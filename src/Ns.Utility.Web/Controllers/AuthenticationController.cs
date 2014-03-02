using Aprimo.Utility.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Aprimo.Utility.Web.Controllers
{
    public class AuthenticationController : ApiController
    {
        public LoginResponse Post(LoginModel model)
        {
            return new LoginResponse { Name = "Nirajan Singh", Token = Guid.NewGuid().ToString() };
        }
    }
}
