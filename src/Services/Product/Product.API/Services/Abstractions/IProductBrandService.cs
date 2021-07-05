using Product.API.Model.ProductBrandModel;
using Shared.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Product.API.Services.Abstractions
{
    public interface IProductBrandService
    {
        Task<ResponseDto<List<ProductBrand>>> GetListAsync();
        Task<ResponseDto<ProductBrand>> GetAsync(string id);
        Task<ResponseDto<ProductBrand>> CreateAsync(ProductBrand productBrand);
        Task<ResponseDto<ProductBrand>> UpdateAsync(string id, ProductBrand productBrand);
        Task<ResponseDto<ProductBrand>> DeleteAsync(string id);

    }
}
