using Ferretero.Datos;
using Ferretero.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ferretero.Controllers
{
    public class TipoAplicacionController : Controller
    {
        private readonly AplicationDbContext _db;

        public TipoAplicacionController(AplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<TipoAplicacion> lista = _db.tipoAplicacion;

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
        public IActionResult Crear(TipoAplicacion tipoAplicacion)
        {
            if (ModelState.IsValid)
            {
                _db.tipoAplicacion.Add(tipoAplicacion);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));

            }
            return View(tipoAplicacion);
        }

        //get
        public IActionResult Editar(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();

            }

            var obj = _db.tipoAplicacion.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(TipoAplicacion tipoAplicacion)
        {
            if (ModelState.IsValid)
            {
                _db.tipoAplicacion.Update(tipoAplicacion);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));

            }
            return View(tipoAplicacion);
        }

        //get
        public IActionResult Eliminar(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();

            }

            var obj = _db.tipoAplicacion.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Eliminar(TipoAplicacion tipoAplicacion)
        {
            if (ModelState.IsValid)
            {
                return NotFound();
            }
            _db.tipoAplicacion.Remove(tipoAplicacion);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
