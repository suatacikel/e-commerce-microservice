namespace Basket.API.Dtos
{
    public class BasketItemDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public string PictureUrl { get; set; }

        private decimal? DiscountAppliedPrice;
        public decimal GetCurrentPrice
        {
            get => DiscountAppliedPrice != null ? DiscountAppliedPrice.Value : (UnitPrice * Quantity);
        }
        public void AppliedDiscount(decimal discountPrice)
        {
            DiscountAppliedPrice = discountPrice;
        }
    }
}
