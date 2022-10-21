using CatalogoServizi.Business.Data;
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
    /// Log di sistema
    /// </summary>
    [Table("Log")]
    public class Log
    {
        /// <summary>
        /// Chiave
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Tipo evento su cui è avvenuto l'evento/eccezione
        /// </summary>
        public int? IdTipo { get; set; }

        /// <summary>
        /// Id utente
        /// </summary>
        public int? IdUtente { get; set; }

        /// <summary>
        /// Data evento
        /// </summary>
        public DateTime DataEvento { get; set; }

        /// <summary>
        /// Dati di ingresso
        /// </summary>
        public string InputData { get; set; } = string.Empty;

        /// <summary>
        /// Distingue tra evento ed errore
        /// </summary>
        public bool IsError { get; set; } = false;

        /// <summary>
        /// Messaggio
        /// </summary>
        [MaxLength(4096)]
        public string Messaggio { get; set; } = String.Empty;

        /// <summary>
        /// Stack trace in caso di errore
        /// </summary>
        public string StackTrace { get; set; } = String.Empty;

        /// <summary>
        /// Identificativo utente
        /// </summary>
        [ForeignKey("IdUtente")]
        public virtual Utente Utente { get; set; } = null!;

        /// <summary>
        /// Tipo evento
        /// </summary>
        [ForeignKey("IdTipo")]
        public virtual TipoEvento Tipo { get; set; } = null!;
    }
}
