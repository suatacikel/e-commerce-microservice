using Shared.Dtos;
using System.Threading.Tasks;
using Basket.API.Model;

namespace Basket.API.Services.Abstractions
{
    public interface IBasketService
    {
        Task<ResponseDto<BasketDto>> GetBasketAsync(string userId);

        Task<ResponseDto<bool>> SaveOrUpdateAsync(BasketDto basketDto);

        Task<ResponseDto<bool>> DeleteAsync(string userId);
    }
}
