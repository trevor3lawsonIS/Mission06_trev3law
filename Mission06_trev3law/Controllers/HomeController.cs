using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission06_trev3law.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission06_trev3law.Controllers
{
    public class HomeController : Controller
    {
        private MovieContext MovieContext { get; set; }

        public HomeController(MovieContext movieContext)
        {
            MovieContext = movieContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Podcasts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult NewMovie()
        {
            ViewBag.Category = MovieContext.Category.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult NewMovie(Movie movie)
        {
            MovieContext.Add(movie);
            MovieContext.SaveChanges();
            return View("Confirmation", movie);
        }

        public IActionResult MyMovies()
        {
            var movies = MovieContext.Movie
                .Include(x => x.Category)
                .OrderBy(x => x.Title)
                .ToList();
            return View(movies);
        }
    }
}
