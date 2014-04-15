using Ns.Utility.Core.Model.Membership;
using Ns.Utility.Framework.Data.Contract;
using Ns.Utility.Web.Framework.Api;
using Ns.Utility.Web.Framework.Api.ActionResults;
using Ns.Utility.Web.Framework.Api.Filters;
using Ns.Utility.Web.Framework.Mapper;
using Ns.Utility.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Ns.Utility.Web.Controllers.Api
{
    [RoutePrefix("api/users")]
    public class UsersController : ApiControllerBase<User, UserModel>
    {
        public UsersController(IRepository<User> repository, ICollectionModelMapper<User, UserModel> mapper)
            : base(repository, mapper)
        {
        }

        [Route("exists/{domain}/{userName}")]
        [HttpGet]
        public virtual IHttpActionResult Get(string domain, string userName)
        {
            var entity = repository.FindOne(x => x.Domain == domain && x.UserName == userName);
            var model = entity != null;
            return new ModelActionResult<bool>(model, Request);
        }

        [Route("{domain}/{userName}")]
        [HttpGet]
        public virtual IHttpActionResult GetUser(string domain, string userName)
        {
            var entity = repository.FindOne(x => x.Domain == domain && x.UserName == userName);
            var model = mapper.Map(entity);
            return new ModelActionResult<UserModel>(model, Request);
        }
    }
}