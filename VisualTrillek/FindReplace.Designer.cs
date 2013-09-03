namespace VisualTrillek
{
    partial class FindReplace
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
            this.textBoxFind = new System.Windows.Forms.TextBox();
            this.labelFind = new System.Windows.Forms.Label();
            this.textBoxReplace = new System.Windows.Forms.TextBox();
            this.labelReplace = new System.Windows.Forms.Label();
            this.checkBoxCaseSensitive = new System.Windows.Forms.CheckBox();
            this.buttonFindNext = new System.Windows.Forms.Button();
            this.buttonFindPrevious = new System.Windows.Forms.Button();
            this.buttonReplaceNext = new System.Windows.Forms.Button();
            this.buttonReplacePrevious = new System.Windows.Forms.Button();
            this.buttonReplaceAll = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxFind
            // 
            this.textBoxFind.Location = new System.Drawing.Point(95, 12);
            this.textBoxFind.Name = "textBoxFind";
            this.textBoxFind.Size = new System.Drawing.Size(335, 23);
            this.textBoxFind.TabIndex = 1;
            this.textBoxFind.Enter += new System.EventHandler(this.textBoxFind_Enter);
            // 
            // labelFind
            // 
            this.labelFind.AutoSize = true;
            this.labelFind.Location = new System.Drawing.Point(26, 15);
            this.labelFind.Name = "labelFind";
            this.labelFind.Size = new System.Drawing.Size(63, 15);
            this.labelFind.TabIndex = 0;
            this.labelFind.Text = "Search &for:";
            // 
            // textBoxReplace
            // 
            this.textBoxReplace.Location = new System.Drawing.Point(95, 41);
            this.textBoxReplace.Name = "textBoxReplace";
            this.textBoxReplace.Size = new System.Drawing.Size(335, 23);
            this.textBoxReplace.TabIndex = 3;
            this.textBoxReplace.Enter += new System.EventHandler(this.textBoxReplace_Enter);
            // 
            // labelReplace
            // 
            this.labelReplace.AutoSize = true;
            this.labelReplace.Location = new System.Drawing.Point(12, 44);
            this.labelReplace.Name = "labelReplace";
            this.labelReplace.Size = new System.Drawing.Size(77, 15);
            this.labelReplace.TabIndex = 2;
            this.labelReplace.Text = "Replace &with:";
            // 
            // checkBoxCaseSensitive
            // 
            this.checkBoxCaseSensitive.AutoSize = true;
            this.checkBoxCaseSensitive.Location = new System.Drawing.Point(331, 70);
            this.checkBoxCaseSensitive.Name = "checkBoxCaseSensitive";
            this.checkBoxCaseSensitive.Size = new System.Drawing.Size(99, 19);
            this.checkBoxCaseSensitive.TabIndex = 4;
            this.checkBoxCaseSensitive.Text = "Case &sensitive";
            this.checkBoxCaseSensitive.UseVisualStyleBackColor = true;
            // 
            // buttonFindNext
            // 
            this.buttonFindNext.Location = new System.Drawing.Point(250, 67);
            this.buttonFindNext.Name = "buttonFindNext";
            this.buttonFindNext.Size = new System.Drawing.Size(75, 23);
            this.buttonFindNext.TabIndex = 5;
            this.buttonFindNext.Text = "Find &Next";
            this.buttonFindNext.UseVisualStyleBackColor = true;
            this.buttonFindNext.Click += new System.EventHandler(this.buttonFindNext_Click);
            // 
            // buttonFindPrevious
            // 
            this.buttonFindPrevious.Location = new System.Drawing.Point(176, 67);
            this.buttonFindPrevious.Name = "buttonFindPrevious";
            this.buttonFindPrevious.Size = new System.Drawing.Size(68, 23);
            this.buttonFindPrevious.TabIndex = 6;
            this.buttonFindPrevious.Text = "&Previous";
            this.buttonFindPrevious.UseVisualStyleBackColor = true;
            this.buttonFindPrevious.Click += new System.EventHandler(this.buttonFindPrevious_Click);
            // 
            // buttonReplaceNext
            // 
            this.buttonReplaceNext.Location = new System.Drawing.Point(250, 95);
            this.buttonReplaceNext.Name = "buttonReplaceNext";
            this.buttonReplaceNext.Size = new System.Drawing.Size(90, 23);
            this.buttonReplaceNext.TabIndex = 7;
            this.buttonReplaceNext.Text = "&Replace Next";
            this.buttonReplaceNext.UseVisualStyleBackColor = true;
            this.buttonReplaceNext.Click += new System.EventHandler(this.buttonReplaceNext_Click);
            // 
            // buttonReplacePrevious
            // 
            this.buttonReplacePrevious.Location = new System.Drawing.Point(176, 95);
            this.buttonReplacePrevious.Name = "buttonReplacePrevious";
            this.buttonReplacePrevious.Size = new System.Drawing.Size(68, 23);
            this.buttonReplacePrevious.TabIndex = 8;
            this.buttonReplacePrevious.Text = "Pre&vious";
            this.buttonReplacePrevious.UseVisualStyleBackColor = true;
            this.buttonReplacePrevious.Click += new System.EventHandler(this.buttonReplacePrevious_Click);
            // 
            // buttonReplaceAll
            // 
            this.buttonReplaceAll.Location = new System.Drawing.Point(346, 95);
            this.buttonReplaceAll.Name = "buttonReplaceAll";
            this.buttonReplaceAll.Size = new System.Drawing.Size(84, 23);
            this.buttonReplaceAll.TabIndex = 9;
            this.buttonReplaceAll.Text = "Replace &All";
            this.buttonReplaceAll.UseVisualStyleBackColor = true;
            this.buttonReplaceAll.Click += new System.EventHandler(this.buttonReplaceAll_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClose.Location = new System.Drawing.Point(12, 96);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(68, 23);
            this.buttonClose.TabIndex = 10;
            this.buttonClose.Text = "&Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(137, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 15);
            this.label1.TabIndex = 11;
            this.label1.Text = "Find:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(119, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 15);
            this.label2.TabIndex = 12;
            this.label2.Text = "Replace:";
            // 
            // FindReplace
            // 
            this.AcceptButton = this.buttonFindNext;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonClose;
            this.ClientSize = new System.Drawing.Size(442, 131);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonReplaceAll);
            this.Controls.Add(this.buttonReplacePrevious);
            this.Controls.Add(this.buttonReplaceNext);
            this.Controls.Add(this.buttonFindPrevious);
            this.Controls.Add(this.buttonFindNext);
            this.Controls.Add(this.checkBoxCaseSensitive);
            this.Controls.Add(this.labelReplace);
            this.Controls.Add(this.textBoxReplace);
            this.Controls.Add(this.labelFind);
            this.Controls.Add(this.textBoxFind);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FindReplace";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Find/Replace";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FindReplace_FormClosing);
            this.Load += new System.EventHandler(this.FindReplace_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelFind;
        private System.Windows.Forms.Label labelReplace;
        private System.Windows.Forms.CheckBox checkBoxCaseSensitive;
        private System.Windows.Forms.Button buttonFindNext;
        private System.Windows.Forms.Button buttonFindPrevious;
        private System.Windows.Forms.Button buttonReplaceNext;
        private System.Windows.Forms.Button buttonReplacePrevious;
        private System.Windows.Forms.Button buttonReplaceAll;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox textBoxFind;
        public System.Windows.Forms.TextBox textBoxReplace;
    }
}