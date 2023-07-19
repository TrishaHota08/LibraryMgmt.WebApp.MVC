using LibraryMgmt.WebApp.MVC.Helper.CustomValidationAttributes;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LibraryMgmt.WebApp.MVC.DTOs
{
    public class BookDTO_client
    {
        public int BookId { get; set; }
        [Required]
        [MaxLength(80,ErrorMessage ="The Title is too long.")]
        [DisplayName("Book Name")]
        public string Title { get; set; }

        [DisplayName("Book Status")]
        public string BookStatus { get; set; }

        [Required]
        [DisplayName("Price")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Only numeric values are allowed.")]
        [PositiveNumber(ErrorMessage = "Please enter a positive number.")]
        public int Price { get; set; }

    }
}
