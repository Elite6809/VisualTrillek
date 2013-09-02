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
    public partial class Welcome : Form
    {
        public Welcome()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Welcome_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
            Program.Events.Enqueue("Closed welcome window");
        }

        private void Welcome_Load(object sender, EventArgs e)
        {
            Program.Events.Enqueue("Loaded welcome window");
            Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
            (MdiParent as Main).AddEditorWindow();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
            (MdiParent as Main).Open();
        }

        /// <summary>
        /// Displays the control to the user.
        /// </summary>
        public new void Show()
        {
            base.Show();
            CenterToParent();
        }

        /// <summary>
        /// Shows the form with the specified owner to the user.
        /// </summary>
        /// <param name="owner">
        /// Any object that implements System.Windows.Forms.IWin32Window and
        /// represents the top-level window that will own this form.
        /// </param>
        public new void Show(IWin32Window owner)
        {
            base.Show(owner);
            CenterToParent();
        }

        /// <summary>
        /// Centers the form in the parent.
        /// </summary>
        public new void CenterToParent()
        {
            this.Location = new Point(
                (ParentForm.Width - Width) / 2,
                (ParentForm.Height - Height) / 2);
        }
    }
}
