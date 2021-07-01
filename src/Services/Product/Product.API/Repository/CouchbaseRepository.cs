using Couchbase.Core.Exceptions.KeyValue;
using Couchbase.Extensions.DependencyInjection;
using Couchbase.KeyValue;
using Microsoft.Extensions.Options;
using Product.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.API.Repository
{
    public class CouchbaseRepository<T> : IRepository<T> where T : EntityBase<T>
    {
        private readonly IClusterProvider _clusterProvider;
        private readonly IBucketProvider _bucketProvider;
        private readonly CouchbaseConfig _couchbaseConfig;

        public CouchbaseRepository(IBucketProvider bucketProvider, IClusterProvider clusterProvider, IOptions<CouchbaseConfig> options)
        {
            _bucketProvider = bucketProvider;
            _clusterProvider = clusterProvider;
            _couchbaseConfig = options.Value;
        }

        public async Task<T> GetAsync(string id)
        {
            try
            {
                var key = CreateKey(id);
                var collection = await getCouchbaseCollection();
                var result = await collection.GetAsync(key);
                var item = result.ContentAs<T>();
                return item;
            }
            catch (DocumentNotFoundException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<T> CreateAsync(T item)
        {
            try
            {
                var collection = await getCouchbaseCollection();
                item.Created = DateTime.Now;
                item.Updated = DateTime.Now;
                item.Id = await AppendKeyIncrement(collection);

                var key = CreateKey(item.Id);

                await collection.InsertAsync(key, item);

                return item;
            }
            catch (DocumentExistsException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<T> UpdateAsync(string id, T item)
        {
            try
            {
                item.Updated = DateTime.Now;

                var key = CreateKey(id);

                var collection = await getCouchbaseCollection();
                await collection.ReplaceAsync(key, item);

                return item;
            }
            catch (DocumentNotFoundException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteAsync(string id)
        {
            var key = CreateKey(id);

            var collection = await getCouchbaseCollection();
            await collection.RemoveAsync(key);
        }

        private async Task<ICouchbaseCollection> getCouchbaseCollection()
        {
            var bucket = await _bucketProvider.GetBucketAsync(_couchbaseConfig.BucketName);
            var scope = bucket.Scope(_couchbaseConfig.ScopeName);
            var collection = scope.Collection(_couchbaseConfig.CollectionName);

            return collection;
        }

        private string CreateKey(string id)
        {
            return string.Format($"{typeof(T).Name.ToLower()}::{id}");
        }

        private async Task<string> AppendKeyIncrement(ICouchbaseCollection collection)
        {
            string counterKey = $"{typeof(T).Name.ToLower()}::counter";

            var result = await collection.Binary.IncrementAsync(counterKey);
            var item = result.Content;
            return item.ToString();
        }

    }
}
