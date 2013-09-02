using ICSharpCode.TextEditor.Document;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace VisualTrillek
{
    // Helper class by Ernest Poletaev
    // http://www.codeproject.com/Articles/111969/Extending-ICSharpCode-TextEditor-Syntax-Highlighti

    /// <summary>
    /// Provides the syntax mode for the Trillek DCPU-16 assembly language
    /// </summary>
    public class TrillekSyntaxModeProvider : ISyntaxModeFileProvider
    {
        private List<SyntaxMode> syntaxModes = null;

        /// <summary>
        /// Gets a list of syntax modes available via this provider.
        /// </summary>
        public ICollection<SyntaxMode> SyntaxModes
        {
            get
            {
                return syntaxModes;
            }
        }

        /// <summary>
        /// Creates a new provider of syntax mode for the Trillek DCPU-16 assembly language
        /// </summary>
        public TrillekSyntaxModeProvider()
        {
            syntaxModes = new List<SyntaxMode>();
            syntaxModes.Add(
                new SyntaxMode("DcpuMode.xshd", "DCPU", ".asm"));
        }

        public XmlTextReader GetSyntaxModeFile(SyntaxMode syntaxMode)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            Stream stream = assembly.GetManifestResourceStream(
              "VisualTrillek.Resources." + syntaxMode.FileName);
            return new XmlTextReader(stream);
        }

        public void UpdateSyntaxModeList()
        {
            // nothing here - list does not change during runtime
        }
    }
}
