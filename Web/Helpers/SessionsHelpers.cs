using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Web.Helpers
{
    public class SessionsHelpers
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public SessionsHelpers(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }   

        public bool IsSessionActive(string sessionVar)
        {
            var result = false;
            if(_contextAccessor.HttpContext.Session != null) 
            {
                var session = _contextAccessor.HttpContext.Session.Get(sessionVar);
                if (session != null)
                    result = true;
            }
            

            return result;
        }

        public void SetSession(string sessionVar, string sessionValue)
        {
            _contextAccessor.HttpContext.Session.SetString(sessionVar, sessionValue);
        }

        public string GetSession(string sessionVar)
        {
            var result = "";

            result = _contextAccessor.HttpContext.Session.GetString(sessionVar);

            return result;
        }

        public void ClearSession()
        {
            _contextAccessor.HttpContext.Session.Clear();
        }

    }
}
