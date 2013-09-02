using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualTrillek
{
    /// <summary>
    /// Represents an object which has a custom ToString() method.
    /// </summary>
    /// <typeparam name="T">The type of value to contain.</typeparam>
    public class StringContainer<T>
    {
        /// <summary>
        /// Gets or sets the contained value.
        /// </summary>
        public T Value
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the string representation.
        /// </summary>
        public string String
        {
            get;
            set;
        }

        /// <summary>
        /// Create a new string container for a <typeparamref name="T"/>.
        /// </summary>
        /// <param name="value">The contained value.</param>
        /// <param name="s">The string representation.</param>
        public StringContainer(T value, string s)
        {
            Value = value;
            String = s;
        }

        /// <summary>
        /// Convert this StringContainer&lt;<typeparamref name="T"/>&gt; to a <typeparamref name="T"/>.
        /// Equivalent to the StringContainer&lt;<typeparamref name="T"/>&gt;'s Value property.
        /// </summary>
        /// <param name="container">The container to convert from.</param>
        /// <returns>The <typeparamref name="T"/> representation of this StringContainer&lt;<typeparamref name="T"/>&gt;.</returns>
        public static implicit operator T(StringContainer<T> container)
        {
            return container.Value;
        }

        /// <summary>
        /// Gets this StringContainer&lt;<typeparamref name="T"/>&gt;'s string representation.
        /// Equivalent to the String property.
        /// </summary>
        /// <returns>This StringContainer&lt;<typeparamref name="T"/>&gt;'s string representation.</returns>
        public override string ToString()
        {
            return String;
        }
    }
}
