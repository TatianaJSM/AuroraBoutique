using AplicacionWebAuroraBoutique.BL.Interfaces;
using AplicacionWebAuroraBoutique.Modelo;
using Microsoft.AspNetCore.Mvc;

namespace AplicacionWebAuroraBoutique.UI.Controllers
{
    public class LoginAdministradorController : Controller
    {
        private readonly ILoginAdministradorBL _loginAdministradorBL;

        public LoginAdministradorController(ILoginAdministradorBL loginAdministradorBL)
        {
            _loginAdministradorBL = loginAdministradorBL;
        }

        public IActionResult Index()
        {
            var lista = _loginAdministradorBL.Listar();
            return View(lista);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(LoginAdministrador login)
        {
            if (ModelState.IsValid)
            {
                _loginAdministradorBL.Insertar(login);
                return RedirectToAction(nameof(Index));
            }
            return View(login);
        }

        public IActionResult Edit(int id)
        {
            var login = _loginAdministradorBL.Listar().FirstOrDefault(l => l.IdLoginAdmin == id);
            if (login == null)
                return NotFound();

            return View(login);
        }

        [HttpPost]
        public IActionResult Edit(LoginAdministrador login)
        {
            if (ModelState.IsValid)
            {
                _loginAdministradorBL.Modificar(login);
                return RedirectToAction(nameof(Index));
            }
            return View(login);
        }

        public IActionResult Delete(int id)
        {
            var login = _loginAdministradorBL.Listar().FirstOrDefault(l => l.IdLoginAdmin == id);
            if (login == null)
                return NotFound();

            return View(login);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _loginAdministradorBL.Eliminar(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
