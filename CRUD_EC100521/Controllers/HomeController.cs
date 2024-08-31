using CRUD_EC100521.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CRUD_EC100521.Controllers
{
    public class HomeController : Controller
    {
        //Hacemos referencia alCRUDContext y le llamamo contex
        private readonly CrudContext _DBContext;

        public HomeController(CrudContext context)
        {
            _DBContext = context;
        }

        public IActionResult Index()
        {
            //LISTA DE EMPLEADOS
            List<Empleado> list = _DBContext.Empleados.Include(c => c.ObjectCargo).ToList();
            return View(list);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
