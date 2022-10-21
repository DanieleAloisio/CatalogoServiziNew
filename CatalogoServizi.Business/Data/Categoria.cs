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
    /// Categoria Area Intranet
    /// </summary>
    [Table("Categoria")]
    public class Categoria : ITipologica
    {
        /// <summary>
        /// Identificativo categoria
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Nome
        /// </summary>
        [Required,MaxLength(256)]
        public string Titolo { get; set; } = string.Empty;

        /// <summary>
        /// Stato attivo
        /// </summary>
        public bool Attivo { get; set; }


    }
}
