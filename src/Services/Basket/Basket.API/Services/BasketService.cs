using Basket.API.Model;
using Basket.API.Services.Abstractions;
using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Basket.API.Services
{
    public class BasketService : IBasketService
    {
        private readonly RedisService _redisService;

        public BasketService(RedisService redisService)
        {
            _redisService = redisService;
        }

        public async Task<ResponseDto<bool>> DeleteAsync(string userId)
        {
            var status = await _redisService.GetDb().KeyDeleteAsync(userId);

            return status ? ResponseDto<bool>.Success(204) : ResponseDto<bool>.Fail("basket not found", 404);
        }

        public async Task<ResponseDto<BasketDto>> GetBasketAsync(string userId)
        {
            var existBasket = await _redisService.GetDb().StringGetAsync(userId);

            if (String.IsNullOrEmpty(existBasket))
            {
                return ResponseDto<BasketDto>.Fail("Basket not found", 404);
            }

            return ResponseDto<BasketDto>.Success(JsonSerializer.Deserialize<BasketDto>(existBasket), 200);

        }

        public async Task<ResponseDto<bool>> SaveOrUpdateAsync(BasketDto basketDto)
        {
            var status = await _redisService.GetDb().StringSetAsync(basketDto.BuyerId, JsonSerializer.Serialize(basketDto));

            return status ? ResponseDto<bool>.Success(204) : ResponseDto<bool>.Fail("basket could not update or save", 500);
        }
    }
}
