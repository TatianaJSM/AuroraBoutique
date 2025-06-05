using AplicacionWebAuroraBoutique.BL.Interfaces;
using AplicacionWebAuroraBoutique.Modelo;
using Microsoft.AspNetCore.Mvc;

namespace AplicacionWebAuroraBoutique.UI.Controllers
{
    public class ProductoController : Controller
    {
        private readonly IProductoBL _productoBL;

        public ProductoController(IProductoBL productoBL)
        {
            _productoBL = productoBL;
        }

        // GET: Producto
        public IActionResult Index()
        {
            var lista = _productoBL.Listar();
            return View(lista);
        }

        // GET: Producto/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Producto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Producto producto)
        {
            if (ModelState.IsValid)
            {
                _productoBL.Insertar(producto);
                return RedirectToAction(nameof(Index));
            }
            return View(producto);
        }

        // GET: Producto/Edit/5
        public IActionResult Edit(int id)
        {
            var producto = _productoBL.Listar().FirstOrDefault(p => p.IdProducto == id);
            if (producto == null)
            {
                return NotFound();
            }
            return View(producto);
        }

        // POST: Producto/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Producto producto)
        {
            if (ModelState.IsValid)
            {
                _productoBL.Modificar(producto);
                return RedirectToAction(nameof(Index));
            }
            return View(producto);
        }

        // GET: Producto/Delete/5
        public IActionResult Delete(int id)
        {
            var producto = _productoBL.Listar().FirstOrDefault(p => p.IdProducto == id);
            if (producto == null)
            {
                return NotFound();
            }
            return View(producto);
        }

        // POST: Producto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _productoBL.Eliminar(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
