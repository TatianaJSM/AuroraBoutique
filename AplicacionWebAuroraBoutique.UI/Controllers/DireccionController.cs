using AplicacionWebAuroraBoutique.BL.Interfaces;
using AplicacionWebAuroraBoutique.Modelo;
using Microsoft.AspNetCore.Mvc;

namespace AplicacionWebAuroraBoutique.UI.Controllers
{
    public class DireccionController : Controller
    {
        private readonly IDireccionBL _direccionBL;

        public DireccionController(IDireccionBL direccionBL)
        {
            _direccionBL = direccionBL;
        }

        public IActionResult Index()
        {
            var lista = _direccionBL.Listar();
            return View(lista);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Direccion direccion)
        {
            if (ModelState.IsValid)
            {
                _direccionBL.Insertar(direccion);
                return RedirectToAction(nameof(Index));
            }
            return View(direccion);
        }

        public IActionResult Edit(int id)
        {
            var direccion = _direccionBL.Listar().FirstOrDefault(d => d.IdDireccion == id);
            if (direccion == null)
                return NotFound();

            return View(direccion);
        }

        [HttpPost]
        public IActionResult Edit(Direccion direccion)
        {
            if (ModelState.IsValid)
            {
                _direccionBL.Modificar(direccion);
                return RedirectToAction(nameof(Index));
            }
            return View(direccion);
        }

        public IActionResult Delete(int id)
        {
            var direccion = _direccionBL.Listar().FirstOrDefault(d => d.IdDireccion == id);
            if (direccion == null)
                return NotFound();

            return View(direccion);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _direccionBL.Eliminar(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
