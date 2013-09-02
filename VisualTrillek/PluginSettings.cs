using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace VisualTrillek
{
    public partial class PluginSettings : Form
    {
        private bool loadingForm = true;

        public PluginSettings()
        {
            InitializeComponent();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Plugins_Load(object sender, EventArgs e)
        {
            foreach (XElement pluginElement in Program.Settings.Root
                .Element("plugins")
                .Elements("plugin"))
            {
                StringContainer<XElement> element = new StringContainer<XElement>(
                    pluginElement, 
                    String.Format("{0} by {1}",
                        pluginElement.Attribute("name").Value,
                        pluginElement.Attribute("author").Value));
                checkedListBox.Items.Add(element, pluginElement
                    .Element("enabled")
                    .Value.ToLower() == "true");
            }
            checkedListBox.Focus();
            loadingForm = false;
        }

        private void checkedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (!loadingForm)   // checks this occurred after the form has been loaded,
            {                   // or this is called every time the form loads for each item
                XElement element = checkedListBox.Items[e.Index] as StringContainer<XElement>;
                element.Element("enabled").Value = (e.NewValue == CheckState.Checked).ToString();
                Program.Events.Enqueue("Plugin " + element.Attribute("name").Value + " by " +
                    element.Attribute("author").Value + " has been " +
                    (e.NewValue == CheckState.Checked ? "enabled" : "disabled"));
            }
        }

        private void buttonRestart_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
