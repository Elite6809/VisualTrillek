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
        internal Welcome Welcome;

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
        public static new EventQueue<string> Events
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
        public void ConfirmExit()
        {
            Application.Exit();
        }

        /// <summary>
        /// Creates a new editor window within this form and displays it.
        /// </summary>
        /// <param name="fileName">The filename of the file contained in this form.</param>
        /// <param name="codeData">The data in the file to show in the editor control.</param>
        /// <returns></returns>
        public CodeEditor AddEditorWindow(string fileName = null, string codeData = null)
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
            Welcome = new Welcome();
            Welcome.MdiParent = this;
            Welcome.Show();
            Welcome.CenterToParent();
            Welcome.Activate();
            foreach (PluginRepresentation pr in Program.LoadedPlugins)
            {
                Plugin p = pr.Plugin;
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

        private void menuItemOpen_Click(object sender, EventArgs e)
        {
            Open();
        }

        /// <summary>
        /// Shows an OpenFileDialog, prompting the user to open a file.
        /// </summary>
        /// <param name="editor">The editor to open the file in, or null to create a new one.</param>
        public void Open(CodeEditor editor = null)
        {
            Events.Enqueue("Showing open dialog...");
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = Properties.Resources.DialogFilter;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    Open(ofd.FileName, editor);
                }
            }
        }

        /// <summary>
        /// Opens the specified file in an Editor window.
        /// </summary>
        /// <param name="fileName">The filename of the file to open.</param>
        /// <param name="editor">The editor to open the file in, or null to create a new one.</param>
        public void Open(string fileName, CodeEditor editor = null)
        {
            string codeData = File.ReadAllText(fileName);
            if (editor == null)
            {
                AddEditorWindow(fileName, codeData);
            }
            else
            {
                editor.FileName = fileName;
                editor.editorControl.Text = codeData;
                editor.editorControl.ActiveTextAreaControl.Caret.Line = 0;
                editor.editorControl.ActiveTextAreaControl.Caret.Column = 0;
                editor.UpdateWindowTitle();
                editor.Activate();
            }
        }

        /// <summary>
        /// Shows the About dialog.
        /// </summary>
        public void About()
        {
            new About(Icon).ShowDialog(this);
        }

        /// <summary>
        /// Shows the Plugin Settings dialog.
        /// </summary>
        public void PluginSettings()
        {
            new PluginSettings().ShowDialog(this);
        }

        private void menuItem4_Click(object sender, EventArgs e)
        {
            About();
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
            finally
            {
                CallEvent(OnProgramExit, new PluginEventArgs(this));
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
            EventList.Activate();
        }

        private void menuItem7_Click(object sender, EventArgs e)
        {
            Welcome.Show();
            Welcome.Activate();
        }

        public void ToggleWindowMaximise()
        {
            ActiveMdiChild.WindowState =
                ActiveMdiChild.WindowState == FormWindowState.Maximized ?
                FormWindowState.Normal : FormWindowState.Maximized;
        }

        public void ToggleWindowMinimise()
        {
            ActiveMdiChild.WindowState =
                ActiveMdiChild.WindowState == FormWindowState.Minimized ?
                FormWindowState.Normal : FormWindowState.Minimized;
        }

        private void menuItemMaximise_Click(object sender, EventArgs e)
        {
            ToggleWindowMaximise();
        }

        private void menuItemMinimise_Click(object sender, EventArgs e)
        {
            ToggleWindowMinimise();
        }

        private void menuItemPlugins_Click(object sender, EventArgs e)
        {
            PluginSettings();
        }

        private void Main_Resize(object sender, EventArgs e)
        {
            if(Welcome != null)
                Welcome.CenterToParent();
        }
    }
}
