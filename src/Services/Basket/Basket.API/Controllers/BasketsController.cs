using Basket.API.Model;
using Basket.API.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Shared.ControllerBases;
using Shared.Services;
using System.Threading.Tasks;

namespace Basket.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BasketsController : CustomBaseController
    {
        private readonly IBasketService _basketService;
        private readonly IIdentityService _identityService;

        public BasketsController(IIdentityService identityService, IBasketService basketService)
        {
            _identityService = identityService;
            _basketService = basketService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBasket()
        {
            return CreateActionResultInstance(await _basketService.GetBasketAsync(_identityService.GetUserId));
        }

        [HttpPost]
        public async Task<IActionResult> SaveOrUpdateBasket(BasketDto basketDto)
        {
            basketDto.BuyerId = _identityService.GetUserId;
            var response = await _basketService.SaveOrUpdateAsync(basketDto);

            return CreateActionResultInstance(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            return CreateActionResultInstance(await _basketService.DeleteAsync(_identityService.GetUserId));
        }
    }
}
