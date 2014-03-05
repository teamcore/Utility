
using Autofac;
using Ns.Utility.Data;
using Ns.Utility.Framework.Caching;
using Ns.Utility.Framework.Data.Contract;
using Ns.Utility.Framework.Dependency;
using Ns.Utility.Web.Framework.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Caching;
using System.Web;
using System.Web.Http;
using System.Data.Entity;

namespace Ns.Utility.Web.Framework.Dependency
{
    public class SmartDependencyManager : DependencyManager
    {
        public override void Register(ContainerBuilder builder)
        {
            base.Register(builder);
            builder.RegisterType<SmartContext>().As<DbContext>();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            builder.RegisterType<CacheItemPolicy>().As<CacheItemPolicy>();
            builder.RegisterType<PerRequestCacheProvider>().As<ICacheProvider>();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>));
            builder.RegisterGeneric(typeof(ModelMapper<,>)).As(typeof(IModelMapper<,>));
            builder.RegisterGeneric(typeof(CollectionModelMapper<,>)).As(typeof(ICollectionModelMapper<,>));
        }
    }
}