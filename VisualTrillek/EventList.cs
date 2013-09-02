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
    public partial class EventList : Form
    {
        public EventQueue<string> EventQueue;

        public EventList(EventQueue<string> events)
        {
            InitializeComponent();
            EventQueue = events;
            EventQueue.Updated += Events_Updated;
            ReloadEvents();
        }

        public void Events_Updated(object sender, EventArgs e)
        {
            ReloadEvents();
        }

        /// <summary>
        /// Reloads the items in the list box to correspond to the items in the EventQueue&lt;string&gt;.
        /// </summary>
        public void ReloadEvents()
        {
            listBoxEvents.Items.Clear();
            foreach (string e in EventQueue)
            {
                listBoxEvents.Items.Add(e);
            }
            listBoxEvents.SelectedIndex = EventQueue.Count - 1;
        }

        private void EventList_Load(object sender, EventArgs e)
        {
            Program.Events.Enqueue("Loaded events window");
        }

        private void EventList_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
            Program.Events.Enqueue("Closed events window");
        }
    }
}
