using Product.API.Model;
using Product.API.Repository;
using Product.API.Services.Abstractions;
using Shared.Dtos;
using System.Collections.Generic;
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

        public async Task<ResponseDto<IEnumerable<ProductBrand>>> GetListAsync()
        {
            var results = await _productBrandRepository.GetListAsync(new RequestQuery());
            return ResponseDto<IEnumerable<ProductBrand>>.Success(results, 200);
        }
    }
}
