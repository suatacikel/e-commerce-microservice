using Product.API.Model;
using Shared.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Product.API.Services.Abstractions
{
    public interface IProductTypeService
    {
        Task<ResponseDto<List<ProductType>>> GetAllAsync();

        Task<ResponseDto<ProductType>> CreateAsync(ProductType productType);

        Task<ResponseDto<ProductType>> GetByIdAsync(string Id);
    }
}
