using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Movies.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MoviesDatabaseContext _MoviesContext { get; set; }

        public HomeController(ILogger<HomeController> logger, MoviesDatabaseContext someName)
        {
            _logger = logger;
            _MoviesContext = someName;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Podcast()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddMovie()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddMovie(Movie M)
        {
            _MoviesContext.Add(M);
            _MoviesContext.SaveChanges();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
