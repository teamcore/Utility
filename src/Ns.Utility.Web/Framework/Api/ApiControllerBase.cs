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

namespace Ns.Utility.Web.Framework.Api
{
    public abstract class ApiControllerBase<TEntity, TModel> : ApiController
        where TEntity : Entity
        where TModel : BaseEntityModel
    {
        protected readonly IRepository<TEntity> repository;
        protected readonly ICollectionModelMapper<TEntity, TModel> mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiControllerBase{TEntity, TModel}" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="mapper">The mapper.</param>
        protected ApiControllerBase(IRepository<TEntity> repository, ICollectionModelMapper<TEntity, TModel> mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public virtual IHttpActionResult Get()
        {
            var entities = repository.GetAll().OrderBy(x => x.Id);
            var models = mapper.Map(entities).AsQueryable();
            return new ModelActionResult<IEnumerable<TModel>>(models, Request);
        }

        public virtual KendoResult<TModel> Get(int take, int skip, int page, int pageSize)
        {
            var count = repository.GetAll().Count();
            var entities = repository.GetAll().OrderByDescending(x => x.Id).Skip(skip).Take(take);
            return new KendoResult<TModel>(mapper.Map(entities), count);
        }

        public virtual IHttpActionResult Get(int id)
        {
            var entity = repository.Get(id);
            var model = mapper.Map(entity);
            return new ModelActionResult<TModel>(model, Request);
        }

        [Transaction]
        public virtual void Post(TModel model)
        {
            var entity = mapper.Map(model);
            repository.Add(entity);
            //var modelResult = mapper.Map(entity);
            //return new ModelActionResult<TModel>(modelResult, Request);
        }

        [Transaction]
        public virtual void Put(TModel model)
        {
            var updatedEntity = mapper.Map(model);
            var entity = repository.FindOne(x => x.Id == model.Id);
            mapper.Update(updatedEntity, entity);
            repository.Update(entity);
            //var modelResult = mapper.Map(entity);
            //return new ModelActionResult<TModel>(modelResult, Request);
        }

        [Transaction]
        public virtual void Delete(int id)
        {
            repository.Delete(id);
            //return new TextActionResult("Deleted successfully.", Request);
        }
    }
}
