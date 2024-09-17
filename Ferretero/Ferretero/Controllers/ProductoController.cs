using Ferretero.Datos;
using Ferretero.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ferretero.Controllers
{
    public class ProductoController : Controller { 
        private readonly AplicationDbContext _db;

    public ProductoController(AplicationDbContext db)
    {
        _db = db;
    }

    //clase especial llamada interface: forma más abstracta de hacer encapsulamiento
    public IActionResult Index()
    {
        IEnumerable<Producto> lista = _db.Producto;
        return View(lista);
    }
    
       
    }
}
