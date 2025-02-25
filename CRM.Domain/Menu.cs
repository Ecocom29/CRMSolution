using CRM.Domain.Common;

namespace CRM.Domain
{
    public class Menu : BaseDomainModel
    {
        public Menu()
        {
            InverseIdMenuPadreNavigation = new HashSet<Menu>();
            RolMenus = new HashSet<RolMenu>();
        }

        public string? Descripcion { get; set; }
        public int? IdMenuPadre { get; set; }
        public string? Icono { get; set; }
        public string? Controlador { get; set; }
        public string? PaginaAccion { get; set; }
        public bool? Status { get; set; } = true;
        public virtual Menu? IdMenuPadreNavigation { get; set; }
        public virtual ICollection<Menu> InverseIdMenuPadreNavigation { get; set; }
        public virtual ICollection<RolMenu> RolMenus { get; set; }
    }
}
