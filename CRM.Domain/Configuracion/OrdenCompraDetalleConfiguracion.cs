using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRM.Domain.Configuracion
{
    public class OrdenCompraDetalleConfiguracion : IEntityTypeConfiguration<DetalleOrdenCompra>
    {
        public void Configure(EntityTypeBuilder<DetalleOrdenCompra> builder)
        {
            builder.Property(x=>x.Precio).HasColumnType("decimal(10,2)");
        }
    }
}
