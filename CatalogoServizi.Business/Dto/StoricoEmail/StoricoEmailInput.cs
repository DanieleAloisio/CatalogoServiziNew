using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatalogoServizi.Common.Models;

namespace CatalogoServizi.Business.Dto.StoricoEmail
{
    public class StoricoEmailInput : DataFilter
    {
        public int Id { get; set; }
        public string TipoEvento { get; set; }
        public string Destinatario { get; set; }
        public DateTime DataInizio { get; set; }
        public DateTime DataFine { get; set; }
        public bool Esito { get; set; }
    }
}
