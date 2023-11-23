using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

//https://www.facebook.com/watch/?v=309768009749378
//https://learn.microsoft.com/en-us/aspnet/core/data/ef-rp/sort-filter-page?view=aspnetcore-6.0#add-sorting
namespace WebApplication1.Pages.Books
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly WebApplication1.Data.WebApplication1Context _context;

        public IndexModel(WebApplication1.Data.WebApplication1Context context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; } = default!;

        // Filter
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Genres { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? BookGenre { get; set; }

        // Sort
        public string TitleSort { get; set; }
        public string YearOfPublicationSort { get; set; }
        public string GenreSort { get; set; }
        public string PriceSort { get; set; }
        public string AuthorSort { get; set; }
        public string PublisherSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public async Task OnGetAsync(string sortOrder, string searchString)
        {

            // using System;
            TitleSort = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            PriceSort = sortOrder == "Price" ? "price_desc" : "Price";
            YearOfPublicationSort = sortOrder == "YearOfPublication" ? "yearOfPublication_desc" : "YearOfPublication";
            GenreSort = sortOrder == "Genre" ? "genre_desc" : "Genre";
            AuthorSort = sortOrder == "Author" ? "author_desc" : "Author";
            PublisherSort = sortOrder == "Publisher" ? "publisher_desc" : "Publisher";

            CurrentFilter = searchString;


            IQueryable<Book> books= from s in _context.Book
                                             select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                books = books.Where(s => s.Title.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "title_desc":
                    books = books.OrderByDescending(s => s.Title);
                    break;
                case "Price":
                    books = books.OrderBy(s => s.Price);
                    break;
                case "price_desc":
                    books = books.OrderByDescending(s => s.Price);
                    break;
                case "YearOfPublication":
                    books = books.OrderBy(s => s.YearOfPublication);
                    break;
                case "yearOfPublication_desc":
                    books = books.OrderByDescending(s => s.YearOfPublication);
                    break;
                case "Genre":
                    books = books.OrderBy(s => s.Genre);
                    break;
                case "genre_desc":
                    books = books.OrderByDescending(s => s.Genre);
                    break;
                case "Author":
                    books = books.OrderBy(s => s.Author);
                    break;
                case "author_desc":
                    books = books.OrderByDescending(s => s.Author);
                    break;
                case "Publisher":
                    books = books.OrderBy(s => s.Publisher);
                    break;
                case "publisher_desc":
                    books = books.OrderByDescending(s => s.Publisher);
                    break;
                default:
                    books = books.OrderBy(s => s.Title);
                    break;
            }
            Book = await books.ToListAsync();
        }
    }
}
