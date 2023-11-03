﻿using AutoMapper;
using Erp.Data.Entities;
using Erp.Dto;

namespace Erp.Operation.Mapper
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<CompanyRequest, Company>();
            CreateMap<Company, CompanyResponse>()
                .ForMember(dest => dest.Role,
                    opt => opt.MapFrom(src => src.Role));

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
            CreateMap<Product, ProductResponse>();
            CreateMap<Product, ProductDetailResponse>();

            CreateMap<OrderCreateRequest, Order>();
            CreateMap<OrderUpdateRequest, Order>();
            CreateMap<Order, OrderResponse>()
                .ForMember(dest => dest.Dealer,
                    opt => opt.MapFrom(src => src.Dealer.DealerName));

            CreateMap<OrderItemRequest, OrderItem>();
            CreateMap<OrderItem, OrderItemResponse>()
                .ForMember(dest => dest.Dealer,
                    opt => opt.MapFrom(src => src.Dealer.DealerName))
                .ForMember(dest => dest.Product,
                    opt => opt.MapFrom(src => src.Product.ProductName));

            CreateMap<AdminMessageRequest, Message>();
            CreateMap<DealerMessageRequest, Message>();
            CreateMap<Message, MessageResponse>()
                .ForMember(dest => dest.Dealer,
                    opt => opt.MapFrom(src => src.Dealer))
                .ForMember(dest => dest.Company,
                    opt => opt.MapFrom(src => src.Company.CompanyName));

            CreateMap<ExpenseRequest, Expense>();
            CreateMap<Expense, ExpenseResponse>()
                .ForMember(dest => dest.DealerName,
                    opt => opt.MapFrom(src => src.Dealer));

            CreateMap<LoginRequest, Company>();
            CreateMap<Company, LoginResponse>();

            CreateMap<LoginRequest, Dealer>();
            CreateMap<Dealer, LoginResponse>();

            CreateMap<AdminMessageRequest, MessageResponse>();
            CreateMap<DealerMessageRequest, MessageResponse>();
        }
    }
}
