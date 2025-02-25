using CRM.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace CRM.Domain
{
    public class Producto: BaseDomainModel
    {
        // El simbolo de interrogacion significa que permite valores nulos.
        // Todas estas propiedades o atributos deben estar igual que en la BD.

        public string? CodigoBarra { get; set; }

        public string? Marca { get; set; }

        public string? Descripcion { get; set; }

        public int? CategoriaId { get; set; }

        public int? Stock { get; set; }

        public string? UrlImagen { get; set; }

        public string? NombreImagen { get; set; }

        public decimal? Precio { get; set; }

        public int? IdMarca { get; set; }

        public bool EsActivo { get; set; }

        public DateTime? FechaRegistro { get; set; }

        public virtual Categoria? IdCategoriaNavigation { get; set; }

        public virtual Marca? IdMarcaNavigation { get; set; }
    }
}
