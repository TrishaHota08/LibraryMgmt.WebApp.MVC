using LibraryMgmt.EFCore.Service.DTOs;
using LibraryMgmt.WebApp.MVC.DTOs;
using AutoMapper;

namespace LibraryMgmt.WebApp.MVC.Helper.Profiles
{
    public class OrderProfile:Profile
    {
        public OrderProfile() 
        {
            CreateMap<OrderDTO, OrderDTO_client>().ReverseMap();
        }
    }
}
