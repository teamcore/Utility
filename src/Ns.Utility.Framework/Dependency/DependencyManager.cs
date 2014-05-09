using System.Web;
using Ns.Utility.Framework.Fakes;
using Ns.Utility.Framework.IO;
using Ns.Utility.Framework.Logger;
using Ns.Utility.Framework.Settings;
using Ns.Utility.Framework.Tasks;
using Autofac;

namespace Ns.Utility.Framework.Dependency
{
    public class DependencyManager : IDependencyManager
    {
        public virtual void Register(ContainerBuilder builder)
        {
            builder.Register<HttpContextBase>(c => { return HttpContext.Current != null ? new HttpContextWrapper(HttpContext.Current) : (FakeHttpContext.Root() as HttpContextBase); });
            builder.RegisterType<AppDomainTypeFinder>().As<ITypeFinder>().SingleInstance();
            builder.RegisterGeneric(typeof(ConfigurationProvider<>)).As(typeof(IConfigurationProvider<>)).SingleInstance();
            builder.RegisterType<SettingService>().As<ISettingService>().SingleInstance();
            builder.RegisterType<ScheduleTaskService>().As<IScheduleTaskService>().SingleInstance();
            builder.RegisterType<WebHelper>().As<IWebHelper>().SingleInstance();
            builder.RegisterType<DefaultLogger>().As<ILogger>().SingleInstance();
            builder.RegisterType<FileSystemStorageProvider>().As<IStorageProvider>().SingleInstance();
        }
    }
}
