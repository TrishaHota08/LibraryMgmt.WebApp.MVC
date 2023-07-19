using AutoMapper;
using LibraryMgmt.EFCore.Service.DTOs;
using LibraryMgmt.WebApp.MVC.DTOs;

namespace LibraryMgmt.WebApp.MVC.Helper.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<BookDTO, BookDTO_client>().ReverseMap();
        }
    }
}
