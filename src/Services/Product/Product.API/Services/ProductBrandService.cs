using Couchbase;
using Couchbase.Extensions.DependencyInjection;
using Product.API.Model;
using Product.API.Services.Abstractions;
using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.API.Services
{
    public class ProductBrandService : IProductBrandService
    {
        private readonly IBucketProvider _bucket;
        public ProductBrandService(IBucketProvider bucket)
        {
            _bucket = bucket;
        }

        public async Task<ResponseDto<ProductBrand>> CreateAsync(ProductBrand productBrand)
        {
            var productBucket = await _bucket.GetBucketAsync("ProductsBucket");
            var collection = productBucket.DefaultCollection();
            var key = Guid.NewGuid().ToString();
            var upsertResult = await collection.UpsertAsync(key,productBrand);

            return ResponseDto<ProductBrand>.Success(productBrand, 200);
        }

        public async Task<ResponseDto<List<ProductBrand>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDto<ProductBrand>> GetByIdAsync(string Id)
        {
            throw new NotImplementedException();
        }
    }
}
