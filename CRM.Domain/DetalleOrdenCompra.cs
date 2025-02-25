using CRM.Domain.Common;

namespace CRM.Domain
{
    public class DetalleOrdenCompra : BaseDomainModel
    {

        public int? OrdenCompraId { get; set; }

        public int? ProductoId { get; set; }

        public string? MarcaProducto { get; set; }

        public string? DescripcionProducto { get; set; }

        public string? CategoriaProducto { get; set; }

        public int? Cantidad { get; set; }

        public decimal? Precio { get; set; }

        public decimal? Total { get; set; }

        public virtual OrdenCompra? OrdenCompraNavigatorId { get; set; }
    }
}
