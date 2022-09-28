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

            foreach (var pelicula in listaPeliculas)
            {
                if (string.IsNullOrEmpty(pelicula.Portada))
                {
                    var imdbData = await _actions.SendAsyncHeadersRequets<IMDBDataMovie>(
                    "GET",
                    $"https://movie-details1.p.rapidapi.com/imdb_api/movie?id={pelicula.IdImdb}");
                    pelicula.Portada = imdbData.image;

                    /*Actualizar portada por cada pelicula*/
                    var peliculaActualizada = await _actions.
                    SendAsyncRequets<PeliculasModel>(
                    "PUT",
                    "http://localhost:5002/api/Peliculas", pelicula);
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
            var pelicula = new PeliculasModel();
            return View(pelicula);
        }

        [HttpGet]
        public async Task<ActionResult> GetImdbInfo(string id)
        {
            var imdbData = await _actions.SendAsyncHeadersRequets<IMDBDataMovie>(
                "GET",
                $"https://movie-details1.p.rapidapi.com/imdb_api/movie?id={id}");

            var pelicula = new PeliculasModel
            {
                ActorPrincipal = imdbData.actors[0].name,
                ActorPrincipal2 = imdbData.actors[1].name,
                ActorSecundario = imdbData.actors[2].name,
                ActorSecundario2 = imdbData.actors[3].name,
                Descripcion = imdbData.description,
                Fecha = imdbData.imdb_date,
                IdCategoriaPeliculas = 1,
                IdImdb = imdbData.id,
                Nombre = imdbData.title,
                Portada = imdbData.image
            };
            

            return View("Create", pelicula);
        }


        // POST: PeliculasController/Create
        [HttpPost]        
        public async Task<ActionResult> Create(PeliculasModel pelicula)
        {            
            var peliculaGuardada = await _actions.
                SendAsyncRequets<PeliculasModel>(
                "Post",
                "http://localhost:5002/api/Peliculas", pelicula);

                return RedirectToAction("Index");            
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
