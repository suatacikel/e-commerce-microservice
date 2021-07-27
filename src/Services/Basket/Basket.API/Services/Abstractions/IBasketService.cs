using Shared.Dtos;
using System.Threading.Tasks;
using Basket.API.Dtos;

namespace Basket.API.Services.Abstractions
{
    public interface IBasketService
    {
        Task<ResponseDto<BasketDto>> GetBasketAsync();

        Task<ResponseDto<bool>> SaveOrUpdateAsync(BasketDto basketDto);
        Task<ResponseDto<bool>> ApplyDiscount(DiscountApplyDto discountApplyDto);
        Task<ResponseDto<bool>> CancelApplyDiscount();

        Task<ResponseDto<bool>> DeleteAsync();
    }
}
