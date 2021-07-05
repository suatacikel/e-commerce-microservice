using Shared.ControllerBases;
using Microsoft.AspNetCore.Mvc;
using Product.API.Services.Abstractions;
using System.Threading.Tasks;
using Product.API.Model;

namespace Product.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductTypesController : CustomBaseController
    {
        private readonly IProductTypeService _productTypeService;

        public ProductTypesController(IProductTypeService productTypeService)
        {
            _productTypeService = productTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _productTypeService.GetListAsync();

            return CreateActionResultInstance(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var response = await _productTypeService.GetAsync(id);

            return CreateActionResultInstance(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductType productType)
        {
            var response = await _productTypeService.CreateAsync(productType);

            return CreateActionResultInstance(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductType productType)
        {
            var response = await _productTypeService.UpdateAsync(productType.Id, productType);

            return CreateActionResultInstance(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var response = await _productTypeService.DeleteAsync(id);

            return CreateActionResultInstance(response);
        }

        
    }
}
