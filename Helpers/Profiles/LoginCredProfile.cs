using AutoMapper;
using LibraryMgmt.WebApp.MVC.DTOs;
using LibraryMgmt.EFCore.Service.DTOs;

namespace LibraryMgmt.WebApp.MVC.Helpers.Profiles
{
    public class LoginCredProfile:Profile
    {
        public LoginCredProfile()
        {
            CreateMap<LoginCredDTO, LoginCredDTO_client>().ReverseMap();
        }
    }
}
