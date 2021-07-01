namespace Product.API.Model
{
    public class ProductBrandListRequestQuery
    {
        public string Search { get; set; }
        public int Limit { get; set; } = 5;
        public int Skip { get; set; }
    }
}
