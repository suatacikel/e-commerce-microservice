using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.OrderAggregate
{
    public class Address
    {
        public string Province { get; private set; }
        public string District { get; private set; }
        public string Street { get; private set; }

        public Address(string province, string district, string street)
        {
            Province = province;
            District = district;
            Street = street;
        }
    }
}
