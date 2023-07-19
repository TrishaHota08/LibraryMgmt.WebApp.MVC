
using LibraryMgmt.WebApp.MVC.DTOs;

namespace LibraryMgmt.WebApp.MVC.Models
{
    public class CustomersModel
    {
        public IEnumerable<CustomerDTO_client>? Customers { get; set; }
        public CustomersModel(IEnumerable<CustomerDTO_client> customers)
        {
            Customers = customers;
        }
    }
}
