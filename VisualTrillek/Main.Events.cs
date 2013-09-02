using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisualTrillek.Plugins;

namespace VisualTrillek
{
    [DesignerCategory("")]
    public partial class Main : Form
    {
        /// <summary>
        /// The event fired when the program is loaded.
        /// </summary>
        public event EventHandler<PluginEventArgs> OnProgramLoad;

        /// <summary>
        /// The event fired when the program is exited.
        /// </summary>
        public event EventHandler<PluginEventArgs> OnProgramExit;
    }
}
