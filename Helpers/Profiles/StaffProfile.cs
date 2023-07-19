using AutoMapper;
using LibraryMgmt.EFCore.Service.DTOs;
using LibraryMgmt.WebApp.MVC.DTOs;

namespace LibraryMgmt.WebApp.MVC.Helper.Profiles
{
    public class StaffProfile:Profile    
    {
        public StaffProfile()
        {
            CreateMap<StaffDTO, StaffDTO_client>().ReverseMap();
        }
    }
}
