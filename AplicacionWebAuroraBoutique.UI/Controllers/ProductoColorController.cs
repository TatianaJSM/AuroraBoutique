using AplicacionWebAuroraBoutique.BL.Interfaces;
using AplicacionWebAuroraBoutique.Modelo;
using Microsoft.AspNetCore.Mvc;

namespace AplicacionWebAuroraBoutique.UI.Controllers
{
    public class ProductoColorController : Controller
    {
        private readonly IProductoColorBL _productoColorBL;

        public ProductoColorController(IProductoColorBL productoColorBL)
        {
            _productoColorBL = productoColorBL;
        }

        public IActionResult Index()
        {
            var lista = _productoColorBL.Listar();
            return View(lista);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductoColor productoColor)
        {
            if (ModelState.IsValid)
            {
                _productoColorBL.Insertar(productoColor);
                return RedirectToAction(nameof(Index));
            }
            return View(productoColor);
        }

        public IActionResult Edit(int idProducto, int idColor)
        {
            var productoColor = _productoColorBL.Listar()
                .FirstOrDefault(pc => pc.IdProducto == idProducto && pc.IdColor == idColor);
            if (productoColor == null)
                return NotFound();

            return View(productoColor);
        }

        [HttpPost]
        public IActionResult Edit(ProductoColor productoColor)
        {
            if (ModelState.IsValid)
            {
                _productoColorBL.Modificar(productoColor);
                return RedirectToAction(nameof(Index));
            }
            return View(productoColor);
        }

        public IActionResult Delete(int idProducto, int idColor)
        {
            var productoColor = _productoColorBL.Listar()
                .FirstOrDefault(pc => pc.IdProducto == idProducto && pc.IdColor == idColor);
            if (productoColor == null)
                return NotFound();

            return View(productoColor);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int idProducto, int idColor)
        {
            _productoColorBL.Eliminar(idProducto, idColor);
            return RedirectToAction(nameof(Index));
        }
    }
}
