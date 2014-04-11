using System.Collections.Generic;
using System.Linq;
using Ns.Utility.Framework.DomainModel;
using Ns.Utility.Framework.Mvc;

namespace Ns.Utility.Web.Framework.Mapper
{
    public class CollectionModelMapper<TEntity, TModel> : ModelMapper<TEntity, TModel>, ICollectionModelMapper<TEntity, TModel>
        where TEntity : Entity
        where TModel : BaseEntityModel
    {
        public IEnumerable<TModel> Map(IEnumerable<TEntity> entities)
        {
            CreateModelMap();
            return entities.Select(Map);
        }

        public IEnumerable<TEntity> Map(IEnumerable<TModel> models)
        {
            CreateEntityMap();
            return models.Select(Map);
        }
    }
}
