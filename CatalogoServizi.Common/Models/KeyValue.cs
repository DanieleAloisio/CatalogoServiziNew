using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoServizi.Common.Models
{
    /// <summary>
    /// Chiave valore
    /// </summary>
    /// <typeparam name="TKey">Tipo Chiave</typeparam>
    /// <typeparam name="TValue">Tipo valore</typeparam>
    public class KeyValue<TKey, TValue> 
    {
        /// <summary>
        /// Chiave
        /// </summary>
        public TKey? Key { get; set; }

        /// <summary>
        /// Valore
        /// </summary>
        public TValue? Value { get; set; }
    }
}
