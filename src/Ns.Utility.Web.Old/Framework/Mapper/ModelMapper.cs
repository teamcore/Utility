using Ns.Utility.Framework.DomainModel;
using Ns.Utility.Framework.Mvc;

namespace Ns.Utility.Web.Framework.Mapper
{
    public class ModelMapper<TEntity, TModel> : IModelMapper<TEntity, TModel>
        where TEntity : Entity
        where TModel : BaseEntityModel
    {

        protected virtual void CreateModelMap()
        {
            AutoMapper.Mapper.CreateMap<TEntity, TModel>();
        }

        protected virtual void CreateEntityMap()
        {
            AutoMapper.Mapper.CreateMap<TModel, TEntity>();
        }

        protected virtual void CreateEntityUpdateMap()
        {
            AutoMapper.Mapper.CreateMap<TEntity, TEntity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }

        protected virtual TModel Mapping(TEntity entity)
        {
            return AutoMapper.Mapper.Map<TEntity, TModel>(entity);
        }

        protected virtual TEntity Mapping(TModel model)
        {
            return AutoMapper.Mapper.Map<TModel, TEntity>(model);
        }

        protected virtual void Mapping(TEntity modifiedEntity, TEntity entity)
        {
            AutoMapper.Mapper.Map(modifiedEntity, entity);
        }

        public TModel Map(TEntity entity)
        {
            CreateModelMap();
            return Mapping(entity);
        }

        public TEntity Map(TModel model)
        {
            CreateEntityMap();
            return Mapping(model);
        }

        public void Update(TEntity modifiedEntity, TEntity entity)
        {
            CreateEntityUpdateMap();
            Mapping(modifiedEntity, entity);
        }
    }
}
