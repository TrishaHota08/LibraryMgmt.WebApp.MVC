using AutoMapper;
using LibraryMgmt.EFCore.Service.DTOs;
using LibraryMgmt.WebApp.MVC.DTOs;

namespace LibraryMgmt.WebApp.MVC.Helpers.Profiles
{
    public class UserAuthTokenProfile:Profile
    {
        public UserAuthTokenProfile()
        {
          CreateMap<UserAuthTokenDTO, UserAuthTokenDTO_client>().ReverseMap();
        }
    }
}
