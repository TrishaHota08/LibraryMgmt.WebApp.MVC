using AutoMapper;
using LibraryMgmt.EFCore.Service.DTOs;
using LibraryMgmt.WebApp.MVC.DTOs;
using LibraryMgmt.WebApp.MVC.Helper;
using Microsoft.AspNetCore.Mvc;

namespace LibraryMgmt.WebApp.MVC.Components
{
    public class BookList : ViewComponent
    {
        private readonly ApiHttpClient _apiClient;
        private readonly IMapper _mapper;
        public BookList(ApiHttpClient apiHttpClient, IMapper mapper)
        {
            _apiClient = apiHttpClient;
            _mapper = mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var response = await _apiClient.GetAsync<IEnumerable<BookDTO>>("/api/Book");
            var availableBooks = _mapper.Map<IEnumerable<BookDTO_client>>(response.Data).ToList();
            return View(availableBooks);
        }
    }
}
