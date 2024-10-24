using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CineProyecto.Models
{
    public class LoginViewModel
    {
        public string User { get; set; }
        public string Password { get; set; }
        public string ErrorMessage { get; set; }
    }
}