using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HealthInsurance.EntityLayer.Concrete.Dtos;
using HealthInsurance.EntityLayer.Concrete.Models;

namespace HealthInsurance.EntityLayer.Concrete.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Mappers
            CreateMap<Card, DtoCard>().ReverseMap();
            CreateMap<CorporateCustomer, DtoCorporateCustomer>().ReverseMap();
            CreateMap<Customer, DtoCustomer>().ReverseMap();
            CreateMap<IndividualCustomer, DtoIndividualCustomer>().ReverseMap();
            CreateMap<Order, DtoOrder>().ReverseMap();
            CreateMap<Payment, DtoPayment>().ReverseMap();
            CreateMap<Product, DtoProduct>().ReverseMap();
            #endregion

            CreateMap<Order, DtoGeneralManagerScreen>()
                .ForMember(dest => dest.FirstName, opt => opt
                    .MapFrom(src => src.Customer.FirstName))
                .ForMember(dest => dest.LastName, opt => opt
                    .MapFrom(src => src.Customer.LastName))
                .ForMember(dest => dest.Title, opt => opt
                    .MapFrom(src => src.Product.Title))
                .ForMember(dest => dest.Price, opt => opt
                    .MapFrom(src => src.Product.Price));
            //.ForMember(dest => dest.InstallmentType, opt => opt
            //  .MapFrom(src => src.));
        }
    }
}
