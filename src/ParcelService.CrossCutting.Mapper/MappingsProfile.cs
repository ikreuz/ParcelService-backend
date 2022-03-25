using AutoMapper;
using ParcelService.Application.DTO;
using ParcelService.Domain.Entity;
using System;

namespace ParcelService.CrossCutting.Mapper
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<Customers, CustomersDto>().ReverseMap();


            //CreateMap<Customers, CustomersDto>().ReverseMap()
            //    .ForMember(destination => destination.Customer_Id, source => source.MapFrom(src => src.Customer_Id))
            //    .ForMember(destination => destination.User_Access, source => source.MapFrom(src => src.User_Access))
            //    .ForMember(destination => destination.Branchoffice_Id, source => source.MapFrom(src => src.Branchoffice_Id))
            //    .ForMember(destination => destination.Third_Type_Id, source => source.MapFrom(src => src.Third_Type_Id))
            //    .ForMember(destination => destination.FirstName, source => source.MapFrom(src => src.FirstName))
            //    .ForMember(destination => destination.MiddleName, source => source.MapFrom(src => src.MiddleName))
            //    .ForMember(destination => destination.LastName, source => source.MapFrom(src => src.LastName))
            //    .ForMember(destination => destination.TradeName, source => source.MapFrom(src => src.TradeName))
            //    .ForMember(destination => destination.CompanyName, source => source.MapFrom(src => src.CompanyName))
            //    .ForMember(destination => destination.Rfc, source => source.MapFrom(src => src.Rfc))
            //    .ForMember(destination => destination.Email, source => source.MapFrom(src => src.Email))
            //    .ForMember(destination => destination.With_Agreement, source => source.MapFrom(src => src.With_Agreement))
            //    .ForMember(destination => destination.Date_Creates, source => source.MapFrom(src => src.Date_Creates))
            //    .ForMember(destination => destination.Date_Modifies, source => source.MapFrom(src => src.Date_Modifies))
            //    .ForMember(destination => destination.Date_Authorizes, source => source.MapFrom(src => src.Date_Authorizes))
            //    .ForMember(destination => destination.Usr_Creates_Id, source => source.MapFrom(src => src.Usr_Creates_Id))
            //    .ForMember(destination => destination.Usr_Modifies_id, source => source.MapFrom(src => src.Usr_Modifies_id))
            //    .ForMember(destination => destination.Usr_Authorizes_Id, source => source.MapFrom(src => src.Usr_Authorizes_Id))
            //    .ReverseMap();

            CreateMap<Users, UsersDto>().ReverseMap();
        }
    }
}
