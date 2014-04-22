
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
using Ns.Utility.Web.Framework.Mvc;
using Ns.Utility.Web.Framework.Security;
using System.Threading;
using System.Security.Principal;
using Ns.Utility.Core.Model.Ranges;
using Ns.Utility.Framework.DomainModel.Events;
using Ns.Utility.Core.Model.Projects;

namespace Ns.Utility.Web.Framework.Dependency
{
    public class SmartDependencyManager : DependencyManager
    {
        public override void Register(ContainerBuilder builder)
        {
            base.Register(builder);
            builder.RegisterType<SmartContext>().As<DbContext>().SingleInstance();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().SingleInstance();
            builder.RegisterType<CacheItemPolicy>().As<CacheItemPolicy>().SingleInstance();
            builder.RegisterType<PerRequestCacheProvider>().As<ICacheProvider>().SingleInstance();
            builder.RegisterType<PageTitleBuilder>().As<IPageTitleBuilder>().SingleInstance();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>));
            builder.RegisterGeneric(typeof(ModelMapper<,>)).As(typeof(IModelMapper<,>));
            builder.RegisterGeneric(typeof(CollectionModelMapper<,>)).As(typeof(ICollectionModelMapper<,>));
            builder.Register(x => new UserSession(Thread.CurrentPrincipal as SmartPrincipal)).As<IUserSession>();
            builder.RegisterType<RangeCreatedHandler>().As<IHandles<RangeCreated>>().SingleInstance();
            //builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(RangeCreatedHandler))).As(typeof(IHandles<>));
        }
    }
}