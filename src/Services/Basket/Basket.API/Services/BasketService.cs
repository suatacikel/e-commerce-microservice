using Basket.API.Dtos;
using Basket.API.Services.Abstractions;
using Shared.Dtos;
using Shared.Services;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Basket.API.Services
{
    public class BasketService : IBasketService
    {
        private readonly RedisService _redisService;
        private readonly IIdentityService _identityService;

        public BasketService(RedisService redisService, IIdentityService identityService)
        {
            _redisService = redisService;
            _identityService = identityService;
        }

        public async Task<ResponseDto<bool>> DeleteAsync()
        {
            var status = await _redisService.GetDb().KeyDeleteAsync(_identityService.GetUserId);

            return status ? ResponseDto<bool>.Success(204) : ResponseDto<bool>.Fail("basket not found", 404);
        }

        public async Task<ResponseDto<BasketDto>> GetBasketAsync()
        {
            var existBasket = await _redisService.GetDb().StringGetAsync(_identityService.GetUserId);

            if (String.IsNullOrEmpty(existBasket))
            {
                return ResponseDto<BasketDto>.Fail("Basket not found", 404);
            }

            return ResponseDto<BasketDto>.Success(JsonSerializer.Deserialize<BasketDto>(existBasket), 200);

        }

        public async Task<ResponseDto<bool>> SaveOrUpdateAsync(BasketDto basketDto)
        {
            basketDto.BuyerId = _identityService.GetUserId;
            var status = await _redisService.GetDb().StringSetAsync(basketDto.BuyerId, JsonSerializer.Serialize(basketDto));

            return status ? ResponseDto<bool>.Success(204) : ResponseDto<bool>.Fail("basket could not update or save", 500);
        }
        public async Task<ResponseDto<bool>> ApplyDiscount(DiscountApplyDto discountApplyDto)
        {
            await CancelApplyDiscount();

            var basket = await GetBasketAsync();

            if (basket == null)
                return ResponseDto<bool>.Fail("basket could not found", 500);

            basket.Data.ApplyDiscount(discountApplyDto.DiscountCode, discountApplyDto.DiscountRate);
            await SaveOrUpdateAsync(basket.Data);
            return ResponseDto<bool>.Success(204);
        }

        public async Task<ResponseDto<bool>> CancelApplyDiscount()
        {
            var basket = await GetBasketAsync();

            if (basket == null || basket.Data.DiscountCode == null)
                return ResponseDto<bool>.Fail("calcel apply discount failed", 500);

            basket.Data.CancelDiscount();
            await SaveOrUpdateAsync(basket.Data);
            return ResponseDto<bool>.Success(204);
        }
    }
}
