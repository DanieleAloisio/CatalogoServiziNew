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
    /// Tag
    /// </summary>
    [Table("Tag")]
    public class Tag : ITipologica
    {
        /// <summary>
        /// Id
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Nome
        /// </summary>
        [Required, MaxLength(256)]
        public string Titolo { get; set; } = String.Empty;

        /// <summary>
        /// Descrizione
        /// </summary>
        [Required, MaxLength(4096)]
        public string Descrizione { get; set; }=String.Empty;

        /// <summary>
        /// Configurazione email
        /// </summary>
        public virtual ICollection<ConfigurazioneEmail> ConfigurazioneEmail { get; set; }=new List<ConfigurazioneEmail>();  
    }
}
