using System;
using System.Configuration;
using System.Xml;
namespace Ns.Utility.Framework.Settings
{
    /// <summary>
    /// Represents a Config
    /// </summary>
    public class Config : IConfigurationSectionHandler
    {
        #region Methods

        /// <summary>
        /// Creates a configuration section handler.
        /// </summary>
        /// <param name="parent">Parent object.</param>
        /// <param name="configContext">Configuration context object.</param>
        /// <param name="section">Section XML node.</param>
        /// <returns>
        /// The created section handler object.
        /// </returns>
        public object Create(object parent, object configContext, XmlNode section)
        {
            Config config = new Config();

            var dynamicDiscoveryNode = section.SelectSingleNode("DynamicDiscovery");
            if (dynamicDiscoveryNode != null)
            {
                var attribute = dynamicDiscoveryNode.Attributes["Enabled"];
                if (attribute != null)
                    config.DynamicDiscovery = Convert.ToBoolean(attribute.Value);
            }

            var engineNode = section.SelectSingleNode("Engine");
            if (engineNode != null)
            {
                var attribute = engineNode.Attributes["Type"];
                if (attribute != null)
                    config.EngineType = attribute.Value;
            }

            var themeNode = section.SelectSingleNode("Themes");
            if (themeNode != null)
            {
                var attribute = themeNode.Attributes["basePath"];
                if (attribute != null)
                    config.ThemeBasePath = attribute.Value;
            }

            config.ScheduleTasks = section.SelectSingleNode("ScheduleTasks");

            return config;
        }

        #endregion

        #region Properties

        /// <summary>
        /// In addition to configured assemblies examine and load assemblies in the bin directory.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [dynamic discovery]; otherwise, <c>false</c>.
        /// </value>
        public bool DynamicDiscovery { get; set; }

        /// <summary>
        /// A custom <see cref="IEngine"/> to manage the application instead of the default.
        /// </summary>
        /// <value>
        /// The type of the engine.
        /// </value>
        public string EngineType { get; set; }

        /// <summary>
        /// Gets or sets a schedule tasks section
        /// </summary>
        /// <value>
        /// The schedule tasks.
        /// </value>
        public XmlNode ScheduleTasks { get; set; }

        /// <summary>
        /// Specifices where the themes will be stored (~/Themes/)
        /// </summary>
        /// <value>
        /// The theme base path.
        /// </value>
        public string ThemeBasePath { get; set; }

        #endregion
    }
}
