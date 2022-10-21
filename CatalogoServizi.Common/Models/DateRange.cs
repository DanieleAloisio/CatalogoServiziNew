using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoServizi.Common.Models
{
    /// <summary>
    /// Date Range Interval
    /// </summary>
    public class DateRange
    {
        /// <summary>
        /// From
        /// </summary>
        public DateTime? From { get; set; }

        /// <summary>
        /// To
        /// </summary>
        public DateTime? To { get; set; }

    }
}
