namespace VisualTrillek
{
    partial class CodeEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CodeEditor));
            this.editorControl = new ICSharpCode.TextEditor.TextEditorControl();
            this.menuItemSave = new System.Windows.Forms.MenuItem();
            this.mainMenu = new System.Windows.Forms.MainMenu(this.components);
            this.menuItemFile = new System.Windows.Forms.MenuItem();
            this.menuItemOpenHere = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItemSaveAs = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItemEdit = new System.Windows.Forms.MenuItem();
            this.menuItemUndo = new System.Windows.Forms.MenuItem();
            this.menuItemRedo = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.menuItemCut = new System.Windows.Forms.MenuItem();
            this.menuItemCopy = new System.Windows.Forms.MenuItem();
            this.menuItemPaste = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItemFind = new System.Windows.Forms.MenuItem();
            this.menuItemReplace = new System.Windows.Forms.MenuItem();
            this.menuItemGoTo = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.menuItemSelectAll = new System.Windows.Forms.MenuItem();
            this.panelSearch = new System.Windows.Forms.Panel();
            this.buttonCloseFind = new System.Windows.Forms.Button();
            this.buttonPrevious = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.textBoxFind = new System.Windows.Forms.TextBox();
            this.panelSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // editorControl
            // 
            this.editorControl.ConvertTabsToSpaces = true;
            this.editorControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editorControl.IsReadOnly = false;
            this.editorControl.Location = new System.Drawing.Point(0, 0);
            this.editorControl.Name = "editorControl";
            this.editorControl.ShowMatchingBracket = false;
            this.editorControl.Size = new System.Drawing.Size(351, 271);
            this.editorControl.TabIndex = 0;
            this.editorControl.TextChanged += new System.EventHandler(this.editorControl_TextChanged);
            this.editorControl.Load += new System.EventHandler(this.editorControl_Load);
            // 
            // menuItemSave
            // 
            this.menuItemSave.Index = 2;
            this.menuItemSave.MergeOrder = 12;
            this.menuItemSave.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
            this.menuItemSave.Text = "&Save";
            this.menuItemSave.Click += new System.EventHandler(this.menuItemSave_Click);
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemFile,
            this.menuItemEdit});
            // 
            // menuItemFile
            // 
            this.menuItemFile.Index = 0;
            this.menuItemFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemOpenHere,
            this.menuItem4,
            this.menuItemSave,
            this.menuItemSaveAs,
            this.menuItem1,
            this.menuItem2});
            this.menuItemFile.MergeType = System.Windows.Forms.MenuMerge.MergeItems;
            this.menuItemFile.Text = "&File";
            // 
            // menuItemOpenHere
            // 
            this.menuItemOpenHere.Index = 0;
            this.menuItemOpenHere.MergeOrder = 2;
            this.menuItemOpenHere.Shortcut = System.Windows.Forms.Shortcut.CtrlShiftO;
            this.menuItemOpenHere.Text = "Open &Here...";
            this.menuItemOpenHere.Click += new System.EventHandler(this.menuItemOpenHere_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 1;
            this.menuItem4.MergeOrder = 11;
            this.menuItem4.Text = "-";
            // 
            // menuItemSaveAs
            // 
            this.menuItemSaveAs.Index = 3;
            this.menuItemSaveAs.MergeOrder = 13;
            this.menuItemSaveAs.Shortcut = System.Windows.Forms.Shortcut.CtrlShiftS;
            this.menuItemSaveAs.Text = "Save &As...";
            this.menuItemSaveAs.Click += new System.EventHandler(this.menuItemSaveAs_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 4;
            this.menuItem1.MergeOrder = 14;
            this.menuItem1.Text = "-";
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 5;
            this.menuItem2.MergeOrder = 15;
            this.menuItem2.Text = "&Close Window";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // menuItemEdit
            // 
            this.menuItemEdit.Index = 1;
            this.menuItemEdit.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemUndo,
            this.menuItemRedo,
            this.menuItem7,
            this.menuItemCut,
            this.menuItemCopy,
            this.menuItemPaste,
            this.menuItem3,
            this.menuItemFind,
            this.menuItemReplace,
            this.menuItemGoTo,
            this.menuItem8,
            this.menuItemSelectAll});
            this.menuItemEdit.MergeOrder = 5;
            this.menuItemEdit.Text = "&Edit";
            // 
            // menuItemUndo
            // 
            this.menuItemUndo.Index = 0;
            this.menuItemUndo.Shortcut = System.Windows.Forms.Shortcut.CtrlZ;
            this.menuItemUndo.Text = "&Undo";
            this.menuItemUndo.Click += new System.EventHandler(this.menuItemUndo_Click);
            // 
            // menuItemRedo
            // 
            this.menuItemRedo.Index = 1;
            this.menuItemRedo.Shortcut = System.Windows.Forms.Shortcut.CtrlY;
            this.menuItemRedo.Text = "&Redo";
            this.menuItemRedo.Click += new System.EventHandler(this.menuItemRedo_Click);
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 2;
            this.menuItem7.Text = "-";
            // 
            // menuItemCut
            // 
            this.menuItemCut.Index = 3;
            this.menuItemCut.Shortcut = System.Windows.Forms.Shortcut.CtrlX;
            this.menuItemCut.Text = "Cut";
            this.menuItemCut.Click += new System.EventHandler(this.menuItemCut_Click);
            // 
            // menuItemCopy
            // 
            this.menuItemCopy.Index = 4;
            this.menuItemCopy.Shortcut = System.Windows.Forms.Shortcut.CtrlC;
            this.menuItemCopy.Text = "Copy";
            this.menuItemCopy.Click += new System.EventHandler(this.menuItemCopy_Click);
            // 
            // menuItemPaste
            // 
            this.menuItemPaste.Index = 5;
            this.menuItemPaste.Shortcut = System.Windows.Forms.Shortcut.CtrlV;
            this.menuItemPaste.Text = "Paste";
            this.menuItemPaste.Click += new System.EventHandler(this.menuItemPaste_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 6;
            this.menuItem3.Text = "-";
            // 
            // menuItemFind
            // 
            this.menuItemFind.Index = 7;
            this.menuItemFind.Shortcut = System.Windows.Forms.Shortcut.CtrlF;
            this.menuItemFind.Text = "&Find...";
            this.menuItemFind.Click += new System.EventHandler(this.menuItemFind_Click);
            // 
            // menuItemReplace
            // 
            this.menuItemReplace.Index = 8;
            this.menuItemReplace.Shortcut = System.Windows.Forms.Shortcut.CtrlH;
            this.menuItemReplace.Text = "Replace...";
            this.menuItemReplace.Click += new System.EventHandler(this.menuItemReplace_Click);
            // 
            // menuItemGoTo
            // 
            this.menuItemGoTo.Index = 9;
            this.menuItemGoTo.Shortcut = System.Windows.Forms.Shortcut.CtrlG;
            this.menuItemGoTo.Text = "&Go To...";
            this.menuItemGoTo.Click += new System.EventHandler(this.menuItemGoTo_Click);
            // 
            // menuItem8
            // 
            this.menuItem8.Index = 10;
            this.menuItem8.Text = "-";
            // 
            // menuItemSelectAll
            // 
            this.menuItemSelectAll.Index = 11;
            this.menuItemSelectAll.Shortcut = System.Windows.Forms.Shortcut.CtrlA;
            this.menuItemSelectAll.Text = "Select &All";
            this.menuItemSelectAll.Click += new System.EventHandler(this.menuItemSelectAll_Click);
            // 
            // panelSearch
            // 
            this.panelSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSearch.Controls.Add(this.buttonCloseFind);
            this.panelSearch.Controls.Add(this.buttonPrevious);
            this.panelSearch.Controls.Add(this.buttonNext);
            this.panelSearch.Controls.Add(this.textBoxFind);
            this.panelSearch.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelSearch.Location = new System.Drawing.Point(0, 248);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(351, 23);
            this.panelSearch.TabIndex = 1;
            this.panelSearch.Visible = false;
            // 
            // buttonCloseFind
            // 
            this.buttonCloseFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCloseFind.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCloseFind.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonCloseFind.Location = new System.Drawing.Point(-1, -2);
            this.buttonCloseFind.Name = "buttonCloseFind";
            this.buttonCloseFind.Size = new System.Drawing.Size(46, 23);
            this.buttonCloseFind.TabIndex = 3;
            this.buttonCloseFind.Text = "Close";
            this.buttonCloseFind.UseVisualStyleBackColor = true;
            this.buttonCloseFind.Click += new System.EventHandler(this.buttonCloseFind_Click);
            this.buttonCloseFind.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EscapeCloseSearch);
            // 
            // buttonPrevious
            // 
            this.buttonPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonPrevious.Location = new System.Drawing.Point(241, -2);
            this.buttonPrevious.Name = "buttonPrevious";
            this.buttonPrevious.Size = new System.Drawing.Size(64, 23);
            this.buttonPrevious.TabIndex = 2;
            this.buttonPrevious.Text = "Previous";
            this.buttonPrevious.UseVisualStyleBackColor = true;
            this.buttonPrevious.Click += new System.EventHandler(this.buttonPrevious_Click);
            this.buttonPrevious.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EscapeCloseSearch);
            // 
            // buttonNext
            // 
            this.buttonNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonNext.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonNext.Location = new System.Drawing.Point(304, -2);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(46, 23);
            this.buttonNext.TabIndex = 1;
            this.buttonNext.Text = "Next";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            this.buttonNext.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EscapeCloseSearch);
            // 
            // textBoxFind
            // 
            this.textBoxFind.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFind.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxFind.Location = new System.Drawing.Point(44, -1);
            this.textBoxFind.Name = "textBoxFind";
            this.textBoxFind.Size = new System.Drawing.Size(199, 23);
            this.textBoxFind.TabIndex = 0;
            this.textBoxFind.TextChanged += new System.EventHandler(this.textBoxFind_TextChanged);
            this.textBoxFind.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxFind_KeyDown);
            // 
            // CodeEditor
            // 
            this.AcceptButton = this.buttonNext;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCloseFind;
            this.ClientSize = new System.Drawing.Size(351, 271);
            this.Controls.Add(this.panelSearch);
            this.Controls.Add(this.editorControl);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mainMenu;
            this.Name = "CodeEditor";
            this.ShowInTaskbar = false;
            this.Text = "Uninitialised";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CodeEditor_FormClosing);
            this.Load += new System.EventHandler(this.CodeEditor_Load);
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public ICSharpCode.TextEditor.TextEditorControl editorControl;
        private System.Windows.Forms.MainMenu mainMenu;
        private System.Windows.Forms.MenuItem menuItemFile;
        private System.Windows.Forms.MenuItem menuItemSave;
        private System.Windows.Forms.MenuItem menuItemSaveAs;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem menuItemEdit;
        private System.Windows.Forms.MenuItem menuItemUndo;
        private System.Windows.Forms.MenuItem menuItemRedo;
        private System.Windows.Forms.MenuItem menuItem7;
        private System.Windows.Forms.MenuItem menuItemCut;
        private System.Windows.Forms.MenuItem menuItemCopy;
        private System.Windows.Forms.MenuItem menuItemPaste;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem menuItemFind;
        private System.Windows.Forms.MenuItem menuItemReplace;
        private System.Windows.Forms.MenuItem menuItemGoTo;
        private System.Windows.Forms.MenuItem menuItem8;
        private System.Windows.Forms.MenuItem menuItemSelectAll;
        private System.Windows.Forms.MenuItem menuItemOpenHere;
        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.TextBox textBoxFind;
        private System.Windows.Forms.Button buttonPrevious;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Button buttonCloseFind;

    }
}