using Product.API.Model;
using Shared.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Product.API.Services.Abstractions
{
    public interface IProductBrandService
    {
        Task<ResponseDto<List<ProductBrand>>> GetAllAsync();

        Task<ResponseDto<ProductBrand>> CreateAsync(ProductBrand productBrand);

        Task<ResponseDto<ProductBrand>> GetByIdAsync(string Id);
    }
}
