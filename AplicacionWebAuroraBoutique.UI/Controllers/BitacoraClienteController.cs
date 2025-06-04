using AplicacionWebAuroraBoutique.BL.Interfaces;
using AplicacionWebAuroraBoutique.Modelo;
using Microsoft.AspNetCore.Mvc;

namespace AplicacionWebAuroraBoutique.UI.Controllers
{
    public class BitacoraClienteController : Controller
    {
        private readonly IBitacoraClienteBL _bitacoraClienteBL;

        public BitacoraClienteController(IBitacoraClienteBL bitacoraClienteBL)
        {
            _bitacoraClienteBL = bitacoraClienteBL;
        }

        public IActionResult Index()
        {
            var lista = _bitacoraClienteBL.Listar();
            return View(lista);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(BitacoraCliente bitacora)
        {
            if (ModelState.IsValid)
            {
                _bitacoraClienteBL.Insertar(bitacora);
                return RedirectToAction(nameof(Index));
            }
            return View(bitacora);
        }

        public IActionResult Edit(int id)
        {
            var bitacora = _bitacoraClienteBL.Listar().FirstOrDefault(b => b.IdLog == id);
            if (bitacora == null)
                return NotFound();

            return View(bitacora);
        }

        [HttpPost]
        public IActionResult Edit(BitacoraCliente bitacora)
        {
            if (ModelState.IsValid)
            {
                _bitacoraClienteBL.Modificar(bitacora);
                return RedirectToAction(nameof(Index));
            }
            return View(bitacora);
        }

        public IActionResult Delete(int id)
        {
            var bitacora = _bitacoraClienteBL.Listar().FirstOrDefault(b => b.IdLog == id);
            if (bitacora == null)
                return NotFound();

            return View(bitacora);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _bitacoraClienteBL.Eliminar(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
