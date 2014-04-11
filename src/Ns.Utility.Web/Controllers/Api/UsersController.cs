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
    public class UsersController : ApiController
    {
        private IRepository<User> repository;
        private ICollectionModelMapper<User, UserModel> mapper;
        private ICollectionModelMapper<User, UserRegistrationModel> profileMapper;

        public UsersController(IRepository<User> repository, ICollectionModelMapper<User, UserModel> mapper, ICollectionModelMapper<User, UserRegistrationModel> profileMapper)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.profileMapper = profileMapper;
        }

        public IHttpActionResult Get()
        {
            var users = repository.GetAll();
            var modelResult = mapper.Map(users);
            return new ModelActionResult<IEnumerable<UserModel>>(modelResult, Request);
        }

        public IHttpActionResult Get(int id)
        {
            var user = repository.Get(id);
            var modelResult = mapper.Map(user);
            return new ModelActionResult<UserModel>(modelResult, Request);
        }

        [Transaction]
        public void Post(UserRegistrationModel model)
        {
            var user = profileMapper.Map(model);
            repository.Add(user);
        }

        [Transaction]
        public void Put(UserModel model)
        {
            var updatedEntity = mapper.Map(model);
            var entity = repository.FindOne(x => x.Id == model.Id);
            mapper.Update(updatedEntity, entity);
            repository.Update(entity);
        }
    }
}