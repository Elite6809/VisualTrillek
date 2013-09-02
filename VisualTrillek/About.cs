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
            Assembly a = Assembly.GetExecutingAssembly();
            AssemblyTitleAttribute ata = a.GetCustomAttribute<AssemblyTitleAttribute>();
            AssemblyFileVersionAttribute ava = a.GetCustomAttribute<AssemblyFileVersionAttribute>();
            AssemblyDescriptionAttribute ada = a.GetCustomAttribute<AssemblyDescriptionAttribute>();
            AssemblyCompanyAttribute aca = a.GetCustomAttribute<AssemblyCompanyAttribute>();

            labelTitle.Text += ata.Title +
                " - " +
                ava.Version;
            labelDescription.Text += ada.Description;
            labelAuthor.Text += aca.Company;
        }

        private void labelAuthor_Click(object sender, EventArgs e)
        {

        }
    }
}
