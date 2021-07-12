using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.API.Model
{
    public class BasketDto
    {
        public string BuyerId { get; set; }
        public string DiscountCode { get; set; }
        public int? DiscountRate { get; set; }
        public List<BasketItemDto> Items { get; set; } = new List<BasketItemDto>();
        public decimal TotalPrice
        {
            get => Items.Sum(d => d.UnitPrice * d.Quantity);
        }
    }
}
