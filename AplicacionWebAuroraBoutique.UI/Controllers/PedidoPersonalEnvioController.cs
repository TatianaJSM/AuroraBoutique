using AplicacionWebAuroraBoutique.BL.Interfaces;
using AplicacionWebAuroraBoutique.Modelo;
using Microsoft.AspNetCore.Mvc;

namespace AplicacionWebAuroraBoutique.UI.Controllers
{
    public class PedidoPersonalEnvioController : Controller
    {
        private readonly IPedidoPersonalEnvioBL _pedidoPersonalEnvioBL;

        public PedidoPersonalEnvioController(IPedidoPersonalEnvioBL pedidoPersonalEnvioBL)
        {
            _pedidoPersonalEnvioBL = pedidoPersonalEnvioBL;
        }

        public IActionResult Index()
        {
            var lista = _pedidoPersonalEnvioBL.Listar();
            return View(lista);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PedidoPersonalEnvio pedidoPersonalEnvio)
        {
            if (ModelState.IsValid)
            {
                _pedidoPersonalEnvioBL.Insertar(pedidoPersonalEnvio);
                return RedirectToAction(nameof(Index));
            }
            return View(pedidoPersonalEnvio);
        }

        public IActionResult Edit(int id)
        {
            var pedidoPersonalEnvio = _pedidoPersonalEnvioBL.Listar().FirstOrDefault(p => p.IdPedidoEnvio == id);
            if (pedidoPersonalEnvio == null)
                return NotFound();

            return View(pedidoPersonalEnvio);
        }

        [HttpPost]
        public IActionResult Edit(PedidoPersonalEnvio pedidoPersonalEnvio)
        {
            if (ModelState.IsValid)
            {
                _pedidoPersonalEnvioBL.Modificar(pedidoPersonalEnvio);
                return RedirectToAction(nameof(Index));
            }
            return View(pedidoPersonalEnvio);
        }

        public IActionResult Delete(int id)
        {
            var pedidoPersonalEnvio = _pedidoPersonalEnvioBL.Listar().FirstOrDefault(p => p.IdPedidoEnvio == id);
            if (pedidoPersonalEnvio == null)
                return NotFound();

            return View(pedidoPersonalEnvio);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _pedidoPersonalEnvioBL.Eliminar(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
