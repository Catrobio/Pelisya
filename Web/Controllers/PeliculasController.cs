using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Models;
using Web.Helpers;

namespace Web.Controllers
{
    public class PeliculasController : Controller
    {
        // GET: PeliculasController
        private ActionHelpers _actions;
        private SessionsHelpers _session;
        public PeliculasController(SessionsHelpers sessions, ActionHelpers actions)
        {
            _actions = actions;
            _session = sessions;
        }
        public async Task<ActionResult> Index()
        {
            if (!_session.IsSessionActive("usuarioActivo"))
            {
                return RedirectToAction("Login", "UserAccount");
            }

            var listaPeliculas = new List<PeliculasModel>();
            listaPeliculas = await _actions.
                    SendAsyncRequets<List<PeliculasModel>>(
                    "GET",
                    "http://localhost:5002/api/Peliculas");

            foreach (var peliculas in listaPeliculas)
            {
                if(string.IsNullOrEmpty(peliculas.Portada))
                {
                    var imdbData = await _actions.SendAsyncHeadersRequets<IMDBDataMovie>(
                    "GET",
                    $"https://movie-details1.p.rapidapi.com/imdb_api/movie?id={peliculas.IdImdb}");
                    peliculas.Portada = imdbData.image;
                }
            }

            return View(listaPeliculas);            
        }

        // GET: PeliculasController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PeliculasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PeliculasController/Create
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

        // GET: PeliculasController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PeliculasController/Edit/5
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

        // GET: PeliculasController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PeliculasController/Delete/5
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
