using CRM.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain
{
    public class NumeroConsecutivo: BaseDomainModel
    {
        public int? UltimoNumero { get; set; }
        public int? CantidadDigitos { get; set; }
        public string? Gestion { get; set; }
    }
}
