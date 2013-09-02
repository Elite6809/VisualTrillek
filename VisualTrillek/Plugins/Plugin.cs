using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace VisualTrillek.Plugins
{
    /// <summary>
    /// Represents a plugin for the Visual Trillek IDE.
    /// </summary>
    public abstract class Plugin
    {
        /// <summary>
        /// The main window of the active program.
        /// </summary>
        public Main Main
        {
            get;
            set;
        }

        /// <summary>
        /// The LINQ-to-XML settings element which can be used to store plugin-specific settings.
        /// </summary>
        public XElement Settings
        {
            get;
            set;
        }

        /// <summary>
        /// Load the plugin.
        /// </summary>
        public Plugin()
        {

        }

        /// <summary>
        /// Initialise the plugin.
        /// </summary>
        public abstract void Initialize();
    }
}
