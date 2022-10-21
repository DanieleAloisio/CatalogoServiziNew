using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoServizi.Business.Data
{
    /// <summary>
    /// Area Intranet
    /// </summary>
    [Table("AreaIntranet")]
    public class AreaIntranet
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Id Categoria
        /// </summary>
        public int IdCategoria { get; set; }

        /// <summary>
        /// Nome
        /// </summary>
        public string Nome { get; set; }=String.Empty;

        /// <summary>
        /// Attiva
        /// </summary>
        public bool Attiva { get; set; }

        /// <summary>
        /// Categoria di appartenenza
        /// </summary>

        public virtual Categoria Categoria { get; set; } = null!;
    }
}
