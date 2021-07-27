using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.API.Dtos
{
    public class DiscountApplyDto
    {
        public string DiscountCode { get; set; }
        public int DiscountRate { get; set; }
    }
}
