using CRM.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.Domain
{
    public class Categoria: BaseDomainModel
    {
        public Categoria()
        {
            Productos = new HashSet<Producto>();
        }

        [Column(TypeName = "NVARCHAR(150)")]
        public string? NombreCategoria { get; set; }
        public string? Descripcion { get; set; }
        public bool Status { get; set; } = true;
        public virtual ICollection<Producto>? Productos { get; set; }
    }
}
