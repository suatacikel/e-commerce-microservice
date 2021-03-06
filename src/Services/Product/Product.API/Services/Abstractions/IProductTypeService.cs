using Product.API.Model.ProductTypeModel;
using Shared.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Product.API.Services.Abstractions
{
    public interface IProductTypeService
    {
        Task<ResponseDto<List<ProductType>>> GetListAsync();
        Task<ResponseDto<ProductType>> GetAsync(string id);
        Task<ResponseDto<ProductType>> CreateAsync(ProductType productBrand);
        Task<ResponseDto<ProductType>> UpdateAsync(string id, ProductType productBrand);
        Task<ResponseDto<ProductType>> DeleteAsync(string id);
    }
}
