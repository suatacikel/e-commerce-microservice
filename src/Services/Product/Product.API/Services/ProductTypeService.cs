using Product.API.Model;
using Product.API.Repository;
using Product.API.Services.Abstractions;
using Shared.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Product.API.Services
{
    public class ProductTypeService : IProductTypeService
    {
        private readonly IRepository<ProductType> _productTypeRepository;
        public ProductTypeService(IRepository<ProductType> productTypeRepository)
        {
            _productTypeRepository = productTypeRepository;
        }

        public async Task<ResponseDto<ProductType>> CreateAsync(ProductType productBrand)
        {
            var result = await _productTypeRepository.CreateAsync(productBrand);
            return ResponseDto<ProductType>.Success(result, 200);
        }
        public async Task<ResponseDto<ProductType>> GetAsync(string id)
        {
            var result = await _productTypeRepository.GetAsync(id);
            return ResponseDto<ProductType>.Success(result, 200);
        }

        public async Task<ResponseDto<ProductType>> UpdateAsync(string id, ProductType productType)
        {
            var result = await _productTypeRepository.UpdateAsync(id, productType);
            return ResponseDto<ProductType>.Success(result, 200);
        }

        public async Task<ResponseDto<ProductType>> DeleteAsync(string id)
        {
            await _productTypeRepository.DeleteAsync(id);
            return ResponseDto<ProductType>.Success(200);
        }

        public async Task<ResponseDto<IEnumerable<ProductType>>> GetListAsync()
        {
            var results = await _productTypeRepository.GetListAsync(new RequestQuery());
            return ResponseDto<IEnumerable<ProductType>>.Success(results, 200);
        }
    }
}
