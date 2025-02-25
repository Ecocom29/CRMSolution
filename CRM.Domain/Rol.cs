using CRM.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain
{
    public class Rol: BaseDomainModel
    {
        public string? Descripcion { get; set; }
        public bool? Status { get; set; } = true;
        public virtual ICollection<RolMenu>? RolMenus { get; set; }

        public virtual ICollection<Usuario>? Usuarios { get; set; }
    }
}
