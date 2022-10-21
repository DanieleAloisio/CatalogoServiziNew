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
    /// Ruolo
    /// </summary>
    [Table("Ruolo")]
    public class Ruolo : ITipologica
    {
        /// <summary>
        /// Id 
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Nome ruolo
        /// </summary>
        [Required, MaxLength(256)]
        public string Titolo { get; set; } = string.Empty;

        /// <summary>
        /// Utenti
        /// </summary>
        public ICollection<Utente> Utenti { get; set; } = new List<Utente>();
    }
}
