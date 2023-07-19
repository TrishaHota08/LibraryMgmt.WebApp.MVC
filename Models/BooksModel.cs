

using LibraryMgmt.WebApp.MVC.DTOs;

namespace LibraryMgmt.WebApp.MVC.Models
{
    public class BooksModel
    {
        public IEnumerable<BookDTO_client>? Books { get; set; }
        public BooksModel(IEnumerable<BookDTO_client> books)
        {
            Books = books;
        }
    }
}
