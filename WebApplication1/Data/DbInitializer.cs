using WebApplication1.Models;

namespace WebApplication1.Data
{
    public static class DbInitializer
    {
        public static void Initialize(WebApplication1Context context)
        {
            if (context.Book.Any())
            {
                return; 
            }

            var books = new Book[]
            {
                new Book
                {
                    Title = "The Great Gatsby",
                    YearOfPublication = 1925,
                    Genre = "Fiction",
                    Price = 10.99M,
                    Author = "F. Scott Fitzgerald",
                    Publisher = "Scribner"
                },
                new Book
                {
                    Title = "To Kill a Mockingbird",
                    YearOfPublication = 1960,
                    Genre = "Fiction",
                    Price = 12.99M,
                    Author = "Harper Lee",
                    Publisher = "J.B. Lippincott & Co."
                },
                new Book
                {
                    Title = "1984",
                    YearOfPublication = 1949,
                    Genre = "Dystopian Fiction",
                    Price = 11.99M,
                    Author = "George Orwell",
                    Publisher = "Secker & Warburg"
                },
                new Book
                {
                    Title = "The Catcher in the Rye",
                    YearOfPublication = 1951,
                    Genre = "Coming-of-Age Fiction",
                    Price = 9.99M,
                    Author = "J.D. Salinger",
                    Publisher = "Little, Brown and Company"
                },
                new Book
                {
                    Title = "Pride and Prejudice",
                    YearOfPublication = 1813,
                    Genre = "Classic",
                    Price = 8.99M,
                    Author = "Jane Austen",
                    Publisher = "T. Egerton, Whitehall"
                },
            };

            context.Book.AddRange(books);
            context.SaveChanges();
        }
    }
}
