using MediatR;
using Order.Application.Dtos;
using Shared.Dtos;
using System.Collections.Generic;

namespace Order.Application.Command
{
    public class CreateOrderCommand: IRequest<ResponseDto<CreatedOrderDto>>
    {
        public string BuyerId { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
        public AddressDto Address { get; set; }
    }
}
