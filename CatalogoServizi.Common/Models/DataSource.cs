using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoServizi.Common.Models
{
    /// <summary>
    /// Data Source
    /// </summary>
    /// <typeparam name="T">Type</typeparam>
    public class DataSource<T> where T : new()
    {
        /// <summary>
        /// Data
        /// </summary>
        public List<T> Data { get; set; } = new List<T>();

        /// <summary>
        /// Row Count
        /// </summary>
        public int RowCount { get; set; }
    }
}
