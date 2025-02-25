using CRM.Domain.Common;

namespace CRM.Domain
{
    public class Usuario: BaseDomainModel
    {
        public Usuario()
        {
            OrdenCompra = new HashSet<OrdenCompra>();
        }

        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }

        public string? CorreoElectronico { get; set; }
        public string? Contrasenia { get; set; }
        public string? UserName { get; set; }

        public string? NumeroTelefono { get; set; }

        public int? IdRol { get; set; }

        public string? UrlImagen { get; set; }

        public bool? Status { get; set; } = true;


        public virtual Rol? IdRolNavigation { get; set; }

        public virtual ICollection<OrdenCompra> OrdenCompra { get; set; }
    }
}
