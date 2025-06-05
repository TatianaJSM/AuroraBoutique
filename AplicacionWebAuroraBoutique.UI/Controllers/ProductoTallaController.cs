using AplicacionWebAuroraBoutique.BL.Interfaces;
using AplicacionWebAuroraBoutique.Modelo;
using Microsoft.AspNetCore.Mvc;

namespace AplicacionWebAuroraBoutique.UI.Controllers
{
    public class ProductoTallaController : Controller
    {
        private readonly IProductoTallaBL _productoTallaBL;

        public ProductoTallaController(IProductoTallaBL productoTallaBL)
        {
            _productoTallaBL = productoTallaBL;
        }

        public IActionResult Index()
        {
            var lista = _productoTallaBL.Listar();
            return View(lista);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductoTalla productoTalla)
        {
            if (ModelState.IsValid)
            {
                _productoTallaBL.Insertar(productoTalla);
                return RedirectToAction(nameof(Index));
            }
            return View(productoTalla);
        }

        public IActionResult Edit(int idProducto, int idTalla)
        {
            var productoTalla = _productoTallaBL.Listar()
                .FirstOrDefault(pt => pt.IdProducto == idProducto && pt.IdTalla == idTalla);
            if (productoTalla == null)
                return NotFound();

            return View(productoTalla);
        }

        [HttpPost]
        public IActionResult Edit(ProductoTalla productoTalla)
        {
            if (ModelState.IsValid)
            {
                _productoTallaBL.Modificar(productoTalla);
                return RedirectToAction(nameof(Index));
            }
            return View(productoTalla);
        }

        public IActionResult Delete(int idProducto, int idTalla)
        {
            var productoTalla = _productoTallaBL.Listar()
                .FirstOrDefault(pt => pt.IdProducto == idProducto && pt.IdTalla == idTalla);
            if (productoTalla == null)
                return NotFound();

            return View(productoTalla);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int idProducto, int idTalla)
        {
            _productoTallaBL.Eliminar(idProducto, idTalla);
            return RedirectToAction(nameof(Index));
        }
    }
}
