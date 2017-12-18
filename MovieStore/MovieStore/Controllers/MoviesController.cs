using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieStore.Models;

namespace MovieStore.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index()
        {
            var movies = intMovies();
            return View(movies);
        }

        public ActionResult Details(int MovieID) {


            var ml = intMovies().Where(x => x.id == MovieID).FirstOrDefault();

            if (ml is null) { ViewBag.error = "this movie can not be found"; }

            return View(ml);
        }


       private List<Movie> intMovies()
        {
            var movies = new List<Movie>{
                new Movie { id =1 , Name = "Titanic", RelaseYear = 2009 },
                new Movie { id = 2, Name = "Finding nemo", RelaseYear = 2010 }
            };

            return movies;
        }
    }
}