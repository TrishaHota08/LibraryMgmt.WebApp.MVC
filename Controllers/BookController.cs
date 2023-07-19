using AutoMapper;
using LibraryMgmt.EFCore.Service.DTOs;
using LibraryMgmt.WebApp.MVC.DTOs;
using LibraryMgmt.WebApp.MVC.Helper;
using LibraryMgmt.WebApp.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Sockets;

namespace LibraryMgmt.WebApp.MVC.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        private readonly ApiHttpClient _apiClient;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public BookController(ApiHttpClient apiHttpClient, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _apiClient = apiHttpClient;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IActionResult>  List()
        {
            try
            {
                var response = await _apiClient.GetAsync<IEnumerable<BookDTO>>("/api/Book");
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var BookModel = new BooksModel(_mapper.Map<IEnumerable<BookDTO_client>>(response.Data));
                    return View(BookModel);
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    var BookModel = new BooksModel(Enumerable.Empty<BookDTO_client>());
                    return View(BookModel);
                }
                else if(response.StatusCode==HttpStatusCode.Unauthorized)
                {
                    return View("Unauthorized");
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index", "Home");
            }
        }

        public async Task<IActionResult> ListAll()
        {
            
            try
            {
                var response = await _apiClient.GetAsync<IEnumerable<BookDTO>>("/api/Book/allbooks");
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var BookModel = new BooksModel(_mapper.Map<IEnumerable<BookDTO_client>>(response.Data));
                    return View(BookModel);
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    var BookModel = new BooksModel(Enumerable.Empty<BookDTO_client>());
                    return View(BookModel);
                }
                else if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    return View("Unauthorized");
                }
                else
                {

                    ViewBag.ErrorMessage = "Network connection issue! Please try after some time.";
                    return View("ErrorView");
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("ErrorView");
            }
        }

        public async Task<IActionResult> AddBook()
        {
            if (!string.IsNullOrEmpty(_httpContextAccessor.HttpContext.Request.Cookies["jwtToken"]))
            {
                return View();
            }
            else
            {
                return View("Unauthorized");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(BookDTO_client book)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    BookDTO bookrequest = _mapper.Map<BookDTO>(book);
                    var data = await _apiClient.PostAsync<BookDTO, BookDTO>("/api/Book", bookrequest);
                    if (data.StatusCode == HttpStatusCode.OK)
                    {
                        return RedirectToAction("AddSuccess");
                    }
                    else if(data.StatusCode == HttpStatusCode.Forbidden)
                    {
                        ViewBag.ErrorMessage = "Book already present! ";
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "Network connection issue! Please try after some time.";
                        return View("ErrorView");
                    }
                }
                return View(book);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("ErrorView");
            }
        }

        public IActionResult AddSuccess()
        {
            ViewBag.AddSuccessMessage = "Book added successfully";
            return View();
        }


    }
}
