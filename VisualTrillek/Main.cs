using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisualTrillek.Plugins;

namespace VisualTrillek
{
    /// <summary>
    /// An MDI parent window that contains code editor windows and any other related windows.
    /// </summary>
    public partial class Main : Form
    {
        internal EventList EventList;

        /// <summary>
        /// The main menu of this form.
        /// </summary>
        public MainMenu MainMenu
        {
            get
            {
                return mainMenu;
            }
            set
            {
                mainMenu = value;
            }
        }

        /// <summary>
        /// The event queue to send event notifications to.
        /// </summary>
        public static EventQueue<string> Events
        {
            get
            {
                return Program.Events;
            }
            set
            {
                Program.Events = value;
            }
        }
        /// <summary>
        /// Create a new Main form.
        /// </summary>
        public Main()
        {
            CallEvent(OnProgramLoad, new PluginEventArgs(this));
            InitializeComponent();
        }

        /// <summary>
        /// Calls an event with thread safety and null checking.
        /// </summary>
        /// <param name="eventHandler">The event handler to call.</param>
        /// <param name="args">The EventArgs to pass to the event handler.</param>
        /// <typeparam name="TEventArgs">The type of EventArgs to pass to the event handler.</typeparam>
        internal void CallEvent<TEventArgs>(EventHandler<TEventArgs> eventHandler, TEventArgs args)
        {
            EventHandler<TEventArgs> handler = eventHandler; // thread safety
            if (handler != null)
                handler(this, args);
        }

        /// <summary>
        /// Prompts the user to confirm whether they want to exit.
        /// Nothing's in here because this is handled by the child forms' FormClosing event.
        /// </summary>
        private void ConfirmExit()
        {
            Application.Exit();
            CallEvent(OnProgramExit, new PluginEventArgs(this));
        }

        /// <summary>
        /// Creates a new editor window within this form and displays it.
        /// </summary>
        /// <param name="fileName">The filename of the file contained in this form.</param>
        /// <param name="codeData">The data in the file to show in the editor control.</param>
        /// <returns></returns>
        private CodeEditor AddEditorWindow(string fileName = null, string codeData = null)
        {
            CodeEditor editor = new CodeEditor();
            editor.MdiParent = this;
            editor.editorControl.Text = codeData ?? "";
            editor.FileName = fileName;
            editor.UnsavedChanges = false;
            editor.Show();
            ActivateMdiChild(editor);
            return editor;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            EventList = new EventList(Events);
            EventList.MdiParent = this;
            EventList.Show();
            foreach (Plugin p in Program.LoadedPlugins)
            {
                p.Main = this;
                p.Initialize();
            }
            CallEvent<PluginEventArgs>(OnProgramLoad, new PluginEventArgs(this));
        }

        private void menuItemNew_Click(object sender, EventArgs e)
        {
            AddEditorWindow();
        }

        private void menuItemExit_Click(object sender, EventArgs e)
        {
            ConfirmExit();
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            Open();
        }

        /// <summary>
        /// Shows an OpenFileDialog, prompting the user to open a file.
        /// </summary>
        private void Open()
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = Properties.Resources.DialogFilter;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    Open(ofd.FileName);
                }
            }
        }

        /// <summary>
        /// Opens the specified file in an Editor window.
        /// </summary>
        /// <param name="fileName">The filename of the file to open.</param>
        private void Open(string fileName)
        {
            string codeData = File.ReadAllText(fileName);
            AddEditorWindow(fileName, codeData);
        }

        private void menuItem4_Click(object sender, EventArgs e)
        {
            About();
        }

        /// <summary>
        /// Shows an About dialog.
        /// </summary>
        private void About()
        {
            new About(Icon).ShowDialog();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Program.Settings.Save(Properties.Resources.SettingsPath);
            }
            catch
            {
                // TODO: handle stuff here
            }
        }

        private void menuItemCascade_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void menuItemArrangeIcons_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void menuItemTileH_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void menuItemTileV_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void menuItemUndo_Click(object sender, EventArgs e)
        {

        }

        private void menuItem6_Click(object sender, EventArgs e)
        {
            EventList.Show();
        }
    }
}
