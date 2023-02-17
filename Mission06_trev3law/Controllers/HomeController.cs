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
            ViewBag.Categories = MovieContext.Categories.ToList();
            return View("NewMovie", new Movie());
        }

        [HttpPost]
        public IActionResult NewMovie(Movie movie)
        {
            if (ModelState.IsValid)
            {
                MovieContext.Add(movie);
                MovieContext.SaveChanges();
                return View("Confirmation", movie);
            }
            else
            {
                return View();
            }
        }

        public IActionResult MyMovies()
        {
            var movies = MovieContext.Movies
                .Include(x => x.Category)
                .OrderBy(x => x.Title)
                .ToList();
            return View(movies);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Categories = MovieContext.Categories.ToList();
            var movie = MovieContext.Movies.Single(x => x.MovieID == id);
            return View("NewMovie", movie);
        }
        [HttpPost]
        public IActionResult Edit(Movie movie)
        {
            MovieContext.Update(movie);
            MovieContext.SaveChanges();
            return RedirectToAction("MyMovies");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var movie = MovieContext.Movies.Single(x => x.MovieID == id);
            return View(movie);
        }
        [HttpPost]
        public IActionResult Delete(Movie movie)
        {
            MovieContext.Movies.Remove(movie);
            MovieContext.SaveChanges();
            return RedirectToAction("MyMovies");
        }
    }
}
