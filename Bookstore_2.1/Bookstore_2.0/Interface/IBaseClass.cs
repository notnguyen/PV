using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore_2._0.Interface
{
    /// <summary>
    /// Represents the base interface for classes that have an integer identifier (ID).
    /// </summary>
    public interface IBaseClass
    {
        /// <summary>
        /// Gets or sets the unique identifier of the class.
        /// </summary>
        int ID { get; set; }
    }
}
