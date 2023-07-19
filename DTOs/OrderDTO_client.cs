using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LibraryMgmt.WebApp.MVC.DTOs
{
    public class OrderDTO_client
    {
        public int OrderId { get; set; }

        public string BookName { get; set; }

        public string CustomerName { get; set; }
        public string CustomerPhoneNumber { get; set; }

        public DateTime IssuedDate { get; set; }
        public DateTime DueDate { get; set; }

    }
}
