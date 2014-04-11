using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Reflection;
using Ns.Utility.Data.Mapping.Infrastracure;
using Ns.Utility.Framework.Data;

namespace Ns.Utility.Data
{
    public class SmartContext : DbContext
    {
        public SmartContext()
        {
            
        }

        public SmartContext(string connectionString)
            : base(connectionString)
        {
#if DEBUG
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<SmartContext>());
#else
            Database.SetInitializer(new CreateDatabaseIfNotExists<SmartContext>());
#endif
            Configuration.LazyLoadingEnabled = true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Type configType = typeof(SettingMap);
            var typesToRegister = Assembly.GetAssembly(configType).GetTypes()
            .Where(type => !String.IsNullOrEmpty(type.Namespace))
            .Where(type => type.BaseType != null && type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == typeof(EntityMapping<>));

            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }

            modelBuilder.Properties<decimal>().Configure(config => config.HasPrecision(10, 2));
            modelBuilder.Properties<string>().Configure(config => config.HasMaxLength(250));
            modelBuilder.Properties<string>().Where(p => p.Name.Equals("Name")).Configure(config => config.HasMaxLength(50));
            modelBuilder.Properties<string>().Where(p => p.Name.Equals("FirstName")).Configure(config => config.HasMaxLength(50));
            modelBuilder.Properties<string>().Where(p => p.Name.Equals("MiddleName")).Configure(config => config.HasMaxLength(50));
            modelBuilder.Properties<string>().Where(p => p.Name.Equals("LastName")).Configure(config => config.HasMaxLength(50));
            modelBuilder.Properties<string>().Where(p => p.Name.Equals("Code")).Configure(config => config.HasMaxLength(10));
            modelBuilder.Properties<string>().Where(p => p.Name.Equals("Description")).Configure(config => config.HasMaxLength(2000));
            base.OnModelCreating(modelBuilder);
        }

        public string GenerateScript()
        {
            return ((IObjectContextAdapter)this).ObjectContext.CreateDatabaseScript();
        }
    }
}