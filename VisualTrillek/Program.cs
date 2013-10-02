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

        public static List<PluginRepresentation> LoadedPlugins
        {
            get;
            set;
        }

        public static EventQueue<string> Events;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Events = new EventQueue<string>();
            Main main = new Main();
            Events.Updated += (sender, e) => main.FireOnEventLogged(main.EventList);

            LoadSettings();
            LoadPlugins();
            Application.Run(main);
        }

        /// <summary>
        /// Initialise this XDocument to the settings structure of VisualTrillek.
        /// </summary>
        /// <returns>This XDocument to the settings structure of VisualTrillek.</returns>
        static XDocument InitialiseSettings(this XDocument doc)
        {
            doc.Add(
                new XElement("settings",
                    new XElement("plugins",
                        new XElement("enabledByDefault", true))));
            return doc;
        }

        /// <summary>
        /// Get the LINQ-to-XML settings element for this specific plugin.
        /// </summary>
        /// <param name="pluginRepresentation">The PluginRepresentation representing this plugin.</param>
        /// <returns>The LINQ-to-XML settings element for this specific plugin.</returns>
        static XElement GetSettingsElementFor(PluginRepresentation pluginRepresentation)
        {
            return GetSettingsElementFor(pluginRepresentation.Plugin,
                new PluginAttribute(
                    pluginRepresentation.PluginName,
                    pluginRepresentation.PluginVersion,
                    pluginRepresentation.PluginAuthor));
        }

        /// <summary>
        /// Get the LINQ-to-XML settings element for this specific plugin.
        /// </summary>
        /// <param name="plugin">The plugin.</param>
        /// <param name="attribute">The attribute holding this plugin's details.</param>
        /// <param name="returnNullIfNotExists">
        /// True if you want to return a null if the element doesn't exist.
        /// Otherwise, this prompts the user to create the element.
        /// </param>
        /// <returns>The LINQ-to-XML settings element for this specific plugin.</returns>
        static XElement GetSettingsElementFor(Plugin plugin, PluginAttribute attribute, bool returnNullIfNotExists = false)
        {
            XElement[] element = Settings.Root
                .Element("plugins")
                .Elements("plugin")
                .Where(x => x.Attribute("name").Value == attribute.PluginName &&
                    x.Attribute("author").Value == attribute.PluginAuthor)
                    .ToArray();
            if (element.Length > 0 || returnNullIfNotExists)
            {
                return element.First();
            }
            else
            {
                DialogResult result = MessageBox.Show(
                    "Plugin " + attribute.PluginName + " by " + attribute.PluginAuthor + " has not been used before.\r\n" +
                    "Do you want to enable this plugin? Click Cancel to skip this plugin.", "Enable Plugin",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (result != DialogResult.Cancel)
                {
                    Settings.Root
                        .Element("plugins")
                        .Add(new XElement("plugin",
                            new XAttribute("name", attribute.PluginName),
                            new XAttribute("author", attribute.PluginAuthor),
                            new XElement("enabled", result == DialogResult.Yes)));
                    return GetSettingsElementFor(plugin, attribute, true);
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Loads the program's plugins.
        /// </summary>
        static void LoadPlugins()
        {
            LoadedPlugins = new List<PluginRepresentation>();
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
        /// Load plugins from a list of types.
        /// </summary>
        /// <param name="assemblyName">The name of the assembly that the plugins are from.</param>
        /// <param name="types">An array of types to scan.</param>
        static void LoadPlugins(string assemblyName, Type[] types)
        {
            Events.Enqueue("Loading plugins from assembly " + assemblyName + "...");
            bool enablePluginByDefault = Settings.Root
                        .Element("plugins")
                        .Element("enabledByDefault").Value.ToLower() == "true";
            foreach (Type t in types)
            {
                if (t.BaseType == typeof(Plugin))
                {
                    Plugin newPlugin = Activator.CreateInstance(t) as Plugin;
                    PluginAttribute attribute = t.GetCustomAttribute<PluginAttribute>();
                    newPlugin.Settings = GetSettingsElementFor(newPlugin, attribute);
                    if (newPlugin.Settings != null)
                    {
                        bool enablePlugin = newPlugin.Settings
                            .Element("enabled")
                            .Value.ToLower() == "true";
                        if (enablePlugin)
                        {
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
                        else
                        {
                            Events.Enqueue("Plugin disabled: " + t.Name);
                        }
                    }
                    else
                    {
                        Events.Enqueue("Plugin skipped: " + t.Name);
                    }
                }
            }
        }

        /// <summary>
        /// Load a specific plugin into program memory.
        /// </summary>
        /// <param name="plugin">The plugin to load.</param>
        /// <param name="pluginName">The name of the plugin.</param>
        /// <param name="pluginVersion">The version of the plugin.</param>
        /// <param name="pluginAuthor">The author of the plugin.</param>
        static void LoadPlugin(Plugin plugin, string pluginName, string pluginVersion, string pluginAuthor = "Anonymous")
        {
            LoadedPlugins.Add(new PluginRepresentation(
                plugin,
                pluginName,
                pluginVersion,
                pluginAuthor));
            Events.Enqueue(String.Format("Loaded plugin {0} ({1}) by {2}",
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
