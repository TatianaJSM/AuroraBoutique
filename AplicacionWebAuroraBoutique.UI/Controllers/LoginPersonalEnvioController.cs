using AplicacionWebAuroraBoutique.BL.Interfaces;
using AplicacionWebAuroraBoutique.Modelo;
using Microsoft.AspNetCore.Mvc;

namespace AplicacionWebAuroraBoutique.UI.Controllers
{
    public class LoginPersonalEnvioController : Controller
    {
        private readonly ILoginPersonalEnvioBL _loginPersonalEnvioBL;

        public LoginPersonalEnvioController(ILoginPersonalEnvioBL loginPersonalEnvioBL)
        {
            _loginPersonalEnvioBL = loginPersonalEnvioBL;
        }

        public IActionResult Index()
        {
            var lista = _loginPersonalEnvioBL.Listar();
            return View(lista);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(LoginPersonalEnvio login)
        {
            if (ModelState.IsValid)
            {
                _loginPersonalEnvioBL.Insertar(login);
                return RedirectToAction(nameof(Index));
            }
            return View(login);
        }

        public IActionResult Edit(int id)
        {
            var login = _loginPersonalEnvioBL.Listar().FirstOrDefault(l => l.IdLoginPersonal == id);
            if (login == null)
                return NotFound();

            return View(login);
        }

        [HttpPost]
        public IActionResult Edit(LoginPersonalEnvio login)
        {
            if (ModelState.IsValid)
            {
                _loginPersonalEnvioBL.Modificar(login);
                return RedirectToAction(nameof(Index));
            }
            return View(login);
        }

        public IActionResult Delete(int id)
        {
            var login = _loginPersonalEnvioBL.Listar().FirstOrDefault(l => l.IdLoginPersonal == id);
            if (login == null)
                return NotFound();

            return View(login);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _loginPersonalEnvioBL.Eliminar(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
