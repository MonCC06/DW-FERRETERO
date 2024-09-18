using Ferretero.Datos;
using Ferretero.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ferretero.Controllers
{
    public class ProductoController : Controller
    {
        private readonly AplicationDbContext _db;

        public ProductoController(AplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Producto> lista = _db.producto;

            return View(lista);
        }
    }
}
