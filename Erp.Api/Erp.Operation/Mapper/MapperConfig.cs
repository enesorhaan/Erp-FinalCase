using AutoMapper;
using Erp.Data.Entities;
using Erp.Dto;

namespace Erp.Operation.Mapper
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<CompanyRequest, Company>();
            CreateMap<Company, CompanyResponse>();

            CreateMap<DealerRequest, Dealer>();
            CreateMap<Dealer, DealerResponse>()
                .ForMember(dest => dest.Company,
                    opt => opt.MapFrom(src => src.Company.CompanyName));

            CreateMap<CurrentAccountRequest, CurrentAccount>();
            CreateMap<CurrentAccount, CurrentAccountResponse>()
                .ForMember(dest => dest.Dealer,
                    opt => opt.MapFrom(src => src.Dealer.DealerName))
                .ForMember(dest => dest.Company,
                    opt => opt.MapFrom(src => src.Company.CompanyName));

            CreateMap<ProductRequest, Product>();
            CreateMap<Product, ProductResponse>()
                .ForMember(dest => dest.Company,
                    opt => opt.MapFrom(src => src.Company.CompanyName));

            CreateMap<OrderRequest, Order>();
            CreateMap<Order, OrderResponse>()
                .ForMember(dest => dest.Dealer,
                    opt => opt.MapFrom(src => src.Dealer.DealerName));

            CreateMap<OrderItemRequest, OrderItem>();
            CreateMap<OrderItem, OrderItemResponse>()
                .ForMember(dest => dest.Order,
                    opt => opt.MapFrom(src => src.Order))
                .ForMember(dest => dest.Product,
                    opt => opt.MapFrom(src => src.Product.ProductName));

            CreateMap<MessageRequest, Message>();
            CreateMap<Message, MessageResponse>()
                .ForMember(dest => dest.Dealer,
                    opt => opt.MapFrom(src => src.Dealer))
                .ForMember(dest => dest.Company,
                    opt => opt.MapFrom(src => src.Company.CompanyName));
        }
    }
}
