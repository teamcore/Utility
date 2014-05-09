using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.Design.PluralizationServices;
using Ns.Utility.Framework.DomainModel;
using System.Globalization;

namespace Ns.Utility.Framework.Data
{
    public class EntityMapping<T> : EntityTypeConfiguration<T> where T : Entity
    {
        private readonly PluralizationService pluralizer = PluralizationService.CreateService(CultureInfo.GetCultureInfo("en"));
        public EntityMapping()
        {
            ToTable(pluralizer.Pluralize(typeof(T).Name));
            HasKey(x => x.Id);
            Property(x => x.RowVersion).IsConcurrencyToken(true).IsRowVersion();
        }
    }
}