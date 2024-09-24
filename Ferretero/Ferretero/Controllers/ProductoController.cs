using Ferretero.Datos;
using Ferretero.Models;
using Ferretero.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;

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

        public IActionResult Upsert(int? Id)
        {

            //IEnumerable<SelectListItem> categoriaDropDown = _db.categoria.Select(c => new SelectListItem
            //{
            //    Text = c.NombreCategoria,
            //    Value = c.Id.ToString()
            //});

            //ViewBag.categoriaDropDown = categoriaDropDown;

            //IEnumerable<SelectListItem> tipoAplicacionListaDropDown = _db.tipoAplicacion.Select(t => new SelectListItem
            //{
            //    Text = t.Nombre,
            //    Value = t.Id.ToString()
            //});

            //ViewBag.tipoAplicacionListaDropDown = tipoAplicacionListaDropDown;

            //Producto producto = new Producto();

            ProductoVM productoVM = new ProductoVM()
            {
                Producto = new Producto(),
                CategoriaLista = _db.categoria.Select(c => new SelectListItem
                {
                    Text = c.NombreCategoria,
                    Value = c.Id.ToString(),
                }),
                TipoAplicacionLista = _db.tipoAplicacion.Select(c => new SelectListItem
                {
                    Text = c.Nombre,
                    Value = c.Id.ToString(),
                })


            };



            if (Id == null)
            {
                return View(productoVM);
            }
            else
            {
                productoVM.Producto = _db.producto.Find(Id);
                if (productoVM == null)
                {
                    return NotFound();
                }
                return View(productoVM);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(ProductoVM)
        {

        }
    }
}
