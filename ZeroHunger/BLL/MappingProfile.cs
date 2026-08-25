using AutoMapper;
using BLL.Models;
using DAL.EF.Tables;

namespace BLL
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<Restaurant, RestaurantModel>().ReverseMap();

 
            CreateMap<Employee, EmployeeModel>().ReverseMap();


            CreateMap<CollectionRequest, CollectionRequestModel>().ReverseMap();

            CreateMap<Distribution, DistributionModel>().ReverseMap();


    
            CreateMap<CollectionRequest, CollectionRequestRestaurantModel>()
                .ForMember(
                    dest => dest.RestaurantName,
                    src => src.MapFrom(x => x.RIdNavigation.Rname)
                );


            CreateMap<CollectionRequest, CollectionRequestEmployeeModel>()
                .ForMember(
                    dest => dest.EmployeeName,
                    src => src.MapFrom(x => x.EIdNavigation.Ename)
                );

 
           

    
            CreateMap<Distribution, DistributionEmployeeModel>()
                .ForMember(
                    dest => dest.EmployeeName,
                    src => src.MapFrom(x => x.EIdNavigation.Ename)
                );
        }
    }
}