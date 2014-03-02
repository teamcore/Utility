using Ns.Utility.Framework.DomainModel;
using Ns.Utility.Framework.Mvc;

namespace Ns.Utility.Web.Framework.Mapper
{
    public interface IModelMapper<TEntity, TModel>
        where TEntity : Entity
        where TModel : BaseEntityModel
    {
        TModel Map(TEntity entity);
        TEntity Map(TModel model);
        void Update(TEntity entity, TEntity modifiedEntity);
    }
}
