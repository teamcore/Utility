using System.Collections.Generic;

namespace Ns.Utility.Framework.Settings
{
    public interface ISettingService
    {
        /// <summary>
        /// Gets the setting by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        Setting GetSettingById(int id);

        /// <summary>
        /// Gets the setting by key.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns></returns>
        T GetSettingByKey<T>(string key, T defaultValue = default(T));

        /// <summary>
        /// Sets the setting.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="clearCache">if set to <c>true</c> [clear cache].</param>
        void SetSetting<T>(string key, T value, bool clearCache = true);

        /// <summary>
        /// Saves the setting.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="setting">The setting.</param>
        void SaveSetting<T>(T setting) where T : ISetting, new();

        /// <summary>
        /// Gets all settings.
        /// </summary>
        /// <returns></returns>
        IDictionary<string, Setting> GetAllSettings();

        /// <summary>
        /// Adds the setting.
        /// </summary>
        /// <param name="setting">The setting.</param>
        /// <param name="clearCache">if set to <c>true</c> [clear cache].</param>
        void AddSetting(Setting setting, bool clearCache = true);

        /// <summary>
        /// Updates the setting.
        /// </summary>
        /// <param name="setting">The setting.</param>
        /// <param name="clearCache">if set to <c>true</c> [clear cache].</param>
        void UpdateSetting(Setting setting, bool clearCache = true);

        /// <summary>
        /// Deletes the setting.
        /// </summary>
        /// <param name="setting">The setting.</param>
        void DeleteSetting(Setting setting);
    }
}
