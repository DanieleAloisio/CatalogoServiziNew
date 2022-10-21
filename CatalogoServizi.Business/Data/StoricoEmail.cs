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
    /// Storico email
    /// </summary>
    [Table("StoricoEmail")]
    public class StoricoEmail
    {
        /// <summary>
        /// Id
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Id configurazione
        /// </summary>
        public int IdConfigurazione { get; set; }

        /// <summary>
        /// Oggetto
        /// </summary>
        [Required, MaxLength(256)]
        public string Oggetto { get; set; } = string.Empty;

        /// <summary>
        /// Testo
        /// </summary>
        [Required, MaxLength(4096)]
        public string Testo { get; set; } = string.Empty;

        /// <summary>
        /// Data invio
        /// </summary>
        [Required]
        public DateTime DataInvio { get; set; }

        /// <summary>
        /// Indica se l'invio è andato correttamente
        /// </summary>
        [Required, MaxLength(256)]
        public bool InvioCorretto { get; set; }

        /// <summary>
        /// Messaggio in caso di errore
        /// </summary>
        public string MessaggioErrore { get; set; } = string.Empty;

        /// <summary>
        /// Configurazione email
        /// </summary>
        [ForeignKey("IdConfigurazione")]
        public virtual ConfigurazioneEmail ConfigurazioneEmail { get; set; } = null!;

        /// <summary>
        /// Destinatari
        /// </summary>
        public virtual ICollection<StoricoDestinatario> StoricoDestinatario { get; set; } = new List<StoricoDestinatario>();


    }
}
