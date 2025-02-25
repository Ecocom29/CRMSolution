using CRM.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain
{
    public class RolMenu: BaseDomainModel
    {
        public int? IdRol { get; set; }
        public int? IdMenu { get; set; }
        public bool? Status { get; set; } = true;
        public virtual Menu? IdMenuNavigation { get; set; }
        public virtual Rol? IdRolNavigation { get; set; }
    }
}
