using CatalogoServizi.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoServizi.Business.Dto.ConfigurazioneEmail
{
    public class ConfigurazioneEmailInput : DataFilter
    {
        public DateTime DataUltimaModifica { get; set; }

        public bool IsAttivo { get; set; }

        public bool Canc { get; set; }
    }
}
