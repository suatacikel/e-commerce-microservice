using Shared.ControllerBases;
using Microsoft.AspNetCore.Mvc;
using Product.API.Services.Abstractions;
using System.Threading.Tasks;
using Product.API.Model;

namespace Product.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductBrandsController : CustomBaseController
    {
        private readonly IProductBrandService _productBrandService;

        public ProductBrandsController(IProductBrandService productBrandService)
        {
            _productBrandService = productBrandService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string id)
        {
            var response = await _productBrandService.GetAsync(id);

            return CreateActionResultInstance(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductBrand productBrand)
        {
            var response = await _productBrandService.CreateAsync(productBrand);

            return CreateActionResultInstance(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductBrand productBrand)
        {
            var response = await _productBrandService.UpdateAsync(productBrand.Id,productBrand);

            return CreateActionResultInstance(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            var response = await _productBrandService.DeleteAsync(id);

            return CreateActionResultInstance(response);
        }

        //[HttpGet]
        //[Route("/api/v1/brands")]
        //public async Task<IActionResult> GetListAsync([FromQuery] ProductBrandListRequestQuery request)
        //{
        //    var response = await _productBrandService.GetListAsync(request);

        //    return CreateActionResultInstance(response);
        //}
    }
}
