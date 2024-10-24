using CineProyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CineProyecto.Controllers
{
    public class HomeController : Controller
    {

        private CineDBEntities1 db = new CineDBEntities1();
        public ActionResult Index()
        {
            var pelicula = db.Pelicula;
            return View(pelicula.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}