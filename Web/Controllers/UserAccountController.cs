using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class UserAccountController : Controller
    {
        HttpRequestMessage _httpRequest;
        HttpClient _httpClient;

        public UserAccountController()
        {
            _httpRequest = new HttpRequestMessage();
            _httpClient = new HttpClient();
        }
        public IActionResult Login()
        {
            var userAccount = new UserAccountModel();
            return View(userAccount);
        }

        [HttpPost]
        public async Task<IActionResult> Login(string userName, string password)
        {
            var userAccount = new UserAccountModel();

            userAccount.UserName = userName;
            userAccount.Password = password;    

            _httpRequest.Method = new HttpMethod("POST");
            _httpRequest.RequestUri = new Uri("http://localhost:5002/api/UserAccount/Login");
            _httpRequest.Content = JsonContent.Create(userAccount);

            var response = await _httpClient.SendAsync(_httpRequest);

            var userAccountResult = await response.Content.ReadFromJsonAsync<UserAccountModel>();

            if(userAccountResult.Error != null)
            {
                userAccount.Error = userAccountResult.Error;
                return View(userAccount);                
            }
            else 
            {
                return RedirectToAction("Index", "Usuarios");
            }

            
        }
    }
}
