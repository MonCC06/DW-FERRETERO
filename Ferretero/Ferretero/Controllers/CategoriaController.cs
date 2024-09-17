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

            IEnumerable<Categoria> Lista = _db.categoria;

            return View(Lista);
        }

        //get
        public IActionResult Crear()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear( Categoria categoria)
        {
           if (ModelState.IsValid) {
                _db.categoria.Add(categoria);
                _db.SaveChanges();
                return RedirectToAction(nameof  (Index));



                    }

           return View(categoria);
        }



        //editar

        public IActionResult Editar(int? id)
        {

            if(id == null || id==0) {
                return NotFound();
            }

            var obj = _db.categoria.Find(id);
            

            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }


        //POST
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



        //eliminar get

        public IActionResult Eliminar(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.categoria.Find(id);


            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }


        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Eliminar(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                return NotFound();
            }


            _db.Producto.Remove(categoria);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
            
        }










    }
}
