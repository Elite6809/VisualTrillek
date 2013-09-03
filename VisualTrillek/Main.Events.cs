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
    /// <summary>
    /// Open me in the code editor, not the designer!
    /// </summary>
    [DesignerCategory("")]
    public partial class Main : Form
    {
        /// <summary>
        /// The event fired when the program is loaded.
        /// </summary>
        public event EventHandler<PluginEventArgs> OnProgramLoad;

        /// <summary>
        /// Fires the OnProgramLoad event.
        /// </summary>
        internal void FireOnProgramLoad()
        {
            CallEvent(OnProgramLoad, new PluginEventArgs(this));
        }

        /// <summary>
        /// The event fired when the program is closed.
        /// </summary>
        public event EventHandler<PluginEventArgs> OnProgramClose;

        /// <summary>
        /// Fires the OnProgramClose event.
        /// </summary>
        internal void FireOnProgramClose()
        {
            CallEvent(OnProgramClose, new PluginEventArgs(this));
        }

        /// <summary>
        /// The event fired when a code editor is loaded.
        /// </summary>
        public event EventHandler<PluginEventArgs<CodeEditor>> OnCodeEditorLoad;

        /// <summary>
        /// Fires the OnCodeEditorLoad event.
        /// </summary>
        /// <param name="editor">The associated form.</param>
        internal void FireOnCodeEditorLoad(CodeEditor editor)
        {
            CallEvent(OnCodeEditorLoad, new PluginEventArgs<CodeEditor>(editor));
        }

        /// <summary>
        /// The event fired when a code editor is closed.
        /// </summary>
        public event EventHandler<PluginEventArgs<CodeEditor>> OnCodeEditorClose;

        /// <summary>
        /// Fires the OnCodeEditorClose event.
        /// </summary>
        /// <param name="editor">The associated form.</param>
        internal void FireOnCodeEditorClose(CodeEditor editor)
        {
            CallEvent(OnCodeEditorClose, new PluginEventArgs<CodeEditor>(editor));
        }

        /// <summary>
        /// Calls an event with thread safety and null checking.
        /// </summary>
        /// <param name="eventHandler">The event handler to call.</param>
        /// <param name="args">The EventArgs to pass to the event handler.</param>
        internal void CallEvent(EventHandler<PluginEventArgs> eventHandler, PluginEventArgs args)
        {
            EventHandler<PluginEventArgs> handler = eventHandler; // thread safety
            if (handler != null)
                handler(this, args);
        }

        /// <summary>
        /// Calls an event with thread safety and null checking.
        /// </summary>
        /// <param name="eventHandler">The event handler to call.</param>
        /// <param name="args">The EventArgs to pass to the event handler.</param>
        /// <typeparam name="TForm">The form involved in the event.</typeparam>
        internal void CallEvent<TForm>(EventHandler<PluginEventArgs<TForm>> eventHandler, PluginEventArgs<TForm> args) where TForm : Form
        {
            EventHandler<PluginEventArgs<TForm>> handler = eventHandler; // thread safety
            if (handler != null)
                handler(this, args);
        }
    }
}
