using LibraryMgmt.WebApp.MVC.DTOs;

namespace LibraryMgmt.WebApp.MVC.ViewModel
{
    public class OrdersViewModel
    {
        public IEnumerable<OrderDTO_client>? Orders { get; set; }
        public OrdersViewModel(IEnumerable<OrderDTO_client> orders)
        {
            Orders = orders;
        }
    }
}
