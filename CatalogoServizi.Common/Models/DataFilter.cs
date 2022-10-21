using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoServizi.Common.Models
{



    /// <summary>
    /// Base Filter
    /// </summary>
    public class DataFilter
    {
        /// <summary>
        /// Offset
        /// </summary>
        public int Offset { get; set; } = 0;

        /// <summary>
        /// Limit
        /// </summary>
        public int Limit { get; set; } = 10;

        /// <summary>
        /// Sorting rule
        /// </summary>
        public string? SortBy { get; set; } = string.Empty;
    }
}
