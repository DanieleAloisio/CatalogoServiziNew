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
    /// Utente
    /// </summary>
    [Table("Utente")]
    public class Utente
    {
        /// <summary>
        /// Id
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Account rete
        /// </summary>
        [Required, MaxLength(256)]
        public string AccountRete { get; set; } = string.Empty;

        /// <summary>
        /// Nome utente
        /// </summary>
        [Required, MaxLength(256)]
        public string Nome { get; set; } = string.Empty;

        /// <summary>
        /// Cognome
        /// </summary>
        [Required, MaxLength(256)]
        public string Cognome { get; set; } = string.Empty;

        /// <summary>
        /// Email
        /// </summary>
        [Required, MaxLength(512)]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Data Creazione
        /// </summary>
        public DateTime DataCreazione { get; set; }

        /// <summary>
        /// Utente cancellato
        /// </summary>
        public bool Canc { get; set; }

        /// <summary>
        /// Ruoli utente
        /// </summary>
        public virtual ICollection<Ruolo> Ruoli { get; set; } = new List<Ruolo>();

    }
}
