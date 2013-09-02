using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualTrillek.Plugins
{
    /// <summary>
    /// Specifies the Main window instance that fired the event.
    /// </summary>
    public class PluginEventArgs : EventArgs
    {
        /// <summary>
        /// The Main window in which the event was fired.
        /// </summary>
        public Main MainWindow
        {
            get;
            set;
        }

        /// <summary>
        /// Creates a new PluginEventArgs object with the given main window.
        /// </summary>
        /// <param name="mainWindow">The Main window in which the event was fired.</param>
        public PluginEventArgs(Main mainWindow)
        {
            MainWindow = mainWindow;
        }
    }
}
