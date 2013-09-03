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
    public partial class FindReplace : Form
    {
        private CodeEditor Editor;
        
        public FindReplace(CodeEditor editor)
        {
            InitializeComponent();
            Editor = editor;
        }

        private void FindReplace_Load(object sender, EventArgs e)
        {
            Program.Events.Enqueue("Loaded find/replace dialog for editor " + Editor.ShortFileName);
            Text += " for " + Editor.ShortFileName;
        }

        private void buttonFindNext_Click(object sender, EventArgs e)
        {
            Editor.SearchNext(textBoxFind.Text, checkBoxCaseSensitive.Checked, true);
        }

        private void buttonFindPrevious_Click(object sender, EventArgs e)
        {
            Editor.SearchPrevious(textBoxFind.Text, checkBoxCaseSensitive.Checked, true);
        }

        private void buttonReplaceNext_Click(object sender, EventArgs e)
        {
            if (Editor.SearchNext(textBoxFind.Text, checkBoxCaseSensitive.Checked, true))
            {
                Editor.editorControl.Document.Replace(Editor.SearchIndex - 
                    (Editor.LastSearchType == SearchType.Forward ? textBoxFind.TextLength : 0), // go back if last search type is forward
                    textBoxFind.TextLength,
                    textBoxReplace.Text);
            }
        }

        private void buttonReplacePrevious_Click(object sender, EventArgs e)
        {
            if (Editor.SearchPrevious(textBoxFind.Text, checkBoxCaseSensitive.Checked, true))
            {
                Editor.editorControl.Document.Replace(Editor.SearchIndex,
                    textBoxFind.TextLength,
                    textBoxReplace.Text);
            }
        }

        private void buttonReplaceAll_Click(object sender, EventArgs e)
        {
            if (Editor.SearchPrevious(textBoxFind.Text, checkBoxCaseSensitive.Checked, false))
            {
                int found = 0;
                do
                {
                    found++;
                    Editor.editorControl.Document.Replace(Editor.SearchIndex,
                    textBoxFind.TextLength,
                    textBoxReplace.Text);
                } while (Editor.SearchPrevious(textBoxFind.Text, checkBoxCaseSensitive.Checked, false));
                MessageBox.Show(this, "Replaced " + found.ToString() + " occurrences.", "Replace", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(this, "No occurrences found.", "Replace", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void FindReplace_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
            Program.Events.Enqueue("Closed find/replace dialog for editor " + Editor.ShortFileName);
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBoxReplace_Enter(object sender, EventArgs e)
        {
            textBoxReplace.SelectAll();
        }

        private void textBoxFind_Enter(object sender, EventArgs e)
        {
            textBoxFind.SelectAll();
        }
    }
}
