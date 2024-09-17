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

        //clase especial llamada interface: forma más abstracta de hacer encapsulamiento
        public IActionResult Index()
        {
            IEnumerable<Categoria> lista = _db.categoria;
            return View(lista);
        }

        //get
        public IActionResult Crear()
        {
            return View();
        }

        //post: envia información
        [HttpPost]
        [ValidateAntiForgeryToken] //datos encriptados
        public IActionResult Crear(Categoria categoria) //recibe un obj4eto de tipo categoria
        {
            if (ModelState.IsValid)
            {
                _db.categoria.Add(categoria); //insertar en base de datos
                _db.SaveChanges(); //se guardan datos
                return RedirectToAction(nameof(Index)); //redireccionar al index
            }
            return View(categoria);
        }

        //get
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

        //post: envia información
        [HttpPost]
        [ValidateAntiForgeryToken] //datos encriptados
        public IActionResult Editar (Categoria categoria) { 
            if (ModelState.IsValid)
            {
                _db.categoria.Update(categoria); //actualizar en base de datos
                _db.SaveChanges(); //se guardan datos
                return RedirectToAction(nameof(Index)); //redireccionar al index
            }
            return View(categoria);
        }
        //get
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
        //post: envia información
        [HttpPost]
        [ValidateAntiForgeryToken] //datos encriptados
        public IActionResult Eliminar(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                return NotFound();
            }
            _db.categoria.Remove(categoria); //actualizar en base de datos
            _db.SaveChanges(); //se guardan datos
            return RedirectToAction(nameof(Index)); //redireccionar al index
            
        }
    }
}
