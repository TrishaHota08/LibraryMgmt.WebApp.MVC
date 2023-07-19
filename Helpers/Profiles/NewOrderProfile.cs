using LibraryMgmt.EFCore.Service.DTOs;
using LibraryMgmt.WebApp.MVC.DTOs;
using AutoMapper;

namespace LibraryMgmt.WebApp.MVC.Helper.Profiles
{
    public class NewOrderProfile : Profile
    {
        public NewOrderProfile()
        {
            CreateMap<NewOrderDTO, NewOrderDTO_client>().ReverseMap();
        }
    }
}