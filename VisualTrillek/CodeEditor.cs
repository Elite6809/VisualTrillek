using ICSharpCode.TextEditor.Document;
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
    /// An MDI child window allowing the user to edit code files.
    /// </summary>
    public partial class CodeEditor : Form
    {
        private MenuItem windowMenuItem;

        /// <summary>
        /// Gets or sets the filename of the currently open file in this editor.
        /// If this is an untitled document, this returns null.
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Gets or sets whether there are unsaved changes to the document.
        /// </summary>
        public bool UnsavedChanges { get; set; }

        /// <summary>
        /// Gets the short filename (path stripped) of the currently open file in this editor.
        /// </summary>
        public string ShortFileName
        {
            get
            {
                return FileName != null ?
                    FileName.Split('\\', '/').Last() :
                    null;
            }
        }

        /// <summary>
        /// Create a new CodeEditor form.
        /// </summary>
        public CodeEditor()
        {
            InitializeComponent();
            windowMenuItem = new MenuItem(ShortFileName, (s, e) => Activate());
            if(MdiParent is Main)
                (MdiParent as Main).menuItemWindow.MenuItems.Add(windowMenuItem);
        }

        private void CodeEditor_Load(object sender, EventArgs e)
        {
            editorControl.Font = new Font("Consolas", 10, FontStyle.Regular);
            editorControl.HorizontalScroll.Visible = false;
            editorControl.VerticalScroll.Visible = false;
            editorControl.ShowEOLMarkers = false;
            UpdateWindowTitle();
            Program.Events.Enqueue("Loaded editor window for " + (ShortFileName ?? "new document"));
        }

        private void editorControl_TextChanged(object sender, EventArgs e)
        {
            UnsavedChanges = true;
            UpdateWindowTitle();
        }

        /// <summary>
        /// Updates the current window title and the Window menu entry for this window.
        /// </summary>
        private void UpdateWindowTitle()
        {
            Text = "Editor: " + (FileName ?? "Untitled") +
                (UnsavedChanges ? "*" : "");
            windowMenuItem.Text = (ShortFileName ?? "Untitled") +
                (UnsavedChanges ? "*" : "");
        }

        /// <summary>
        /// If the FileName property isn't null, save to that location. Otherwise, performs the same action as SaveAs().
        /// </summary>
        private void Save()
        {
            if (FileName == null)
            {
                SaveAs();
            }
            else
            {
                SaveAs(FileName);
            }
        }

        /// <summary>
        /// Opens a SaveFileDialog, prompting the user to choose as save location, and subsequently save the document to the new filename.
        /// </summary>
        private void SaveAs()
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = Properties.Resources.DialogFilter;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    FileName = sfd.FileName;
                    SaveAs(FileName);
                }
            }
        }

        /// <summary>
        /// Save the document to the given filename.
        /// </summary>
        /// <param name="fileName">The filename to save the document to.</param>
        private void SaveAs(string fileName)
        {
            File.WriteAllText(fileName, editorControl.Text);
            UnsavedChanges = false;
            UpdateWindowTitle();
            Program.Events.Enqueue("Saved document " + fileName);
        }

        private void editorControl_Load(object sender, EventArgs e)
        {
            HighlightingManager hmgr = HighlightingManager.Manager;
            TrillekSyntaxModeProvider smp = new TrillekSyntaxModeProvider();
            hmgr.AddSyntaxModeFileProvider(smp);
            editorControl.SetHighlighting("DCPU");
        }

        private void menuItemSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void menuItemSaveAs_Click(object sender, EventArgs e)
        {
            SaveAs();
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// If the document has unsaved changes, asks for confirmation from the user if they want to save this document.
        /// If there are none, or the user selects no, the window is closed.
        /// If the user selects yes, the document is saved via the <c>Save()</c> method.
        /// If the user selects cancel, the FormClosingEventArgs.Cancel property is set to true, to the closing operation is halted.
        /// </summary>
        /// <returns>The FormClosingEventArgs.Cancel value representing whether the window-closing should be cancelled or not.</returns>
        private bool ConfirmClose()
        {
            Activate();
            if ((UnsavedChanges && FileName != null) ||
                (editorControl.Text.Length > 0 && FileName == null))
            {
                DialogResult dr = MessageBox.Show(
                    "You have unsaved changes to " + (ShortFileName ?? "untitled") + ". Do you want to save this document?",
                    "Close",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    Save();
                    return false;
                }
                else if (dr == DialogResult.No)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        private void CodeEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!(e.Cancel = ConfirmClose()))
            {
                if(MdiParent is Main)
                    (MdiParent as Main).menuItemWindow.MenuItems.Remove(windowMenuItem);
                Program.Events.Enqueue("Closing editor window for " + (ShortFileName ?? "untitled document"));
            }
        }

        private void menuItemUndo_Click(object sender, EventArgs e)
        {
            editorControl.Undo();
        }

        private void menuItemRedo_Click(object sender, EventArgs e)
        {
            editorControl.Redo();
        }

        private void menuItemCut_Click(object sender, EventArgs e)
        {
            editorControl.ActiveTextAreaControl.TextArea.ClipboardHandler.Cut(sender, e);
        }

        private void menuItemCopy_Click(object sender, EventArgs e)
        {
            editorControl.ActiveTextAreaControl.TextArea.ClipboardHandler.Copy(sender, e);
        }

        private void menuItemPaste_Click(object sender, EventArgs e)
        {
            editorControl.ActiveTextAreaControl.TextArea.ClipboardHandler.Paste(sender, e);
        }
    }
}
