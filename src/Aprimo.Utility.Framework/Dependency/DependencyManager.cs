using System.Web;
using Aprimo.Utility.Framework.Events;
using Aprimo.Utility.Framework.Fakes;
using Aprimo.Utility.Framework.IO;
using Aprimo.Utility.Framework.Logger;
using Aprimo.Utility.Framework.Settings;
using Aprimo.Utility.Framework.Tasks;
using Autofac;

namespace Aprimo.Utility.Framework.Dependency
{
    public class DependencyManager : IDependencyManager
    {
        public virtual void Register(ContainerBuilder builder)
        {
            builder.Register<HttpContextBase>(c => { return HttpContext.Current != null ? new HttpContextWrapper(HttpContext.Current) : (FakeHttpContext.Root() as HttpContextBase); });
            builder.RegisterType<AppDomainTypeFinder>().As<ITypeFinder>();
            builder.RegisterType(typeof(ConfigurationProvider<>)).As(typeof(IConfigurationProvider<>));
            builder.RegisterType<SettingService>().As<ISettingService>();
            builder.RegisterType<ScheduleTaskService>().As<IScheduleTaskService>();
            builder.RegisterType<WebHelper>().As<IWebHelper>();
            builder.RegisterType<DefaultLogger>().As<ILogger>();
        }
    }
}
