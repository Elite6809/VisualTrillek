using ICSharpCode.TextEditor;
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
        private int searchIndex;
        public SearchType LastSearchType = SearchType.None;
        public FindReplace FindReplace;

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
        /// Gets the current index at which text has been found.
        /// </summary>
        public int SearchIndex
        {
            get
            {
                return searchIndex;
            }
        }

        /// <summary>
        /// Create a new CodeEditor form.
        /// </summary>
        public CodeEditor()
        {
            InitializeComponent();
            windowMenuItem = new MenuItem(ShortFileName, (s, e) => Activate());
            FindReplace = new FindReplace(this);
        }

        private void CodeEditor_Load(object sender, EventArgs e)
        {
            if (MdiParent is Main)
                (MdiParent as Main).menuItemWindow.MenuItems.Add(windowMenuItem);
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
        public void UpdateWindowTitle()
        {
            Text = "Editor: " + (FileName ?? "Untitled") +
                (UnsavedChanges ? "*" : "");
            windowMenuItem.Text = (ShortFileName ?? "Untitled") +
                (UnsavedChanges ? "*" : "");
        }

        /// <summary>
        /// If the FileName property isn't null, save to that location. Otherwise, performs the same action as SaveAs().
        /// </summary>
        public void Save()
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
        public void SaveAs()
        {
            Main.Events.Enqueue("Showing save dialog...");
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
        public void SaveAs(string fileName)
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
        /// <param name="title">The title fo the dialog box to use.</param>
        /// <returns>The FormClosingEventArgs.Cancel value representing whether the window-closing should be cancelled or not.</returns>
        public bool ConfirmClose(string title = "Close")
        {
            Activate();
            if ((UnsavedChanges && FileName != null) ||
                (editorControl.Text.Length > 0 && FileName == null))
            {
                DialogResult dr = MessageBox.Show(
                    "You have unsaved changes to " + (ShortFileName ?? "untitled") + ". Do you want to save this document?",
                    title,
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
                Program.Events.Enqueue("Closed editor window for " + (ShortFileName ?? "untitled document"));
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

        private void menuItemFind_Click(object sender, EventArgs e)
        {
            SetSearchVisible(true);
            textBoxFind.Focus();
        }

        private void menuItemReplace_Click(object sender, EventArgs e)
        {
            FindReplace.Show(this);
        }

        private void menuItemGoTo_Click(object sender, EventArgs e)
        {
            Goto gotoDialog = new Goto(editorControl);
            gotoDialog.ShowDialog();
        }

        private void menuItemSelectAll_Click(object sender, EventArgs e)
        {
            editorControl.ActiveTextAreaControl.TextArea.ClipboardHandler.SelectAll(sender, e);
        }

        private void menuItemOpenHere_Click(object sender, EventArgs e)
        {
            if (!ConfirmClose("Open Here"))
            {
                (MdiParent as Main).Open(this);
                UnsavedChanges = false;
            }
        }

        private void textBoxFind_TextChanged(object sender, EventArgs e)
        {
            searchIndex = 0;
        }

        private void buttonCloseFind_Click(object sender, EventArgs e)
        {
            SetSearchVisible(false);
        }

        /// <summary>
        /// Sets the visibility of the search bar.
        /// </summary>
        /// <param name="visible">Whether the search bar shall be visible or not.</param>
        public void SetSearchVisible(bool visible)
        {
            panelSearch.Visible = visible;
            textBoxFind.Text = "";
            /* searchIndex = 0;
            lastSearchType = LastSearchType.None; */
        }

        /// <summary>
        /// Search forward until SearchString is found.
        /// </summary>
        /// <param name="searchString">The string to search for.</param>
        /// <param name="caseSensitive">Whether the search is case-sensitive or not.</param>
        /// <param name="message">Whether to display a MessageBox upon failure or not.</param>
        /// <returns>Returns true if a match was found, otherwise false.</returns>
        public bool SearchNext(string searchString, bool caseSensitive = false, bool message = true)
        {
            if (LastSearchType == SearchType.Backward) searchIndex += searchString.Length;
            searchIndex = (searchIndex + editorControl.Text.Length) % editorControl.Text.Length;
            searchIndex = editorControl.Text.IndexOf(searchString, searchIndex,
                caseSensitive ? StringComparison.InvariantCulture : StringComparison.InvariantCultureIgnoreCase);
            if (searchIndex == -1)
            {
                searchIndex = 0;
                searchIndex = editorControl.Text.IndexOf(searchString, searchIndex,
                    caseSensitive ? StringComparison.InvariantCulture : StringComparison.InvariantCultureIgnoreCase);
                if (searchIndex == -1)
                {
                    if (message)
                    {
                        MessageBox.Show(this, "No occurrence of the string " + searchString, "Search",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    return false;
                }
            }
            TextLocation
                startLocation = editorControl.Document.OffsetToPosition(searchIndex),
                endLocation = editorControl.Document.OffsetToPosition(searchIndex + searchString.Length);
            editorControl.ActiveTextAreaControl.SelectionManager.SetSelection(startLocation, endLocation);
            editorControl.ActiveTextAreaControl.Caret.Position = startLocation;
            editorControl.ActiveTextAreaControl.ScrollToCaret();
            searchIndex += searchString.Length;
            LastSearchType = SearchType.Forward;
            return true;
        }

        /// <summary>
        /// Search backward until SearchString is found.
        /// </summary>
        /// <param name="searchString">The string to search for.</param>
        /// <param name="caseSensitive">Whether the search is case-sensitive or not.</param>
        /// <param name="message">Whether to display a MessageBox upon failure or not.</param>
        /// <returns>Returns true if a match was found, otherwise false.</returns>
        public bool SearchPrevious(string searchString, bool caseSensitive = false, bool message = true)
        {
            if (LastSearchType == SearchType.Forward) searchIndex -= searchString.Length;
            searchIndex = (searchIndex + editorControl.Text.Length) % editorControl.Text.Length;
            searchIndex = editorControl.Text.LastIndexOf(searchString, searchIndex,
                caseSensitive ? StringComparison.InvariantCulture : StringComparison.InvariantCultureIgnoreCase);
            if (searchIndex == -1)
            {
                searchIndex = editorControl.Text.Length;
                searchIndex = editorControl.Text.LastIndexOf(searchString, searchIndex,
                    caseSensitive ? StringComparison.InvariantCulture : StringComparison.InvariantCultureIgnoreCase);
                if (searchIndex == -1)
                {
                    if (message)
                    {
                        MessageBox.Show(this, "No occurrence of the string " + searchString, "Search",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    return false;
                }
            }
            TextLocation
                startLocation = editorControl.Document.OffsetToPosition(searchIndex),
                endLocation = editorControl.Document.OffsetToPosition(searchIndex + searchString.Length);
            editorControl.ActiveTextAreaControl.SelectionManager.SetSelection(startLocation, endLocation);
            editorControl.ActiveTextAreaControl.Caret.Position = startLocation;
            editorControl.ActiveTextAreaControl.ScrollToCaret();
            LastSearchType = SearchType.Backward;
            return true;
        }

        private void textBoxFind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                SetSearchVisible(false);
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Enter)
            {
                buttonNext.Focus();
                SearchNext(textBoxFind.Text);
                e.Handled = true;
            }
        }
        private void buttonNext_Click(object sender, EventArgs e)
        {
            SearchNext(textBoxFind.Text);
        }

        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            SearchPrevious(textBoxFind.Text);
        }

        private void EscapeCloseSearch(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                SetSearchVisible(false);
                e.Handled = true;
            }
        }
    }
}
