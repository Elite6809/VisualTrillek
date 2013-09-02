using ICSharpCode.TextEditor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisualTrillek
{
    public partial class Goto : Form
    {
        private TextEditorControl Editor;

        public Goto(TextEditorControl editor)
        {
            InitializeComponent();
            Editor = editor;
            Editor.TextChanged += Editor_TextChanged;
            UpdateMaximumLine();
            numericUpDown.Select(0, numericUpDown.Value.ToString().Length);
        }

        private void UpdateMaximumLine()
        {
            numericUpDown.Maximum = Editor.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.None).Length + 1;
        }

        private void Editor_TextChanged(object sender, EventArgs e)
        {
            UpdateMaximumLine();
        }

        private void Goto_Load(object sender, EventArgs e)
        {

        }

        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {

        }

        private void buttonGo_Click(object sender, EventArgs e)
        {
            Editor.ActiveTextAreaControl.Caret.Column = 0;
            Editor.ActiveTextAreaControl.Caret.Line = (int)numericUpDown.Value - 1;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void numericUpDown_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonGo_Click(sender, e);
                e.Handled = true;
            }
        }

        private void buttonGo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonGo_Click(sender, e);
                e.Handled = true;
            }
        }
    }
}
