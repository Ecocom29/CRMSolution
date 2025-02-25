using CRM.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.Domain
{
    public class Imagen: BaseDomainModel
    {
        [Column(TypeName = "NVARCHAR(4000)")]
        public string? ImagenURL { get; set; }
        public int ProductoId { get; set; }
        public string? CodigoPublico { get; set; }
        public bool Status { get; set; } = true;
        public virtual ICollection<Producto>? Productos { get; set; }
    }
}
