using System;

namespace Discount.API.Models
{
    public class Discount : EntityBase<Discount>
    {
        public int Rate { get; set; }
        public string Code { get; set; }
    }
}
