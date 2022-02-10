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
                    .MapFrom(src => src.Product.Price)).ReverseMap();
            //.ForMember(dest => dest.InstallmentType, opt => opt
            //  .MapFrom(src => src.));

            CreateMap<CorporateCustomer, DtoDetailCorporateCustomer>()
                .ForMember(dest => dest.Id, opt => opt
                    .MapFrom(src => src.Id))
                .ForMember(dest => dest.CompanyName, opt => opt
                    .MapFrom(src => src.CompanyName))
                .ForMember(dest => dest.TaxNumber, opt => opt
                    .MapFrom(src => src.TaxNumber))
                .ForMember(dest => dest.FirstName, opt => opt
                    .MapFrom(src => src.Customer.FirstName))
                .ForMember(dest => dest.LastName, opt => opt
                    .MapFrom(src => src.Customer.LastName))
                .ForMember(dest => dest.PhoneNumber, opt => opt
                    .MapFrom(src => src.Customer.PhoneNumber))
                .ForMember(dest => dest.Country, opt => opt
                    .MapFrom(src => src.Customer.Country))
                .ForMember(dest => dest.City, opt => opt
                    .MapFrom(src => src.Customer.City))
                .ForMember(dest => dest.Email, opt => opt
                    .MapFrom(src => src.Customer.Email)).ReverseMap();

            CreateMap<IndividualCustomer, DtoDetailIndividualCustomer>()
                .ForMember(dest => dest.Id, opt => opt
                    .MapFrom(src => src.Id))
                .ForMember(dest => dest.IdentityNumber, opt => opt
                    .MapFrom(src => src.IdentityNumber))
                .ForMember(dest => dest.DateOfBirth, opt => opt
                    .MapFrom(src => src.DateOfBirth))
                .ForMember(dest => dest.Gender, opt => opt
                    .MapFrom(src => src.Gender))
                .ForMember(dest => dest.FirstName, opt => opt
                    .MapFrom(src => src.Customer.FirstName))
                .ForMember(dest => dest.LastName, opt => opt
                    .MapFrom(src => src.Customer.LastName))
                .ForMember(dest => dest.PhoneNumber, opt => opt
                    .MapFrom(src => src.Customer.PhoneNumber))
                .ForMember(dest => dest.Country, opt => opt
                    .MapFrom(src => src.Customer.Country))
                .ForMember(dest => dest.City, opt => opt
                    .MapFrom(src => src.Customer.City))
                .ForMember(dest => dest.Email, opt => opt
                    .MapFrom(src => src.Customer.Email)).ReverseMap();
        }
    }
}
