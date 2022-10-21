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
    /// Storico destinatario
    /// </summary>
    [Table("StoricoDestinatario")]
    public class StoricoDestinatario
    {
        /// <summary>
        /// Id
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [Required, MaxLength(256)]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Id tipo destinatario
        /// </summary>
        public int IdTipoDestinatario { get; set; }

        /// <summary>
        /// Id Storico email
        /// </summary>
        public int IdStoricoEmail { get; set; }

        /// <summary>
        /// Storico email
        /// </summary>
        [ForeignKey("IdStoricoEmail")]
        public virtual StoricoEmail StoricoEmail { get; set; } = null!;

        /// <summary>
        /// Tipo destinatario
        /// </summary>
        [ForeignKey("IdTipoDestinatario")]
        public virtual TipoDestinatario TipoDestinatario { get; set; } = null!;
    }
}
