using System.Linq;
using System.Web.Http;
using Ns.Utility.Framework.Data.Contract;
using Ns.Utility.Framework.DomainModel;
using Ns.Utility.Framework.Mvc;
using Ns.Utility.Web.Framework.Api.Filters;
using Ns.Utility.Web.Framework.Mapper;
using System.Net.Http;
using System.Net;
using Ns.Utility.Web.Framework.Api.ActionResults;
using System.Collections.Generic;
using Ns.Utility.Web.Framework.Kendo;
using Ns.Utility.Web.Framework.Security;
using System.Security.Claims;
using Ns.Utility.Framework.Settings;
using Ns.Utility.Core.Model.Membership;
using Ns.Utility.Framework;

namespace Ns.Utility.Web.Framework.Api
{
    public abstract class ApiControllerBase<TEntity, TModel> : ApiController
        where TEntity : Entity
        where TModel : BaseEntityModel
    {
        protected readonly IRepository<TEntity> repository;
        protected readonly ICollectionModelMapper<TEntity, TModel> mapper;
        private readonly IConfigurationProvider<ApplicationSettings> provider;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiControllerBase{TEntity, TModel}" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="mapper">The mapper.</param>
        protected ApiControllerBase(IRepository<TEntity> repository, ICollectionModelMapper<TEntity, TModel> mapper, IConfigurationProvider<ApplicationSettings> provider)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.provider = provider;
        }

        public ApiControllerBase(IRepository<TEntity> repository, ICollectionModelMapper<TEntity, TModel> mapper)
            : this(repository, mapper, EngineContext.Current.Resolve<IConfigurationProvider<ApplicationSettings>>())
        {
        }

        public IUserSession UserSession { get { return new UserSession(User as ClaimsPrincipal); } }

        [Route("{id:int}")]
        public virtual IHttpActionResult Get(int id)
        {
            var entity = repository.Get(id);
            if(entity == null)
            {
                return NotFound();
            }
            
            var model = mapper.Map(entity);
            return Ok<TModel>(model);
        }

        [Route("")]
        public virtual IEnumerable<TModel> Get()
        {
            var entities = repository.GetAll().OrderByDescending(x => x.Id);
            var models = mapper.Map(entities);
            return models;
        }

        [Route("{take:int}/{skip:int}/{page:int}/{pageSize:int}")]
        public virtual KendoResult<TModel> Get(int take, int skip, int page, int pageSize)
        {
            var count = repository.AsQueryable().Where(x => x.IsDeleted == false).Count();
            var entities = repository.AsQueryable().Where(x => x.IsDeleted == false).OrderByDescending(x => x.Id).Skip(skip).Take(take);
            return new KendoResult<TModel>(mapper.Map(entities), count);
        }

        [Transaction]
        public virtual void Post(TModel model)
        {
            var entity = mapper.Map(model);
            repository.Add(entity);
        }

        [Transaction]
        public virtual void Put(TModel model)
        {
            var updatedEntity = mapper.Map(model);
            var entity = repository.FindOne(x => x.Id == model.Id);
            mapper.Update(updatedEntity, entity);
            repository.Update(entity);
        }

        [Transaction]
        public virtual void Delete(int id)
        {
            if(provider.Settings.SoftDeleteEnabled)
            {
                var entity = repository.FindOne(x => x.Id == id);
                entity.IsDeleted = true;
                repository.Update(entity);
            }
            else
            {
                repository.Delete(id);
            }
        }
    }
}
