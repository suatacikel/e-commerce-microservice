using AutoMapper;
using Order.Application.Dtos;

namespace Order.Application.Mapping
{
    class CustomMappingProfile : Profile
    {
        public CustomMappingProfile()
        {
            CreateMap<Domain.OrderAggregate.Order, OrderDto>().ReverseMap();
            CreateMap<Domain.OrderAggregate.OrderItem, OrderItemDto>().ReverseMap();
            CreateMap<Domain.OrderAggregate.Address, AddressDto>().ReverseMap();
        }
    }
}
