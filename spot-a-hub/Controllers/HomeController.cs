using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace spot_a_hub.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {

        [HttpGet]
        [Route("/books")]
        public ActionResult Index()
        {
          
            var books = new List<Books> 
            {
                new() {  BookId = 1, Author = "Tobby Umoh", DateAdded = DateTime.Now, NumberOfPages = 300, Title = "When the cock grows"},
                new() {  BookId = 2, Author = "Tobby Jay", DateAdded = DateTime.Now, NumberOfPages = 350, Title = "When the cock grows (part 2)"},
                new() {  BookId = 3, Author = "Tobby ", DateAdded = DateTime.Now, NumberOfPages = 370, Title = "When the cock grows (part 3)"},
                new() {  BookId = 4, Author = "T Jay", DateAdded = DateTime.Now, NumberOfPages = 380, Title = "When the cock grows (part 4)"},
                new() {  BookId = 5, Author = "Tobby Umoh", DateAdded = DateTime.Now, NumberOfPages = 400, Title = "When the cock grows (part 5)"},
                
            };
            return Ok(books);
        }
    }
}
