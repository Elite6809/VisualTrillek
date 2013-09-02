using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualTrillek.Plugins
{
    /// <summary>
    /// Represents the parameters of a plugin.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class PluginAttribute : Attribute
    {
        /// <summary>
        /// Attribute a plugin.
        /// </summary>
        /// <param name="pluginName">The name of the plugin.</param>
        /// <param name="pluginVersion">The version of the plugin.</param>
        /// <param name="pluginAuthor">The author of the plugin.</param>
        public PluginAttribute(string pluginName, string pluginVersion, string pluginAuthor = "Anonymous")
        {
            PluginName = pluginName;
            PluginVersion = pluginVersion;
            PluginAuthor = pluginAuthor;
        }

        /// <summary>
        /// The name of the plugin.
        /// </summary>
        public string PluginName { get; private set; }

        /// <summary>
        /// The version of the plugin.
        /// </summary>
        public string PluginVersion { get; private set; }

        /// <summary>
        /// The author of the plugin.
        /// </summary>
        public string PluginAuthor { get; private set; }
    }
}
