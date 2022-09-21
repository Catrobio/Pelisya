using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Models;
using Web.Helpers;
using System.Net.Http.Headers;

namespace Web.Controllers
{
    public class UsuariosController : Controller
    {
        private ActionHelpers _actions;
        private SessionsHelpers _session;
        public UsuariosController(SessionsHelpers sessions, ActionHelpers actions)
        {
            _actions = actions;
            _session = sessions;
        }

        // GET: UsuariosController
        public async Task<ActionResult> Index()
        {
            if (!_session.IsSessionActive("usuarioActivo"))
            {
                return RedirectToAction("Login", "UserAccount");           
            }


            var listUsuariosModel = new List<UsuariosModel>();

            var token = _session.GetSession("Token");
           
            listUsuariosModel = await _actions.
                    SendAsyncSecureRequets<List<UsuariosModel>>(
                    "GET",
                    "http://localhost:5002/api/Usuarios/Lista",
                    token);           

            return View(listUsuariosModel);
        }

        // GET: UsuariosController/Details/5
        public ActionResult Details()
        {
            return View();
        }

        // GET: UsuariosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuariosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuariosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UsuariosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuariosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsuariosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
