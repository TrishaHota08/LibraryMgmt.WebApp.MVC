using AutoMapper;
using LibraryMgmt.EFCore.Service.DTOs;
using LibraryMgmt.WebApp.MVC.DTOs;
using LibraryMgmt.WebApp.MVC.Helper;
using LibraryMgmt.WebApp.MVC.Models;
using LibraryMgmt.WebApp.MVC.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Sockets;

namespace LibraryMgmt.WebApp.MVC.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly ApiHttpClient _apiClient;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public OrderController(ApiHttpClient apiHttpClient, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _apiClient = apiHttpClient;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<IActionResult> List()
        {
            try
            {
                var response = await _apiClient.GetAsync<IEnumerable<OrderDTO>>("/api/Order");
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var orderViewModel = new OrdersViewModel(_mapper.Map<IEnumerable<OrderDTO_client>>(response.Data));
                    return View(orderViewModel);
                }
                else if(response.StatusCode == HttpStatusCode.NotFound)
                {
                    var orderViewModel = new OrdersViewModel(Enumerable.Empty<OrderDTO_client>());
                    return View(orderViewModel);
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

        public async Task<IActionResult> AddOrder()
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
        public async Task<IActionResult> AddOrder(NewOrderDTO_client order)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    NewOrderDTO newOrder = _mapper.Map<NewOrderDTO>(order);
                    var data = await _apiClient.PostAsync<NewOrderDTO, OrderDTO>("/api/CreateOrder", newOrder);
                    if (data.StatusCode == HttpStatusCode.OK)
                    {
                        return RedirectToAction("AddSuccess");
                    }
                    else if(data.StatusCode == HttpStatusCode.NotFound)
                    {
                        ViewBag.ErrorMessage = "Customer not found! Please enter registered customer phone number.";
                    }
                    else if (data.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        ViewBag.ErrorMessage = "Staff not found! Please enter correct staff ID.";
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "Network connection issue! Please try after some time.";
                        return View("ErrorView"); ;
                    }
                }

                return View();
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("ErrorView");
            }

        }

        public IActionResult AddSuccess()
        {
            ViewBag.AddSuccessMessage = "Book issued successfully";
            return View();
        }
    }
}
