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

        [HttpPost]
        public async Task<IActionResult> Create(ProductBrand productBrand)
        {
            var response = await _productBrandService.CreateAsync(productBrand);

            return CreateActionResultInstance(response);
        }
    }
}
