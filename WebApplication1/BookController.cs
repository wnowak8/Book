using System;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class BookController : Controller
    {
        [HttpPost]
        public IActionResult AddBook(Book book)
        {
            if (book.YearOfPublication > DateTime.Now.Year)
            {
                ModelState.AddModelError("YearOfPublication", "Year of publication cannot be in the future.");
            }

            // Dodatkowa walidacja dla innych właściwości...

            if (!ModelState.IsValid)
            {
                // Obsługa nieprawidłowych danych wejściowych
                return BadRequest(ModelState);
            }

            // Logika dodawania książki...

            return Ok("Book added successfully!");
        }
    }
}
