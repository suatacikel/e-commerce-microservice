using MediatR;
using MongoDB.Driver;
using Order.Application.Command;
using Order.Application.Dtos;
using Order.Domain.OrderAggregate;
using Order.Infrastructure.Settings;
using Shared.Dtos;
using System.Threading;
using System.Threading.Tasks;

namespace Order.Application.Handlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, ResponseDto<CreatedOrderDto>>
    {
        private readonly IMongoCollection<Order.Domain.OrderAggregate.Order> _orderCollection;
        private readonly IMongoCollection<Order.Domain.OrderAggregate.OrderItem> _orderItemCollection;
        public CreateOrderCommandHandler(IMongoDbSettings mongoDbSettings)
        {
            var client = new MongoClient(mongoDbSettings.ConnectionString);
            var database = client.GetDatabase(mongoDbSettings.DatabaseName);
            _orderCollection = database.GetCollection<Order.Domain.OrderAggregate.Order>(mongoDbSettings.OrderCollectionName);
            _orderItemCollection = database.GetCollection<Order.Domain.OrderAggregate.OrderItem>(mongoDbSettings.OrderItemCollectionName);
        }

        public async Task<ResponseDto<CreatedOrderDto>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var newAddress = new Address(request.Address.Province, request.Address.District, request.Address.Street);

            var newOrder = new Domain.OrderAggregate.Order(request.BuyerId, newAddress);

            await _orderCollection.InsertOneAsync(newOrder);

            request.OrderItems.ForEach(d =>
            {
                newOrder.AddOrderItem(newOrder.Id, d.ProductId, d.ProductName, d.PictureUrl, d.Price, d.Quantity);
            });

            await _orderItemCollection.InsertManyAsync(newOrder.OrderItems);

            return ResponseDto<CreatedOrderDto>.Success(new CreatedOrderDto { OrderId = newOrder.Id }, 200);

        }
    }
}
