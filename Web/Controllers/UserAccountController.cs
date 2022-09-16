using Microsoft.AspNetCore.Mvc;
using Web.Models;
using Web.Helpers;

namespace Web.Controllers
{
    public class UserAccountController : Controller
    {
        HttpRequestMessage _httpRequest;
        HttpClient _httpClient;
        private SessionsHelpers _session;
        private LocalStorageHelpers _loaclStorage;

        public UserAccountController(SessionsHelpers sessions, LocalStorageHelpers loaclStorage)
        {
            _httpRequest = new HttpRequestMessage();
            _httpClient = new HttpClient();
            _session = sessions;
            _loaclStorage = loaclStorage;
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
            //userAccount.IdUsuario = 0;
            _httpRequest.Method = new HttpMethod("POST");
            _httpRequest.RequestUri = new Uri("http://localhost:5002/api/UserAccount/Create");
            _httpRequest.Content = JsonContent.Create(userAccount);

            var response = await _httpClient.SendAsync(_httpRequest);

            var userAccountResult = await response.Content.ReadFromJsonAsync<UserAccountModel>();

            if (userAccountResult.ErrorCode != null)
            {                
                return View(userAccountResult);
            }
            return RedirectToAction("Login", "Useraccount");
        }

        [HttpPost]
        public async Task<IActionResult> Login(string userName, string password)
        {
            var userAccount = new LoginModel();

            userAccount.UserName = userName;
            userAccount.Password = password;            

            _httpRequest.Method = new HttpMethod("POST");
            _httpRequest.RequestUri = new Uri("http://localhost:5002/api/UserAccount/Login");
            _httpRequest.Content = JsonContent.Create(userAccount);

            var response = await _httpClient.SendAsync(_httpRequest);

            var userAccountResult = await response.Content.ReadFromJsonAsync<UserAccountModel>();

            if(userAccountResult.Message != null)
            {
                userAccount.Message = userAccountResult.Error;
                return View(userAccountResult);                
            }

            _session.SetSession("usuarioActivo", userAccountResult.UserName);
            _session.SetSession("Token", userAccountResult.Token);

            //await _loaclStorage.SetValue("UserName", userAccountResult.UserName);

            return RedirectToAction("Index", "Usuarios");                        
        }
    }
}
