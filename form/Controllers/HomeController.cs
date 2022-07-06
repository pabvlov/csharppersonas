using form.Models;
using form.Models.DAL;
using form.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace form.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        static PersonaDAL dal = new PersonaDAL();
        
        public IActionResult index()
        {
            return View(dal.get());
        }

        [HttpPost]
        public IActionResult Index(string nombre, string apellido)
        {
            Persona persona = new Persona(nombre, apellido);

            dal.agregar(persona);
            return View(dal.get());
        }
        [HttpGet]
        public IActionResult Index(int id)
        {
            dal.borrar(id);
            return View(dal.get());
        }

        [HttpPost]
        public IActionResult Modificar(int id, string nombre, string apellido)
        {
            dal.modificar(id, nombre, apellido);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Editar(int id, string nombre, string apellido)
        {
            ViewData["id"] = id;
            ViewData["nombre"] = nombre;
            ViewData["apellido"] = apellido;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
