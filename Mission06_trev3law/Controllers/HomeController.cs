using Microsoft.AspNetCore.Mvc;
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
        private readonly ILogger<HomeController> _logger;

        private MovieContext _movieContext { get; set; }

        public HomeController(ILogger<HomeController> logger, MovieContext movieContext)
        {
            _logger = logger;
            _movieContext = movieContext;
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
        public IActionResult Movie()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Movie(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _movieContext.Add(movie);
                _movieContext.SaveChanges();
                return View("Confirmation", movie);
            }
            else
            {
                return View();
            };
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
