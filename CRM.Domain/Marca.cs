using CRM.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain
{
    public class Marca: BaseDomainModel
    {
        public Marca()
        {
            Productos = new HashSet<Producto>();
        }

        public string? NombreMarca { get; set; }
        public string? Descripcion { get; set; }
        public bool Status { get; set; } = true;
        public virtual ICollection<Producto> Productos { get; set; }
    }
}
