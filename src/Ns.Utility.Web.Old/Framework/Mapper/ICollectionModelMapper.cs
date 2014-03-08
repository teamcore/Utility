using System.Collections.Generic;
using Ns.Utility.Framework.DomainModel;
using Ns.Utility.Framework.Mvc;

namespace Ns.Utility.Web.Framework.Mapper
{
    public interface ICollectionModelMapper<TEntity, TModel> : IModelMapper<TEntity, TModel>
        where TEntity : Entity
        where TModel : BaseEntityModel
    {
        IEnumerable<TModel> Map(IEnumerable<TEntity> entities);
        IEnumerable<TEntity> Map(IEnumerable<TModel> models);
    }
}
