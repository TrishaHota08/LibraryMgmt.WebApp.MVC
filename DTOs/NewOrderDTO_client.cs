
using LibraryMgmt.WebApp.MVC.Helper.CustomValidationAttributes;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LibraryMgmt.WebApp.MVC.DTOs
{
    public class NewOrderDTO_client
    {
        [Required(ErrorMessage ="Staff ID is required")]
        [DisplayName("Staff Id")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Only numeric values are allowed.")]
        [PositiveNumber(ErrorMessage = "Please enter a positive number.")]
        public int StaffId { get; set; }

        [Required]
        [DisplayName("Book Name")]
        public string BookName { get; set; }

        [Required(ErrorMessage = "Customer Ph Num is required")]
        [DisplayName("Customer Ph Num")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Only numeric values are allowed.")]
        [StringLength(10, ErrorMessage = "The phone number must be exactly 10 digits.")]
        [MinLength(10, ErrorMessage = "The phone number must be exactly 10 digits.")]
        [PositiveNumber(ErrorMessage = "Please enter a positive number.")]
        public string CustomerPhoneNumber { get; set; }

        [Required(ErrorMessage = "Issued Date is required")]
        [DisplayName("Issued Date")]
        public DateTime IssuedDate { get; set; }

        [Required(ErrorMessage = "Due Date is required")]
        [DateGreaterThan("IssuedDate", ErrorMessage = "Departure date must be later than the issued date.")]
        [DisplayName("Due Date")]
        public DateTime DueDate { get; set; }
    }
}
