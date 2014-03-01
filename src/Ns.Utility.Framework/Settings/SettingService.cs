using System;
using System.Collections.Generic;
using System.Linq;
using Ns.Utility.Framework.Caching;
using Ns.Utility.Framework.Data.Contract;
using Ns.Utility.Framework.Helper;

namespace Ns.Utility.Framework.Settings
{
    public class SettingService : ISettingService
    {
        private const string SettingsAllKey = "novimaritime.setting.all";
        private readonly IRepository<Setting> repository;
        private readonly ICacheProvider cacheProvider;
        private readonly IUnitOfWork unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="SettingService" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="cacheProvider">The cache manager.</param>
        public SettingService(IRepository<Setting> repository, IUnitOfWork unitOfWork, ICacheProvider cacheProvider)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
            this.cacheProvider = cacheProvider;
        }

        /// <summary>
        /// Gets the setting by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public Setting GetSettingById(int id)
        {
            return repository.AsQueryable().FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Gets the setting by key.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns></returns>
        public T GetSettingByKey<T>(string key, T defaultValue = default(T))
        {
            key = key.Trim().ToLowerInvariant();
            var settings = GetAllSettings();
            if (!string.IsNullOrEmpty(key) && settings.ContainsKey(key))
            {
                var setting = settings[key];
                return setting.As<T>();
            }

            return defaultValue;
        }

        /// <summary>
        /// Sets the setting.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="clearCache">if set to <c>true</c> [clear cache].</param>
        public virtual void SetSetting<T>(string key, T value, bool clearCache = true)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentNullException("key");

            key = key.Trim().ToLowerInvariant();
            var settings = GetAllSettings();

            string settingValue = CommonHelper.GetCustomTypeConverter(typeof(T)).ConvertToInvariantString(value);
            if (settings.ContainsKey(key))
            {
                var setting = settings[key];
                setting.Value = settingValue;
                UpdateSetting(setting, clearCache);
            }
            else
            {
                AddSetting(new Setting(key, settingValue), clearCache);
            }

            unitOfWork.Commit();
        }

        /// <summary>
        /// Saves the setting.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="setting">The setting.</param>
        public virtual void SaveSetting<T>(T setting) where T : ISetting, new()
        {
            EngineContext.Current.Resolve<IConfigurationProvider<T>>().Save(setting);
        }

        /// <summary>
        /// Gets all settings.
        /// </summary>
        /// <returns></returns>
        public IDictionary<string, Setting> GetAllSettings()
        {
            var key = string.Format(SettingsAllKey);
            return cacheProvider.Get(key, () =>
            {
                var query = from s in repository.GetAll()
                            orderby s.Name
                            select s;
                var settings = query.ToDictionary(s => s.Name.ToLowerInvariant());

                return settings;
            });
        }

        /// <summary>
        /// Adds the setting.
        /// </summary>
        /// <param name="setting">The setting.</param>
        /// <param name="clearCache">if set to <c>true</c> [clear cache].</param>
        public void AddSetting(Setting setting, bool clearCache = true)
        {
            if (setting == null)
                throw new ArgumentNullException("setting");

            repository.Add(setting);
        }

        /// <summary>
        /// Updates the setting.
        /// </summary>
        /// <param name="setting">The setting.</param>
        /// <param name="clearCache">if set to <c>true</c> [clear cache].</param>
        public void UpdateSetting(Setting setting, bool clearCache = true)
        {
            if (setting == null)
                throw new ArgumentNullException("setting");

            repository.Update(setting);
        }

        /// <summary>
        /// Deletes the setting.
        /// </summary>
        /// <param name="setting">The setting.</param>
        public void DeleteSetting(Setting setting)
        {
            if (setting == null)
                throw new ArgumentNullException("setting");

            repository.Delete(setting.Id);
        }
    }
}
