using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualTrillek
{
    /// <summary>
    /// Represents a type of textual search.
    /// </summary>
    public enum SearchType
    {
        /// <summary>
        /// Represents the state in which a search has not happened.
        /// </summary>
        None,
        /// <summary>
        /// Represents a forward search.
        /// </summary>
        Forward,
        /// <summary>
        /// Represents a backward search.
        /// </summary>
        Backward
    }
}
