using Product.API.Model.ProductBrandModel;
using Product.API.Model.ProductTypeModel;

namespace Product.API.Model.ProductItemModel
{
    public class ProductItemViewModel : EntityBase<ProductItem>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string PictureFileName { get; set; }

        public string PictureUri { get; set; }

        public int ProductTypeId { get; set; }

        public ProductType ProductType { get; set; }

        public int ProductBrandId { get; set; }

        public ProductBrand ProductBrand { get; set; }

        // Quantity in stock
        public int AvailableStock { get; set; }        
    }
}
