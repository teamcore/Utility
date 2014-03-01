namespace Aprimo.Utility.Framework.Settings
{
    public interface IConfigurationProvider<T> where T : ISetting, new ()
    {
        /// <summary>
        /// Gets the settings.
        /// </summary>
        T Settings { get; }

        /// <summary>
        /// Saves the specified settings.
        /// </summary>
        /// <param name="settings">The settings.</param>
        void Save(T settings);
    }
}
