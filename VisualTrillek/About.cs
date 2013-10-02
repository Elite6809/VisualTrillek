using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisualTrillek
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        public About(Icon icon)
            : this()
        {
            pictureBoxIcon.Image = icon.ToBitmap();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void About_Load(object sender, EventArgs e)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            AssemblyTitleAttribute title = assembly.GetCustomAttribute<AssemblyTitleAttribute>();
            AssemblyFileVersionAttribute fileVersion = assembly.GetCustomAttribute<AssemblyFileVersionAttribute>();
            AssemblyDescriptionAttribute description = assembly.GetCustomAttribute<AssemblyDescriptionAttribute>();
            AssemblyCompanyAttribute company = assembly.GetCustomAttribute<AssemblyCompanyAttribute>();

            labelTitle.Text += title.Title +
                " - " +
                fileVersion.Version;
            labelDescription.Text += description.Description;
            labelAuthor.Text += company.Company;
            labelDisclaimer.Text += Properties.Resources.AboutDisclaimer;
        }

        private void labelAuthor_Click(object sender, EventArgs e)
        {

        }
    }
}
