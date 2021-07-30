using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.OrderAggregate
{
    public class Order
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        public DateTime CreatedDate { get; private set; }
        public Address Address { get; private set; }
        public string BuyerId { get; private set; }

        private readonly List<OrderItem> _orderItems;

        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;

        public Order()
        {

        }
        public Order(string buyerId, Address address)
        {
            _orderItems = new List<OrderItem>();
            CreatedDate = DateTime.Now;
            BuyerId = buyerId;
            Address = address;
        }

        public void AddOrderItem(string orderId,string productId, string productName, string pictureUrl, decimal price, int quantity)
        {
            var existProduct = _orderItems.Any(d => d.ProductId == productId);

            if (!existProduct)
            {
                var newOrderItem = new OrderItem(orderId,productId, productName, pictureUrl, price, quantity);
                _orderItems.Add(newOrderItem);
            }
        }

        [BsonIgnore]
        public decimal GetTotalPrice => _orderItems.Sum(d => d.Price);
    }
}
