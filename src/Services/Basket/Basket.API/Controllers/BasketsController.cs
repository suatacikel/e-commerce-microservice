using Basket.API.Dtos;
using Basket.API.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Shared.ControllerBases;
using System.Threading.Tasks;

namespace Basket.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BasketsController : CustomBaseController
    {
        private readonly IBasketService _basketService;

        public BasketsController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBasket()
        {
            return CreateActionResultInstance(await _basketService.GetBasketAsync());
        }

        [HttpPost]
        public async Task<IActionResult> SaveOrUpdateBasket(BasketDto basketDto)
        {
            var response = await _basketService.SaveOrUpdateAsync(basketDto);

            return CreateActionResultInstance(response);
        }

        [HttpPost]
        [Route("/api/v1/[controller]/[action]")]
        public async Task<IActionResult> ApplyDiscount(DiscountApplyDto discountApplyDto)
        {
            var response = await _basketService.ApplyDiscount(discountApplyDto);

            return CreateActionResultInstance(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            return CreateActionResultInstance(await _basketService.DeleteAsync());
        }
    }
}
