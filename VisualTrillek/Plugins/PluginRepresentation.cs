using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualTrillek.Plugins
{
    /// <summary>
    /// Represents a plugin, its details, and its status within the program.
    /// </summary>
    public class PluginRepresentation
    {
        /// <summary>
        /// Gets or sets the plugin.
        /// </summary>
        public Plugin Plugin
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the name of the plugin.
        /// </summary>
        public string PluginName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the version of the plugin.
        /// </summary>
        public string PluginVersion
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the author of the plugin.
        /// </summary>
        public string PluginAuthor
        {
            get;
            set;
        }

        /// <summary>
        /// Create a new plugin representation.
        /// </summary>
        /// <param name="plugin">The plugin to represent.</param>
        /// <param name="name">The name of the plugin.</param>
        /// <param name="version">The version of the plugin.</param>
        /// <param name="author">The author of the plugin.</param>
        public PluginRepresentation(Plugin plugin, string name, string version, string author)
        {
            Plugin = plugin;
            PluginName = name;
            PluginVersion = version;
            PluginAuthor = author;
        }
    }
}
