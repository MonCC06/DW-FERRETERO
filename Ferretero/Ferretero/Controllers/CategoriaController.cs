using Microsoft.AspNetCore.Mvc;
using Ferretero.Datos;
using Ferretero.Models;

namespace Ferretero.Controllers
{
    public class CategoriaController : Controller
    {

        private readonly AplicationDbContext _db;

        public CategoriaController(AplicationDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            IEnumerable<Categoria> lista = _db.categoria;

            return View(lista);
        }

        //Get

        public IActionResult Crear()
        {
            return View();
        }

        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Categoria categoria)
        {
            if(ModelState.IsValid)
            {
                _db.categoria.Add(categoria);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));

            }
            return View(categoria);
        }

        public IActionResult Editar(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();

            }

            var obj = _db.categoria.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _db.categoria.Update(categoria);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));

            }
            return View(categoria);
        }

        public IActionResult Eliminar(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();

            }

            var obj = _db.categoria.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Eliminar(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                return NotFound();
            }
            _db.categoria.Remove(categoria);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
