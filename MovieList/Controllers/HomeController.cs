using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieList.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MovieList.Controllers
{
    public class HomeController : Controller
    {
        private MovieContext context { get; set; }       //New

        public HomeController(MovieContext ctx)         //New
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            var movies = context.Movies.OrderBy(m => m.Name).ToList();
            return View(movies);
        }

    }
}
