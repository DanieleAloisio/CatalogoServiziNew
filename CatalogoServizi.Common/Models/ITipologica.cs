using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoServizi.Common.Models
{
    /// <summary>
    /// Interfaccia oggetto tipologico
    /// </summary>
    public interface ITipologica
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Titolo
        /// </summary>
        public string Titolo { get; set; }
    }
}
