using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoServizi.Business.Dto
{
    public class StoricoDestinatarioDto
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public int IdTipoDestinatario { get; set; }

        public int IdStoricoEmail { get; set; }

    }
}
