using Ferretero.Datos;
using Ferretero.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ferretero.Controllers
{
    public class ProductoController1 : Controller
    {

        private readonly AplicationDbContext _db;


        public ProductoController1(AplicationDbContext db)
        {
            _db = db;
        }






        public IActionResult Index()
        {

            IEnumerable<Producto> Lista = _db.Producto;

            return View(Lista);
        }

        //get
        public IActionResult Crear()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Producto producto)
        {
            if (ModelState.IsValid)
            {
                _db.Producto.Add(producto);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));



            }

            return View(producto);
        }



        //editar

        public IActionResult Editar(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Producto.Find(id);


            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }


        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Producto producto)
        {
            if (ModelState.IsValid)
            {
                _db.Producto.Update(producto);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(producto);
        }



        //eliminar get

        public IActionResult Eliminar(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Producto.Find(id);


            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }


        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Eliminar(  Producto producto)
        {
            if (ModelState.IsValid)
            {
                return NotFound();
            }


            _db.Producto.Remove(producto);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));

        }


    }
}
