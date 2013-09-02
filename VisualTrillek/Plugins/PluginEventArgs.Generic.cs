using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisualTrillek.Plugins
{
    /// <summary>
    /// Specifies the Main window instance that fired the event, and a custom generic form involved in this event.
    /// </summary>
    public class PluginEventArgs<TForm> : PluginEventArgs where TForm : Form
    {
        /// <summary>
        /// The window in which the event was fired.
        /// </summary>
        public TForm Window
        {
            get;
            set;
        }

        /// <summary>
        /// Creates a new PluginEventArgs&lt;<typeparamref name="TForm"/>&gt; object with the given window.
        /// </summary>
        /// <param name="window">The window in which the event was fired.</param>
        public PluginEventArgs(TForm window)
            : base(window.MdiParent as Main)
        {
            Window = window;
        }
    }
}
