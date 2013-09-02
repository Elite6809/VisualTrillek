using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace VisualTrillek
{
    static class Program
    {
        public static XDocument Settings
        {
            get;
            set;
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                if (File.Exists(Properties.Resources.SettingsPath))
                {
                    Settings = XDocument.Load(Properties.Resources.SettingsPath);
                }
                else
                {
                    Settings = new XDocument().InitialiseSettings();
                }
            }
            catch
            {
                Settings = new XDocument().InitialiseSettings();
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }

        static XDocument InitialiseSettings(this XDocument doc)
        {
            doc.Add(new XElement("settings"));
            return doc;
        }
    }
}
