using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using VisualTrillek.Plugins;

namespace VisualTrillek
{
    static class Program
    {
        public static XDocument Settings
        {
            get;
            set;
        }

        public static List<Plugin> LoadedPlugins
        {
            get;
            set;
        }

        public static EventQueue<string> Events = new EventQueue<string>();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            LoadSettings();
            LoadPlugins();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }

        static XDocument InitialiseSettings(this XDocument doc)
        {
            doc.Add(new XElement("settings"));
            return doc;
        }

        /// <summary>
        /// Loads the program's plugins.
        /// </summary>
        static void LoadPlugins()
        {
            LoadedPlugins = new List<Plugin>();
            if (Directory.Exists("Plugins"))
            {
                string[] files = Directory.GetFiles("Plugins")
                    .Where(s => s.EndsWith(".dll"))
                    .ToArray();
                if (files.Length > 0)
                {
                    Events.Enqueue(files.Length.ToString() + " plugins found");
                    foreach (string file in files)
                    {
                        string shortName = file.Split('\\', '/').Last();
                        try
                        {
                            Assembly a = Assembly.LoadFrom(file);
                            LoadPlugins(a.GetName().Name, a.GetTypes());
                        }
                        catch (BadImageFormatException)
                        {
                            Events.Enqueue("Not a plugin: " + shortName);
                        }
                    }
                }
                else
                {
                    Events.Enqueue("No plugins found");
                }
            }
            else
            {
                Events.Enqueue("No plugin directory found, creating");
                Directory.CreateDirectory("Plugins");
            }
        }

        /// <summary>
        /// Load the program's plugins.
        /// </summary>
        /// <param name="types">An array of types to scan.</param>
        static void LoadPlugins(string assemblyName, Type[] types)
        {
            Events.Enqueue("Loading plugins from assembly " + assemblyName + "...");
            foreach (Type t in types)
            {
                if (t.BaseType == typeof(Plugin))
                {
                    Plugin newPlugin = Activator.CreateInstance(t) as Plugin;
                    PluginAttribute attribute = t.GetCustomAttribute<PluginAttribute>();
                    if (attribute != null)
                    {
                        LoadPlugin(newPlugin,
                            attribute.PluginName,
                            attribute.PluginVersion,
                            attribute.PluginAuthor);
                    }
                    else
                    {
                        Events.Enqueue("Missing attributes for " + t.Name);
                    }
                }
            }
        }

        static void LoadPlugin(Plugin plugin, string pluginName, string pluginVersion, string pluginAuthor)
        {
            LoadedPlugins.Add(plugin);
            Events.Enqueue(String.Format("Loaded plugin {0} {1} by {2}",
                pluginName,
                pluginVersion,
                pluginAuthor));
        }

        /// <summary>
        /// Loads the program's settings.
        /// </summary>
        static void LoadSettings()
        {
            try
            {
                if (File.Exists(Properties.Resources.SettingsPath))
                {
                    Settings = XDocument.Load(Properties.Resources.SettingsPath);
                    Events.Enqueue("Loaded settings");
                }
                else
                {
                    Settings = new XDocument().InitialiseSettings();
                    Events.Enqueue("Created new settings");
                }
            }
            catch
            {
                Settings = new XDocument().InitialiseSettings();
                Events.Enqueue("Invalid settings file, regenerating");
            }
        }
    }
}
