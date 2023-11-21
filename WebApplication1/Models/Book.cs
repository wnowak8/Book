using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

//https://learn.microsoft.com/en-us/aspnet/core/tutorials/razor-pages/search?view=aspnetcore-7.0
namespace WebApplication1.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(60, MinimumLength = 2, ErrorMessage = "The field Title must be a string with a minimum length of 3 and a maximum length of 60.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Year of publication is required.")]
        [Range(0, 2023, ErrorMessage = "Year of publication cannot be negative or from the future.")]
        public int YearOfPublication { get; set; }

        [StringLength(30, ErrorMessage = "Genre should be at most 30 characters.")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$", ErrorMessage = "Invalid genre format.")]
        public string Genre { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [RegularExpression(@"^\d{1,4}\.\d{2}$", ErrorMessage = "Invalid price format. Use a dot (.) as the decimal separator and provide exactly two decimal places.")]
        public string Price { get; set; }

        [Required(ErrorMessage = "Author is required.")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Publisher is required.")]
        [StringLength(30, ErrorMessage = "Publisher should be at most 30 characters.")]
        public string Publisher { get; set; }
    }
}
