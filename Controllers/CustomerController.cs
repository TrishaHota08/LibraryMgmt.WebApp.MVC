using AutoMapper;
using LibraryMgmt.EFCore.Service.DTOs;
using LibraryMgmt.WebApp.MVC.DTOs;
using LibraryMgmt.WebApp.MVC.Helper;
using LibraryMgmt.WebApp.MVC.Models;
using LibraryMgmt.WebApp.MVC.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Net;
using System.Net.Sockets;

namespace LibraryMgmt.WebApp.MVC.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        private readonly ApiHttpClient _apiClient;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CustomerController(ApiHttpClient apiHttpClient, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _apiClient = apiHttpClient;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IActionResult> AddCustomer()
        {
            if(!string.IsNullOrEmpty(_httpContextAccessor.HttpContext.Request.Cookies["jwtToken"]))
            {
                return View();
            }
            else
            {
                return View("Unauthorized");
            }
        }

        public async Task<IActionResult> List()
        {
            try
            {
                var response = await _apiClient.GetAsync<IEnumerable<CustomerDTO>>("/api/Customer");
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var customerModel = new CustomersModel(_mapper.Map<IEnumerable<CustomerDTO_client>>(response.Data));
                    return View(customerModel);
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    var customerModel = new CustomersModel(Enumerable.Empty<CustomerDTO_client>());
                    return View(customerModel);
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
                // Handle SocketException
                // For example, display an error message or redirect to an error page
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer(CustomerDTO_client customer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CustomerDTO newCustomer = _mapper.Map<CustomerDTO>(customer);
                    var data = await _apiClient.PostAsync<CustomerDTO, CustomerDTO>("/api/Customer", newCustomer);
                    if (data.StatusCode == HttpStatusCode.OK)
                    {
                        return RedirectToAction("AddSuccess");
                    }
                    else if (data.StatusCode == HttpStatusCode.Forbidden)
                    {
                        ViewBag.ErrorMessage = "Customer already present! ";
                    }
                    else 
                    {

                        ViewBag.ErrorMessage = "Network connection issue! Please try after some time.";
                        return View("ErrorView");
                    }
                }
                return View();
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index", "Home");
            }
        }

        public  IActionResult AddSuccess()
        {
            ViewBag.AddSuccessMessage = "Customer added successfully";
            return View();
        }
    }
}
