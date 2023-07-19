using LibraryMgmt.WebApp.MVC.DTOs;

namespace LibraryMgmt.WebApp.MVC.ViewModel
{
    public class NewOrderViewModel
    {
        public IEnumerable<NewOrderDTO_client> NewOrders { get; set; }
        public NewOrderViewModel(IEnumerable<NewOrderDTO_client> newOrders)
        {
            NewOrders = newOrders;
        }
    }
}
