using CatalogoServizi.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoServizi.Business.Data
{
    /// <summary>
    /// Tipologia di evento
    /// </summary>
    [Table("TipoEvento")]
    public class TipoEvento : ITipologica
    {
        /// <summary>
        /// Chiave
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Titolo
        /// </summary>
        [Required, MaxLength(256)]
        public string Titolo { get; set; } = string.Empty;

    }
}
