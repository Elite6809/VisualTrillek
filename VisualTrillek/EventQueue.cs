using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualTrillek
{
    /// <summary>
    /// Represents a first-in, first-out collection of objects that fires an event whenever the contents are modified.
    /// </summary>
    /// <typeparam name="T">Specifies the type of elements in the queue.</typeparam>
    public class EventQueue<T> : Queue<T>
    {
        /// <summary>
        /// Fired whenever items are enqueued or dequeued.
        /// </summary>
        public event EventHandler Updated;

        /// <summary>
        /// The maximum number of items in this EventQueue, or 0 if there is no limit.
        /// </summary>
        public int CountLimit
        {
            get;
            protected set;
        }

        /// <summary>
        /// Initializes a new instance of the EventQueue&lt;T&gt; class
        /// that is empty and has the default initial capacity and limit.
        /// </summary>
        public EventQueue()
            : base()
        {
            CountLimit = 0;
        }

        /// <summary>
        /// Initializes a new instance of the EventQueue&lt;T&gt; class
        /// that is empty and has the default initial capacity and the specified limit.
        /// <param name="sizeLimit">The maximum number of items that can be contained in the EventQueue.</param>
        /// </summary>
        public EventQueue(int sizeLimit)
            : base()
        {
            CountLimit = sizeLimit;
        }

        /// <summary>
        /// Adds an object to the end of the EventQueue&lt;T&gt;.
        /// Any registered events are fired.
        /// </summary>
        /// <param name="item">The object to add to the EventQueue&lt;T&gt;. The value can be null for reference types.</param>
        public new void Enqueue(T item)
        {
            base.Enqueue(item);
            if (Count > CountLimit && CountLimit != 0)
                base.Dequeue();
            Update();
        }

        /// <summary>
        /// Removes and returns the object at the beginning of the EventQueue&lt;T&gt;.
        /// </summary>
        /// <returns>The object that is removed from the beginning of the EventQueue&lt;T&gt;.</returns>
        public new T Dequeue()
        {
            T item = base.Dequeue();
            Update();
            return item;
        }

        /// <summary>
        /// Fires event handlers to signal that this EventQueue has been updated.
        /// This event is thread-safe and checks for nulls.
        /// </summary>
        protected void Update()
        {
            EventHandler handler = Updated;
            if (handler != null)
                handler(this, new EventArgs());
        }
    }
}
