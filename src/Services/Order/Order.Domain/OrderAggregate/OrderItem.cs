using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Order.Domain.OrderAggregate
{
    public class OrderItem
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string OrderId { get; private set; }
        public string ProductId { get; private set; }
        public string ProductName { get; private set; }

        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string PictureUrl { get; set; }

        public OrderItem()
        {

        }
        public OrderItem(string orderId,string productId, string productName, string pictureUrl, decimal price, int quantity)
        {
            OrderId = orderId;
            ProductId = productId;
            ProductName = productName;
            PictureUrl = pictureUrl;
            Price = price;
            Quantity = quantity;
        }

        public void UpdateOrderItem(string productName, string pictureUrl, decimal price, int quantity)
        {
            ProductName = productName;
            PictureUrl = pictureUrl;
            Price = price;
            Quantity = quantity;
        }

    }
}
