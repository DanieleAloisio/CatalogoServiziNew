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
    /// Parametro di sistema
    /// </summary>
    [Table("ConfigurazioneParametro")]
    public class ConfigurazioneParametro
    {
        /// <summary>
        /// Id
        /// </summary>
        [Key]
        public int Id { get; set; }
        
        /// <summary>
        /// Nome parametro
        /// </summary>
        [MaxLength(256)]
        public string Nome { get; set; }=string.Empty;
        
        /// <summary>
        /// Valore
        /// </summary>
        [MaxLength(256)]
        public string Valore { get; set; }= string.Empty;

        /// <summary>
        /// Id autore ultima modifica
        /// </summary>
        public int IdAutoreUltimaModifica { get; set; }

        /// <summary>
        /// Data Ultima modifica
        /// </summary>
        public DateTime DataUltimaModifica { get; set; }

        //Navigazione

        /// <summary>
        /// Autore ultima modifica
        /// </summary>
        [ForeignKey("IdAutoreUltimaModifica")]
        public Utente AutoreUltimaModifica { get; set; } = null!;
    }
}
