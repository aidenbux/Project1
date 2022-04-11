using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieList.Models;

namespace MovieList.Controllers
{
    public class MovieController : Controller
    {
        private MovieContext context { get; set; }

        public MovieController(MovieContext ctx)
        {
            context = ctx;
        }

        [HttpGet]

        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("Edit", new Movie()); //Send Empty Object.
        }

        [HttpGet]

        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var movie = context.Movies.Find(id); //Read data for id.
            return View("Edit", movie); //send movie object to view.
        }

        [HttpPost]

        public IActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                if (movie.MovieId == 0) // add the movie if not there
                {
                    context.Movies.Add(movie);
                }
                else // Update the movie if there
                {
                    context.Movies.Update(movie);
                }

                context.SaveChanges(); //Saves to database

                return RedirectToAction("Index", "Home"); //Reloads data and shows user updated data
            }
            else
            {
                ViewBag.Action = (movie.MovieId == 0) ? "Add" : "Edit";
                return View(movie);
            }   //31:18


            //Not needed after above

            //ViewBag.Action = "Edit";
            //var movie = context.Movies.Find(id); //Read data for id.
            //return View("Edit", movie); //send movie object to view.
        }
    }
}
