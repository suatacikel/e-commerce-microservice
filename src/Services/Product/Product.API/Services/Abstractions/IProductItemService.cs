using Product.API.Model.ProductItemModel;
using Shared.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Product.API.Services.Abstractions
{
    public interface IProductItemService
    {
        Task<ResponseDto<List<ProductItemViewModel>>> GetListAsync(int pageSize, int pageIndex);

        Task<ResponseDto<ProductItemViewModel>> GetAsync(string id);

        Task<ResponseDto<ProductItem>> CreateAsync(ProductItem productItem);

        Task<ResponseDto<ProductItem>> UpdateAsync(string  id,ProductItem productItem);

        Task<ResponseDto<ProductItem>> DeleteAsync(string id);
    }
}
