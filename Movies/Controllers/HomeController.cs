using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public IActionResult MovieList()
        {
            var MovieList = _MoviesContext.MovieSet.Include(x => x.Category).ToList();
            return View(MovieList);
        }

        [HttpGet]
        public IActionResult AddMovie()
        {
            ViewBag.categories = _MoviesContext.Categories.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult AddMovie(Movie M)
        {
            if (ModelState.IsValid)
            {
                _MoviesContext.Add(M);
                _MoviesContext.SaveChanges();
                return View();
            }
            else
            {
                ViewBag.categories = _MoviesContext.Categories.ToList();
                return View(M);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult Edit(int MovieId)
        {
            ViewBag.categories = _MoviesContext.Categories.ToList();

            var MovieList = _MoviesContext.MovieSet.Single(x => x.MovieId == MovieId);

            return View("AddMovie", MovieList);
        }

        [HttpPost]
        public IActionResult Edit(Movie x)
        {
            _MoviesContext.Update(x);
            _MoviesContext.SaveChanges();

            return RedirectToAction("MovieList");
        }

        [HttpGet]
        public IActionResult Delete(int MovieId)
        {
            var MovieList = _MoviesContext.MovieSet.Single(x => x.MovieId == MovieId);

            return View(MovieList);
        }

        [HttpPost]
        public IActionResult Delete(Movie x)
        {
            _MoviesContext.MovieSet.Remove(x);
            _MoviesContext.SaveChanges();

            return RedirectToAction("MovieList");
        }

        private IActionResult View(Func<IActionResult> movieList)
        {
            throw new NotImplementedException();
        }
    }
}
