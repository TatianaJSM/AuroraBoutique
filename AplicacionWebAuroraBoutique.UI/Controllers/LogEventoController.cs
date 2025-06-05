using AplicacionWebAuroraBoutique.BL.Interfaces;
using AplicacionWebAuroraBoutique.Modelo;
using Microsoft.AspNetCore.Mvc;

namespace AplicacionWebAuroraBoutique.UI.Controllers
{
    public class LogEventoController : Controller
    {
        private readonly ILogEventoBL _logEventoBL;

        public LogEventoController(ILogEventoBL logEventoBL)
        {
            _logEventoBL = logEventoBL;
        }

        public IActionResult Index()
        {
            var lista = _logEventoBL.Listar();
            return View(lista);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(LogEvento logEvento)
        {
            if (ModelState.IsValid)
            {
                _logEventoBL.Insertar(logEvento);
                return RedirectToAction(nameof(Index));
            }
            return View(logEvento);
        }

        public IActionResult Edit(int id)
        {
            var logEvento = _logEventoBL.Listar().FirstOrDefault(l => l.IdLog == id);
            if (logEvento == null)
                return NotFound();

            return View(logEvento);
        }

        [HttpPost]
        public IActionResult Edit(LogEvento logEvento)
        {
            if (ModelState.IsValid)
            {
                _logEventoBL.Modificar(logEvento);
                return RedirectToAction(nameof(Index));
            }
            return View(logEvento);
        }

        public IActionResult Delete(int id)
        {
            var logEvento = _logEventoBL.Listar().FirstOrDefault(l => l.IdLog == id);
            if (logEvento == null)
                return NotFound();

            return View(logEvento);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _logEventoBL.Eliminar(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
