using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Plugin()
        {

        }

        /// <summary>
        /// Load the plugin.
        /// </summary>
        /// <param name="main">The main window of the active program.</param>
        public Plugin(Main main)
        {
            Main = main;
        }

        /// <summary>
        /// Initialise the plugin.
        /// </summary>
        public abstract void Initialize();
    }
}
