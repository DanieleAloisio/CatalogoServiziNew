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
    /// Configurazione email
    /// </summary>
    [Table("ConfigurazioneEmail")]
    public class ConfigurazioneEmail
    {
        /// <summary>
        /// Id
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Id Tipo evento
        /// </summary>
        public int IdTipoEvento { get; set; }

        /// <summary>
        /// Autore modifica
        /// </summary>
        public int IdAutoreModifica { get; set; }

        /// <summary>
        /// Oggetto della email
        /// </summary>
        [Required, MaxLength(256)]
        public string Oggetto { get; set; } = String.Empty;

        /// <summary>
        /// Testo della email
        /// </summary>
        [Required, MaxLength(4096)]
        public string Testo { get; set; } = String.Empty;

        /// <summary>
        /// Data ultima modifica
        /// </summary>
        [Required]
        public DateTime DataUltimaModifica { get; set; }

        /// <summary>
        /// Tipo di Email attiva. Se disattivato l'email di questo tipo non viene inviata
        /// </summary>
        public bool IsAttivo { get; set; }

        /// <summary>
        /// Configurazione Cancellata
        /// </summary>
        public bool Canc { get; set; }


        //Navigazione

        /// <summary>
        /// Tipo di evento
        /// </summary>
        [ForeignKey("IdTipoEvento")]
        public virtual TipoEvento TipoEvento { get; set; } = null!;

        /// <summary>
        /// Autore modifica
        /// </summary>
        [ForeignKey("IdAutoreModifica")]
        public Utente AutoreModifica { get; set; } = null!;

        /// <summary>
        /// Elenco TAG associati
        /// </summary>
        public virtual ICollection<Tag> Tag { get; set; } = new List<Tag>();

        /// <summary>
        /// Destinatari
        /// </summary>
        public virtual ICollection<Destinatario> Destinatario { get; set; } = new List<Destinatario>();

        /// <summary>
        /// Lista email storico
        /// </summary>
        public virtual ICollection<StoricoEmail> StoricoEmail { get; set; } = new List<StoricoEmail>();

    }
}
