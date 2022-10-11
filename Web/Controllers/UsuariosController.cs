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
        private IConfiguration _configuration;
        public UsuariosController(SessionsHelpers sessions, ActionHelpers actions, IConfiguration configuration)
        {
            _actions = actions;
            _session = sessions;
            _configuration = configuration;
        }

        // GET: UsuariosController
        public async Task<ActionResult> Index()
        {
            try
            {
                if (!_session.IsSessionActive("usuarioActivo"))
                {
                    return RedirectToAction("Login", "UserAccount");
                }
                var listUsuariosModel = new List<UsuariosModel>();

                var token = _session.GetSession("Token");

                if(string.IsNullOrEmpty(token))
                {                    
                    _session.ClearSession();
                    var userAccountModel = new UserAccountModel
                    {
                        ErrorCode = -100,
                        Message = "Error al interno del sistema, Token no valido"
                    };
                    return RedirectToAction("Login", "UserAccount", userAccountModel);                    
                }

                listUsuariosModel = await _actions.
                        SendAsyncSecureRequets<List<UsuariosModel>>(
                            "GET",
                           $"{_configuration["apiUrl"]}Usuarios/Lista",
                            token
                        );
                return View(listUsuariosModel);
            }
            catch(Exception ex) 
            {
                // Para buscar una cadena de caracateres dentro del mensaje de la excepcion
                /*if (ex.Message.Contains("token"))
                {
                    _session.ClearSession();
                    var userAccountModel = new UserAccountModel
                    {
                        ErrorCode = -100,
                        Message = "Error al interno del sistema, Token no valido"
                    };
                    return RedirectToAction("Login", "UserAccount", userAccountModel);
                }*/

                var error = new ErrorModel
                {
                    ErrorCode = -100,
                    Message = "Error al interno del sistema, Error en Lista de usuarios"
                };
                return RedirectToAction("Index", "Home", error);
            }
            finally
            {
                //metodo de logueo de errores
            }
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
