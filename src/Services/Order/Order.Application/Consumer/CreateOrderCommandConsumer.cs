using MassTransit;
using MongoDB.Driver;
using Order.Infrastructure.Settings;
using Shared.Messages;
using System.Threading.Tasks;

namespace Order.Application.Consumer
{
    public class CreateOrderCommandConsumer : IConsumer<CreateOrderMessageCommand>
    {
        private readonly IMongoCollection<Order.Domain.OrderAggregate.Order> _orderCollection;
        private readonly IMongoCollection<Order.Domain.OrderAggregate.OrderItem> _orderItemCollection;
        public CreateOrderCommandConsumer(IMongoDbSettings mongoDbSettings)
        {
            var client = new MongoClient(mongoDbSettings.ConnectionString);
            var database = client.GetDatabase(mongoDbSettings.DatabaseName);
            _orderCollection = database.GetCollection<Order.Domain.OrderAggregate.Order>(mongoDbSettings.OrderCollectionName);
            _orderItemCollection = database.GetCollection<Order.Domain.OrderAggregate.OrderItem>(mongoDbSettings.OrderItemCollectionName);
        }

        public async Task Consume(ConsumeContext<CreateOrderMessageCommand> context)
        {
            var newAddress = new Domain.OrderAggregate.Address(context.Message.Province, context.Message.District, context.Message.Street);

            Domain.OrderAggregate.Order order = new Domain.OrderAggregate.Order(context.Message.BuyerId, newAddress);

            await _orderCollection.InsertOneAsync(order);

            context.Message.OrderItems.ForEach(d =>
            {
                order.AddOrderItem(order.Id,d.ProductId, d.ProductName, d.PictureUrl, d.Price, d.Quantity);
            });

            await _orderItemCollection.InsertManyAsync(order.OrderItems);
            
        }
    }
}
