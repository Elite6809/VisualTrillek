using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisualTrillek
{
    /// <summary>
    /// An MDI parent window that contains code editor windows and any other related windows.
    /// </summary>
    public partial class Main : Form
    {
        /// <summary>
        /// Create a new Main form.
        /// </summary>
        public Main()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Prompts the user to confirm whether they want to exit.
        /// Nothing's in here because this is handled by the child forms' FormClosing event.
        /// </summary>
        private void ConfirmExit()
        {
            Application.Exit();
        }

        /// <summary>
        /// Creates a new editor window within this form and displays it.
        /// </summary>
        /// <param name="fileName">The filename of the file contained in this form.</param>
        /// <param name="codeData">The data in the file to show in the editor control.</param>
        /// <returns></returns>
        private CodeEditor AddEditorWindow(string fileName = null, string codeData = null)
        {
            CodeEditor editor = new CodeEditor();
            editor.MdiParent = this;
            editor.editorControl.Text = codeData ?? "";
            editor.FileName = fileName;
            editor.UnsavedChanges = false;
            editor.Show();
            ActivateMdiChild(editor);
            return editor;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            
        }

        private void menuItemNew_Click(object sender, EventArgs e)
        {
            AddEditorWindow();
        }

        private void menuItemExit_Click(object sender, EventArgs e)
        {
            ConfirmExit();
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            Open();
        }

        /// <summary>
        /// Shows an OpenFileDialog, prompting the user to open a file.
        /// </summary>
        private void Open()
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = Properties.Resources.DialogFilter;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    Open(ofd.FileName);
                }
            }
        }

        /// <summary>
        /// Opens the specified file in an Editor window.
        /// </summary>
        /// <param name="fileName">The filename of the file to open.</param>
        private void Open(string fileName)
        {
            string codeData = File.ReadAllText(fileName);
            AddEditorWindow(fileName, codeData);
        }

        private void menuItem4_Click(object sender, EventArgs e)
        {
            About();
        }

        /// <summary>
        /// Shows an About dialog.
        /// </summary>
        private void About()
        {
            new About(Icon).ShowDialog();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Program.Settings.Save(Properties.Resources.SettingsPath);
            }
            catch
            {
                // TODO: handle stuff here
            }
        }

        private void menuItemCascade_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void menuItemArrangeIcons_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void menuItemTileH_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void menuItemTileV_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void menuItemUndo_Click(object sender, EventArgs e)
        {

        }
    }
}
