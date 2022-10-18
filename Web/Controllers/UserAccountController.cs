using Microsoft.AspNetCore.Mvc;
using Web.Models;
using Web.Helpers;

namespace Web.Controllers
{
    public class UserAccountController : Controller
    {
        private SessionsHelpers _session;
        private ActionHelpers _actions;
        private IConfiguration _configuration;

        public UserAccountController(SessionsHelpers sessions, ActionHelpers actions, IConfiguration configuration)
        {
            _session = sessions;
            _actions = actions;
            _configuration = configuration;
        }
        public IActionResult Login(UserAccountModel userAccount)
        {
            if (_session.IsSessionActive("usuarioActivo"))
            {
                return RedirectToAction("Index", "Home");
            }            
            return View(userAccount);
        }

        public IActionResult CreateAccount()
        {
            var userAccount = new UserAccountModel();

            return View(userAccount);
        }


        public IActionResult Logout()
        {
            _session.ClearSession();
            return RedirectToAction("Login", "Useraccount");

        }

        [HttpPost]
        public async Task<IActionResult> CreateAccount(UserAccountModel userAccount)
        {
           
            var userAccountResult = await _actions.
                    SendAsyncRequets<UserAccountModel>(
                    "POST",
                   $"{_configuration["apiUrl"]}UserAccount/Create",
                    userAccount);

            if (userAccountResult.ErrorCode != null)
            {                
                return View(userAccountResult);
            }
            return RedirectToAction("Login", "Useraccount");
        }

        [HttpPost]
        public async Task<IActionResult> Login(string userName, string password)
        {
            var userLogin = new LoginModel();
            var userAccountResult = new UserAccountModel();
            userLogin.UserName = userName;
            userLogin.Password = password;
            try
            {
                userAccountResult = await _actions.
                    SendAsyncRequets<UserAccountModel>(
                        "POST",
                        $"{_configuration["apiUrl"]}UserAccount/Login",
                        userLogin
                    );


                if (userAccountResult.Message != null)
                {
                    if (userAccountResult.ErrorCode == -100)
                        userAccountResult.Message = "Error interno, Estamos en mantenimiento";

                    return View(userAccountResult);
                }

                _session.SetSession("usuarioActivo", userAccountResult.UserName);
                _session.SetSession("Token", userAccountResult.Token);
                _session.SetSession("Rol", userAccountResult.IdCategoria.ToString());
                _session.SetSession("Nombre", userAccountResult.Nombre);

                //await _loaclStorage.SetValue("UserName", userAccountResult.UserName);
                if (userAccountResult.IdCategoria == 3)
                    return RedirectToAction("Index", "Usuarios");

                return RedirectToAction("Index", "Home");
            }
            catch
            {
                userAccountResult.ErrorCode = -100;
                userAccountResult.Message = $"Error interno del sistema";

                return View(userAccountResult);
            }
                                   
        }
    }
}
