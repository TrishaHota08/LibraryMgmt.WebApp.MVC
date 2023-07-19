using LibraryMgmt.WebApp.MVC.Helper.CustomValidationAttributes;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LibraryMgmt.WebApp.MVC.DTOs
{
    public class CustomerDTO_client
    {
        [Required(ErrorMessage = "Customer name is required")]
        [DisplayName("Customer Name")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Only numeric values are allowed.")]
        [StringLength(10, ErrorMessage = "The phone number must be exactly 10 digits.")]
        [MinLength(10, ErrorMessage = "The phone number must be exactly 10 digits.")]
        [PositiveNumber(ErrorMessage = "Please enter a positive number.")]
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [DisplayName("Email")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }
    }
}
