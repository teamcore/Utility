using System.Linq;
using System.Web.Http;
using Ns.Utility.Framework.Data.Contract;
using Ns.Utility.Framework.DomainModel;
using Ns.Utility.Framework.Mvc;
using Ns.Utility.Web.Framework.Api.Filters;
using Ns.Utility.Web.Framework.Mapper;

namespace Ns.Utility.Web.Framework.Api
{
    public abstract class ApiBaseController<TEntity, TModel> : ApiController where TEntity : Entity where TModel : BaseEntityModel
    {
        protected readonly IRepository<TEntity> repository;
        protected readonly ICollectionModelMapper<TEntity, TModel> mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiBaseController{TEntity, TModel}" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="mapper">The mapper.</param>
        protected ApiBaseController(IRepository<TEntity> repository, ICollectionModelMapper<TEntity, TModel> mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public virtual IQueryable<TModel> Get()
        {
            var entities = repository.GetAll().OrderBy(x => x.Id);
            return mapper.Map(entities).AsQueryable();
        }


        public virtual TModel Get(int id)
        {
            var entity = repository.Get(id);
            return mapper.Map(entity);
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
            repository.Delete(id);
        }
    }
}
