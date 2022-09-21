using Microsoft.AspNetCore.Mvc;
using Web.Models;
using Web.Helpers;

namespace Web.Controllers
{
    public class UserAccountController : Controller
    {
        private SessionsHelpers _session;
        private ActionHelpers _actions;

        public UserAccountController(SessionsHelpers sessions, ActionHelpers actions)
        {            
            _session = sessions;
            _actions = actions;
        }
        public IActionResult Login()
        {
            if (_session.IsSessionActive("usuarioActivo"))
            {
                return RedirectToAction("Index", "Home");
            }

            var userAccount = new UserAccountModel();
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
                    "http://localhost:5002/api/UserAccount/Create",
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

            userLogin.UserName = userName;
            userLogin.Password = password;

            var userAccountResult = await _actions.
                    SendAsyncRequets<UserAccountModel>(
                    "POST", 
                    "http://localhost:5002/api/UserAccount/Login", 
                    userLogin);
                        

            if(userAccountResult.Message != null)
            {
                userLogin.Message = userAccountResult.Error;
                return View(userAccountResult);                
            }

            _session.SetSession("usuarioActivo", userAccountResult.UserName);
            _session.SetSession("Token", userAccountResult.Token);

            //await _loaclStorage.SetValue("UserName", userAccountResult.UserName);

            return RedirectToAction("Index", "Usuarios");                        
        }
    }
}
