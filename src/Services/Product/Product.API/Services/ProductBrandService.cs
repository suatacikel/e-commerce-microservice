using Couchbase.Extensions.DependencyInjection;
using Couchbase.KeyValue;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Product.API.Model;
using Product.API.Repository;
using Product.API.Services.Abstractions;
using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Product.API.Services
{
    public class ProductBrandService : IProductBrandService
    {
        private readonly IRepository<ProductBrand> _productBrandRepository;
        public ProductBrandService(IRepository<ProductBrand> productBrandRepository)
        {
            _productBrandRepository = productBrandRepository;
        }

        public async Task<ResponseDto<ProductBrand>> CreateAsync(ProductBrand productBrand)
        {
            var result = await _productBrandRepository.CreateAsync(productBrand);
            return ResponseDto<ProductBrand>.Success(result, 200);
        }
        public async Task<ResponseDto<ProductBrand>> GetAsync(string id)
        {
            var result = await _productBrandRepository.GetAsync(id);
            return ResponseDto<ProductBrand>.Success(result, 200);
        }

        public async Task<ResponseDto<ProductBrand>> UpdateAsync(string id, ProductBrand productBrand)
        {
            var result = await _productBrandRepository.UpdateAsync(id, productBrand);
            return ResponseDto<ProductBrand>.Success(result, 200);
        }
        public async Task<ResponseDto<ProductBrand>> DeleteAsync(string id)
        {
            await _productBrandRepository.DeleteAsync(id);
            return ResponseDto<ProductBrand>.Success(200);
        }

        public async Task<ResponseDto<List<ProductBrand>>> GetListAsync(ProductBrandListRequestQuery productBrandListRequestQuery)
        {
            //var cluster = await _clusterProvider.GetClusterAsync();
            //var query = $"SELECT p. * FROM {_couchbaseConfig.BucketName}.{_couchbaseConfig.ScopeName}.{_couchbaseConfig.CollectionName} p WHERE lower(p.Brand) LIKE '%{productBrandListRequestQuery.Search.ToLower()}%' OR lower(p.Brand) LIKE '%{productBrandListRequestQuery.Search.ToLower()}%' LIMIT {productBrandListRequestQuery.Limit} OFFSET {productBrandListRequestQuery.Skip}";

            //var results = await cluster.QueryAsync<ProductBrand>(query);
            //var items = await results.Rows.ToListAsync();

            //return ResponseDto<List<ProductBrand>>.Success(items, 200);

            throw new Exception();
        }

       
    }
}
