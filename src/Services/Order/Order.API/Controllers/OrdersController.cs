using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Order.Application.Command;
using Shared.ControllerBases;
using Shared.Dtos;
using Shared.Messages;
using Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OrdersController : CustomBaseController
    {
        private readonly IMediator _mediator;
        private readonly ISendEndpointProvider _sendEndpointProvider;

        public OrdersController(IMediator mediator, ISendEndpointProvider sendEndpointProvider)
        {
            _mediator = mediator;
            _sendEndpointProvider = sendEndpointProvider;
        }


        [HttpPost]
        public async Task<IActionResult> SaveOrder(CreateOrderCommand createOrderCommand)
        {
            var response = await _mediator.Send(createOrderCommand);

            return CreateActionResultInstance(response);

        }

        [HttpPost]
        [Route("/api/v1/[controller]/[action]")]
        public async Task<IActionResult> SaveOrderRabbitMQ(CreateOrderCommand createOrderCommand)
        {
            var sendEndPoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("queue:create-order-service"));

            var createOrderMessageCommand = new CreateOrderMessageCommand();

            createOrderMessageCommand.BuyerId = createOrderCommand.BuyerId;

            createOrderMessageCommand.Province = createOrderCommand.Address.Province;
            createOrderMessageCommand.District = createOrderCommand.Address.District;
            createOrderMessageCommand.Street = createOrderCommand.Address.Street;

            createOrderCommand.OrderItems.ForEach(d =>
            {
                createOrderMessageCommand.OrderItems.Add(
                    new OrderItem
                    {
                        PictureUrl = d.PictureUrl,
                        Price = d.Price,
                        ProductId = d.ProductId,
                        ProductName = d.ProductName
                    });
            });

            await sendEndPoint.Send<CreateOrderMessageCommand>(createOrderMessageCommand);

            return CreateActionResultInstance(ResponseDto<NoContentDto>.Success(200));
        }
    }
}
