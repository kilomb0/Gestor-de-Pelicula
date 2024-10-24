using CineProyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CineProyecto.Controllers
{
    public class LoginController : Controller
    {
        private string user;
        private string password;

        // GET: Login
        public ActionResult InicioLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string textUs, string textPas)
        {
            user= textUs;
            password= textPas;
            if (user == "admin" && password == "123")
            {
                // Redirigir a otra vista
                return RedirectToAction("Index", "Home"); // Cambia "Index" y "Home" por la acción y el controlador a donde quieras redirigir
            }
            else
            {
                // Mostrar mensaje de error
                return RedirectToAction("InicioLogin","Login");
            }
        }
    }
}