using AutoMapper;
using LibraryMgmt.EFCore.Service.DTOs;
using LibraryMgmt.WebApp.MVC.DTOs;
using LibraryMgmt.WebApp.MVC.Helper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;

namespace LibraryMgmt.WebApp.MVC.Pages
{
    public class DeleteBookModel : PageModel
    {
        private readonly ApiHttpClient _apiClient;
        public DeleteBookModel(ApiHttpClient apiHttpClient)
        {
            _apiClient = apiHttpClient;
        }

        [BindProperty]
        public BookDTO_client Book { get; set; }

        public void OnGet()
        {
           
        }

        public async Task<IActionResult> OnPost()
        {
            try
            {
                var response = await _apiClient.DeleteAsync("/api/Book?bookName=", Book.Title);
                    if (response == HttpStatusCode.OK)
                    {
                        return RedirectToPage("AddSuccessPage");
                    }

                return RedirectToPage("ErrorPage");
                            
            }
            catch 
            {
                 return RedirectToAction("Index", "Home");
            }
        }
    }
}
