using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualTrillek.Plugins
{
    /// <summary>
    /// Specifies a CodeEditor window of which the event relates to.
    /// </summary>
    public class CodeEditorEventArgs : PluginEventArgs
    {
        /// <summary>
        /// The CodeEditor window in which the event was fired.
        /// </summary>
        public CodeEditor CodeEditor
        {
            get;
            set;
        }

        /// <summary>
        /// Creates a new CodeEditorEventArgs object with the given CodeEditor.
        /// </summary>
        /// <param name="codeEditor">The CodeEditor window in which the event was fired.</param>
        public CodeEditorEventArgs(CodeEditor codeEditor)
            : base(codeEditor.MdiParent as Main)
        {
            CodeEditor = codeEditor;
        }
    }
}
