using Discount.API.Services;
using Microsoft.AspNetCore.Mvc;
using Shared.ControllerBases;
using System.Threading.Tasks;

namespace Discount.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DiscountsController : CustomBaseController
    {
        private readonly IDiscountService _discountService;

        public DiscountsController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return CreateActionResultInstance(await _discountService.GetListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var discount = await _discountService.GetByIdAsync(id);
            return CreateActionResultInstance(discount);
        }

        [HttpGet]
        [Route("/api/v1/[controller]/[action]/{code}")]
        public async Task<IActionResult> GetByCode(string code)
        {
            var discount = await _discountService.GetByCodeAsync(code);

            return CreateActionResultInstance(discount);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Models.Discount discount)
        {
            return CreateActionResultInstance(await _discountService.CreateAsync(discount));
        }

        [HttpPut]
        public async Task<IActionResult> Update(Models.Discount discount)
        {
            return CreateActionResultInstance(await _discountService.UpdateAsync(discount.Id, discount));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            return CreateActionResultInstance(await _discountService.DeleteAsync(id));
        }
    }
}
