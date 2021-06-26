using Product.API.Model;
using Shared.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Product.API.Services.Abstractions
{
    public interface IProductItemService
    {
        Task<ResponseDto<List<ProductItem>>> GetAllAsync();

        Task<ResponseDto<ProductItem>> GetByIdAsync(string Id);

        Task<ResponseDto<List<ProductItem>>> GetItemsByIdsAsync(string Ids);

        Task<ResponseDto<ProductItem>> CreateAsync(ProductItem productItem);

        Task<ResponseDto<NoContentDto>> UpdateAsync(ProductItem productItem);

        Task<ResponseDto<NoContentDto>> DeleteAsync(string Id);
    }
}
