using Product.API.Model;
using Product.API.Model.ProductItemModel;
using Product.API.Repository;
using Product.API.Services.Abstractions;
using Shared.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Product.API.Services
{
    public class ProductItemService : IProductItemService
    {
        private readonly IRepository<ProductItem> _productItemRepository;

        private readonly IProductBrandService _productBrandService;
        private readonly IProductTypeService _productTypeService;

        public ProductItemService(IRepository<ProductItem> productItemRepository, IProductBrandService productBrandService, IProductTypeService productTypeService)
        {
            _productItemRepository = productItemRepository;
            _productBrandService = productBrandService;
            _productTypeService = productTypeService;
        }

        public async Task<ResponseDto<ProductItem>> CreateAsync(ProductItem productItem)
        {
            var result = await _productItemRepository.CreateAsync(productItem);
            return ResponseDto<ProductItem>.Success(result, 200);
        }

        public async Task<ResponseDto<ProductItem>> DeleteAsync(string id)
        {
            await _productItemRepository.DeleteAsync(id);
            return ResponseDto<ProductItem>.Success(200);
        }

        public async Task<ResponseDto<ProductItemViewModel>> GetAsync(string id)
        {
            var result = await _productItemRepository.GetAsync(id);

            return ResponseDto<ProductItemViewModel>.Success(await ItemToViewItem(result), 200);
        }

        public async Task<ResponseDto<List<ProductItemViewModel>>> GetListAsync(int pageSize, int pageIndex)
        {
            var result = await _productItemRepository.GetListAsync(new RequestQuery { Limit = pageSize, Skip = pageSize * pageIndex });
            List<ProductItemViewModel> viewList = new List<ProductItemViewModel>();
            
            foreach (var item in result)
            {
                viewList.Add(await ItemToViewItem(item));
            }

            return ResponseDto<List<ProductItemViewModel>>.Success(viewList, 200);
        }

        public async Task<ResponseDto<ProductItem>> UpdateAsync(string id,ProductItem productItem)
        {
            var result = await _productItemRepository.UpdateAsync(id, productItem);
            return ResponseDto<ProductItem>.Success(result, 200);
        }

        private async Task<ProductItemViewModel> ItemToViewItem(ProductItem productItem)
        {
            return new ProductItemViewModel
            {
                Id = productItem.Id,
                Created = productItem.Created,
                Updated = productItem.Updated,
                Name = productItem.Name,
                Description = productItem.Description,
                Price = productItem.Price,
                PictureFileName = productItem.PictureFileName,
                PictureUri = productItem.PictureUri,
                ProductTypeId = productItem.ProductTypeId,
                ProductBrandId = productItem.ProductBrandId,
                AvailableStock = productItem.AvailableStock,
                ProductBrand = (await _productBrandService.GetAsync(productItem.ProductBrandId.ToString())).Data,
                ProductType = (await _productTypeService.GetAsync(productItem.ProductTypeId.ToString())).Data,
            };
        }
    }
}
