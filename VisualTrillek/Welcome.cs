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
    }
}
