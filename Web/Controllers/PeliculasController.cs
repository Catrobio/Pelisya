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
        private IConfiguration _configuration;
        public PeliculasController(SessionsHelpers sessions, ActionHelpers actions, IConfiguration configuration)
        {
            _actions = actions;
            _session = sessions;
            _configuration = configuration;
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
                    $"{_configuration["apiUrl"]}Peliculas");

            foreach (var pelicula in listaPeliculas)
            {
                if (string.IsNullOrEmpty(pelicula.Portada))
                {
                    var imdbData = await _actions.SendAsyncHeadersRequets<IMDBDataMovie>(
                    "GET",
                    $"https://movie-details1.p.rapidapi.com/imdb_api/movie?id={pelicula.IdImdb}",
                    _configuration["RapidAPIKey"],
                    _configuration["RapidAPIHost"]
                    );
                    pelicula.Portada = imdbData.image;

                    /*Actualizar portada por cada pelicula*/
                    var peliculaActualizada = await _actions.
                    SendAsyncRequets<PeliculasModel>(
                    "PUT",
                    $"{_configuration["apiUrl"]}Peliculas", pelicula);
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
                $"https://movie-details1.p.rapidapi.com/imdb_api/movie?id={id}",
                _configuration["RapidAPIKey"],
                _configuration["RapidAPIHost"]
                );

            var pelicula = new PeliculasModel
            {
                ActorPrincipal = imdbData.actors[0].name,
                ActorPrincipal2 = imdbData.actors[1].name,
                ActorSecundario = imdbData.actors[2].name,
                ActorSecundario2 = imdbData.actors[3].name,
                Descripcion = string.IsNullOrEmpty(imdbData.description) ? "N/A" : imdbData.description,
                Fecha = imdbData.imdb_date,                
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
            pelicula.Categoria = "categoria";
            var peliculaGuardada = await _actions.
                SendAsyncRequets<PeliculasModel>(
                "Post",
                $"{_configuration["apiUrl"]}Peliculas", pelicula);

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
