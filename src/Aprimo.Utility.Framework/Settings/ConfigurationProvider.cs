using System;
using System.Linq;
using Aprimo.Utility.Framework.Helper;

namespace Aprimo.Utility.Framework.Settings
{
    public class ConfigurationProvider<TSetting> : IConfigurationProvider<TSetting> where TSetting : ISetting, new()
    {
        private readonly ISettingService settingService;

        public ConfigurationProvider(ISettingService settingService)
        {
            this.settingService = settingService;
            BuildConfiguration();
        }

        /// <summary>
        /// Gets or sets the setting.
        /// </summary>
        /// <value>
        /// The setting.
        /// </value>
        public TSetting Settings { get; protected set; }

        /// <summary>
        /// Builds the configuration.
        /// </summary>
        protected void BuildConfiguration()
        {
            Settings = Activator.CreateInstance<TSetting>();

            // get properties we can write to
            var properties = from prop in typeof(TSetting).GetProperties()
                             where prop.CanWrite && prop.CanRead
                             let setting = settingService.GetSettingByKey<string>(typeof(TSetting).Name + "." + prop.Name)
                             where setting != null
                             where CommonHelper.GetCustomTypeConverter(prop.PropertyType).CanConvertFrom(typeof(string))
                             where CommonHelper.GetCustomTypeConverter(prop.PropertyType).IsValid(setting)
                             let value = CommonHelper.GetCustomTypeConverter(prop.PropertyType).ConvertFromInvariantString(setting)
                             select new { prop, value };

            // assign properties
            properties.ToList().ForEach(p => p.prop.SetValue(Settings, p.value, null));
        }

        /// <summary>
        /// Saves the specified setting.
        /// </summary>
        /// <param name="setting">The setting.</param>
        public void Save(TSetting setting)
        {
            var properties = from prop in typeof(TSetting).GetProperties()
                             where prop.CanWrite && prop.CanRead
                             where CommonHelper.GetCustomTypeConverter(prop.PropertyType).CanConvertFrom(typeof(string))
                             select prop;

            /* We do not clear cache after each setting update.
             * This behavior can increase performance because cached settings will not be cleared 
             * and loaded from database after each update */
            foreach (var prop in properties)
            {
                string key = typeof(TSetting).Name + "." + prop.Name;
                //Duck typing is not supported in C#. That's why we're using dynamic type
                dynamic value = prop.GetValue(setting, null);
                settingService.SetSetting(key, value ?? "", false);
            }

            Settings = setting;
        }
    }
}
