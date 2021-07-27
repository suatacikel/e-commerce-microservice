using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.API.Dtos
{
    public class BasketDto
    {
        public BasketDto()
        {
            _items = new List<BasketItemDto>();
        }
        private List<BasketItemDto> _items;
        public string BuyerId { get; set; }
        public string DiscountCode { get; set; }
        public int? DiscountRate { get; set; }
        public List<BasketItemDto> Items
        {
            get
            {
                if (HasDiscount)
                {
                    _items.ForEach(d =>
                    {
                        var current = d.UnitPrice * d.Quantity;
                        var discountPrice = current * ((decimal)DiscountRate.Value / 100);
                        d.AppliedDiscount(Math.Round(current - discountPrice, 2));
                    });
                }
                return _items;
            }
            set
            {
                _items = value;
            }
        }
        public bool HasDiscount
        {
            get => !string.IsNullOrEmpty(DiscountCode) && DiscountRate.HasValue;
        }
        public decimal TotalPrice
        {
            get => _items.Sum(d => d.GetCurrentPrice);
        }
        public void CancelDiscount()
        {
            DiscountCode = null;
            DiscountRate = null;
        }

        public void ApplyDiscount(string code, int rate)
        {
            DiscountCode = code;
            DiscountRate = rate;
        }
    }
}
