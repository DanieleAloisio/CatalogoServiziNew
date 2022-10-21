using CatalogoServizi.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoServizi.Business.Data
{
    /// <summary>
    /// Tipo destinatario
    /// </summary>
    public class TipoDestinatario:ITipologica
    {
        /// <summary>
        /// Id
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Titolo
        /// </summary>
        [Required, MaxLength(256)]
        public string Titolo { get; set; }=String.Empty;


    }
}
