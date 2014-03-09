using Aprimo.Utility.Web.Models;
using Ns.Utility.Core.Model.Membership;
using Ns.Utility.Framework.Data.Contract;
using Ns.Utility.Web.Framework.Api;
using Ns.Utility.Web.Framework.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Aprimo.Utility.Web.Controllers
{
    public class AuthenticationController : ApiBaseController<User, LoginResponse>
    {
        public AuthenticationController(IRepository<User> repository, ICollectionModelMapper<User, LoginResponse> mapper)
            : base(repository, mapper)
        {

        }
        public LoginResponse Post(LoginModel model)
        {
            var user = repository.FindOne(x => x.UserName == model.UserName);
            if (user != null)
            {
                var isAuthenticated = user.Authenticate(model.Password);
            }
            return new LoginResponse { UserName = "nirsingh", DisplayName = "Nirajan Singh", Token = Guid.NewGuid().ToString() };
        }
    }
}
