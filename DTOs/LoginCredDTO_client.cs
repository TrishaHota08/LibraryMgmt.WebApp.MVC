using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace LibraryMgmt.WebApp.MVC.DTOs
{
    public class LoginCredDTO_client
    {
        [Required(ErrorMessage = "Email is required")]
        [DisplayName("Email")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
