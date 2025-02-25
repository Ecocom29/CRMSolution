using CRM.Domain.Common;

namespace CRM.Domain
{
    public class OrdenCompra: BaseDomainModel
    {
        public OrdenCompra()
        {
            DetalleVenta = new HashSet<DetalleOrdenCompra>();
        }

        public string? NumeroOrdenCompra { get; set; }

        public int? TipoDocumentoOrdenCompraId { get; set; }

        public int? UsuarioId { get; set; }

        public string? DocumentoCliente { get; set; }

        public string? NombreCliente { get; set; }

        public decimal? SubTotal { get; set; }

        public decimal? ImpuestoTotal { get; set; }

        public decimal? Total { get; set; }

        public virtual ICollection<DetalleOrdenCompra> DetalleVenta { get; set; }

        public virtual TipoDocumento? TipoDocumentoNavId { get; set; }

        public virtual Usuario? IdUsuarioNavigation { get; set; }
    }
}
