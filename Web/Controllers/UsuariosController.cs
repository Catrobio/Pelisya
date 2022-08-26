using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Models;
using Web.Helpers;

namespace Web.Controllers
{
    public class UsuariosController : Controller
    {
        HttpRequestMessage _httpRequest;
        HttpClient _httpClient;
        private SessionsHelpers _session;
        public UsuariosController(SessionsHelpers sessions)
        {
            _httpRequest = new HttpRequestMessage();
            _httpClient = new HttpClient();
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
            _httpRequest.Method = new HttpMethod("GET");
            _httpRequest.RequestUri = new Uri("http://localhost:5002/api/Usuarios/Lista");
            var response = _httpClient.Send(_httpRequest);
            listUsuariosModel = await response.Content.ReadFromJsonAsync<List<UsuariosModel>>();

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
