using Shared.ControllerBases;
using Microsoft.AspNetCore.Mvc;
using Product.API.Services.Abstractions;
using System.Threading.Tasks;
using Product.API.Model.ProductItemModel;

namespace Product.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductItemsController : CustomBaseController
    {
        private readonly IProductItemService _productItemService;

        public ProductItemsController(IProductItemService productItemService)
        {
            _productItemService = productItemService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int pageSize = 10, [FromQuery] int pageIndex = 0)
        {
            var response = await _productItemService.GetListAsync(pageSize,pageIndex);

            return CreateActionResultInstance(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var response = await _productItemService.GetAsync(id);

            return CreateActionResultInstance(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductItem productItem)
        {
            var response = await _productItemService.CreateAsync(productItem);

            return CreateActionResultInstance(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductItem productItem)
        {
            var response = await _productItemService.UpdateAsync(productItem.Id, productItem);

            return CreateActionResultInstance(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var response = await _productItemService.DeleteAsync(id);

            return CreateActionResultInstance(response);
        }


    }
}
