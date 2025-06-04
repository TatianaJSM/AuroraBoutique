using AplicacionWebAuroraBoutique.BL.Interfaces;
using AplicacionWebAuroraBoutique.Modelo;
using Microsoft.AspNetCore.Mvc;

namespace AplicacionWebAuroraBoutique.UI.Controllers
{
    public class DetallePedidoController : Controller
    {
        private readonly IDetallePedidoBL _detallePedidoBL;

        public DetallePedidoController(IDetallePedidoBL detallePedidoBL)
        {
            _detallePedidoBL = detallePedidoBL;
        }

        public IActionResult Index()
        {
            var lista = _detallePedidoBL.Listar();
            return View(lista);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DetallePedido detalle)
        {
            if (ModelState.IsValid)
            {
                _detallePedidoBL.Insertar(detalle);
                return RedirectToAction(nameof(Index));
            }
            return View(detalle);
        }

        public IActionResult Edit(int id)
        {
            var detalle = _detallePedidoBL.Listar().FirstOrDefault(d => d.IdDetalle == id);
            if (detalle == null)
                return NotFound();

            return View(detalle);
        }

        [HttpPost]
        public IActionResult Edit(DetallePedido detalle)
        {
            if (ModelState.IsValid)
            {
                _detallePedidoBL.Modificar(detalle);
                return RedirectToAction(nameof(Index));
            }
            return View(detalle);
        }

        public IActionResult Delete(int id)
        {
            var detalle = _detallePedidoBL.Listar().FirstOrDefault(d => d.IdDetalle == id);
            if (detalle == null)
                return NotFound();

            return View(detalle);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _detallePedidoBL.Eliminar(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
