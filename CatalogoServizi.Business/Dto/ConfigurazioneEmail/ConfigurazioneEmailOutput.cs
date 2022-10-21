using CatalogoServizi.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoServizi.Business.Dto.ConfigurazioneEmail
{
    public class ConfigurazioneEmailOutput
    {
        public int IdAutoreUltimaModifica { get; set; }

        public string Oggetto { get; set; }

        public string Testo { get; set; }

        public DateTime DataUltimaModifica { get; set; }

        public bool IsAttivo { get; set; }

        public string TipoEvento { get; set; }
        public int? CountMessage { get; set; }
    }
}
