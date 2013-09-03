using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using VisualTrillek;
using VisualTrillek.Plugins;

namespace TestPlugin
{
    [Plugin("Test Plugin", "v0.01", "Elite6809")]
    public class TestPlugin : Plugin
    {
        MenuItem pluginMenu;

        public override void Initialize()
        {
            Main.Events.Enqueue("Hello, world");
            Main.OnProgramLoad += Main_OnProgramLoad;
            Main.OnProgramClose += Main_OnProgramClose;
            pluginMenu = new MenuItem(MenuMerge.Add, 30, Shortcut.None, "Test &Plugin",
                null, null, null, null);
            pluginMenu.MenuItems.Add(new MenuItem(
                MenuMerge.Add, 0, Shortcut.None, "&Test Action",
                MenuClick, null, null, null));
        }

        void Main_OnProgramLoad(object sender, PluginEventArgs e)
        {
            Main.MainMenu.MenuItems.Add(pluginMenu);
        }

        void Main_OnProgramClose(object sender, PluginEventArgs e)
        {
            Main.MainMenu.MenuItems.Remove(pluginMenu);
        }

        public void MenuClick(object sender, EventArgs e)
        {
            int timesClicked = 0;
            if (Settings.Element("timesClicked") != null)
            {
                timesClicked = Convert.ToInt32(Settings.Element("timesClicked").Value);
            }
            else
            {
                Settings.Add(new XElement("timesClicked", 0));
            }
            MessageBox.Show(Main, "You've clicked this a total of " + ++timesClicked + " times.");
            Settings.Element("timesClicked").Value = timesClicked.ToString();
        }
    }
}
