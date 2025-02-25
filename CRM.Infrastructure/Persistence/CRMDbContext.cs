using CRM.Domain;
using CRM.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace CRM.Infrastructure.Persistence
{
    public class CRMDbContext : DbContext
    {
        public CRMDbContext(DbContextOptions<CRMDbContext> options) : base(options)
        {
            
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var userName = "system";

            foreach (var entry in ChangeTracker.Entries<BaseDomainModel>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = userName;
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = userName;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        public virtual DbSet<Categoria> Categorias { get; set; } 

        public virtual DbSet<Ajustes> Configuracions { get; set; }

        public virtual DbSet<DetalleOrdenCompra> DetalleOrdenCompra { get; set; }

        public virtual DbSet<Menu> Menus { get; set; }

        public virtual DbSet<Negocio> Negocio { get; set; }

        public virtual DbSet<NumeroConsecutivo> NumeroConsecutivo { get; set; }

        public virtual DbSet<Producto> Productos { get; set; }

        public virtual DbSet<Rol> Roles { get; set; }

        public virtual DbSet<RolMenu> RolMenus { get; set; }

        public virtual DbSet<TipoDocumento> TipoDocumento { get; set; }

        public virtual DbSet<Usuario> Usuarios { get; set; }

        public virtual DbSet<OrdenCompra> OrdenCompra { get; set; }

        public virtual DbSet<Marca> Marcas { get; set; }

        public virtual DbSet<Imagen> Imagenes { get; set; }
        public virtual DbSet<Pais> Paises { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }


        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

            builder.Entity<Categoria>()
                .HasMany(p => p.Productos)
                .WithOne(r => r.IdCategoriaNavigation)
                .HasForeignKey(r => r.CategoriaId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Ajustes>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("Ajustes");

                entity.Property(e => e.Propiedad)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("propiedad");
                entity.Property(e => e.Recurso)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("recurso");
                entity.Property(e => e.Valor)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("valor");
            });

            builder.Entity<Menu>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Menu__C26AF48342ADEDD5");

                entity.ToTable("Menu");

                entity.Property(e => e.Id).HasColumnName("idMenu");
                entity.Property(e => e.Controlador)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("controlador");
                entity.Property(e => e.Descripcion)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");
                entity.Property(e => e.Status).HasColumnName("esActivo");
                entity.Property(e => e.CreatedDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime")
                    .HasColumnName("fechaRegistro");
                entity.Property(e => e.Icono)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("icono");
                entity.Property(e => e.IdMenuPadre).HasColumnName("idMenuPadre");
                entity.Property(e => e.PaginaAccion)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("paginaAccion");

                entity.HasOne(d => d.IdMenuPadreNavigation).WithMany(p => p.InverseIdMenuPadreNavigation)
                    .HasForeignKey(d => d.IdMenuPadre)
                    .HasConstraintName("FK__Menu__idMenuPadr__37A5467C");
            });


            builder.Entity<Negocio>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Negocio__70E1E107B347A0CA");

                entity.ToTable("Negocio");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("idNegocio");
                entity.Property(e => e.CorreoElectronico)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("correo");
                entity.Property(e => e.Direccion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("direccion");
                entity.Property(e => e.NombreNegocio)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
                entity.Property(e => e.PorcetanjeImpuesto)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("porcentajeImpuesto");
                entity.Property(e => e.TipoMoneda)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("tipoMoneda");
                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("telefono");
                entity.Property(e => e.UrlLogo)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("urlLogo");
            });

            builder.Entity<NumeroConsecutivo>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__NumeroCo__25FB547E36414AE2");

                entity.ToTable("NumeroCorrelativo");

                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.CantidadDigitos).HasColumnName("cantidadDigitos");
                entity.Property(e => e.LastModifiedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaActualizacion");
                entity.Property(e => e.Gestion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("gestion");
                entity.Property(e => e.UltimoNumero).HasColumnName("ultimoNumero");
            });

            builder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Producto__07F4A132697CEC5A");

                entity.ToTable("Producto");

                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.CodigoBarra)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("codigoBarra");
                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");
                entity.Property(e => e.EsActivo).HasColumnName("esActivo");
                entity.Property(e => e.FechaRegistro)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime")
                    .HasColumnName("fechaRegistro");
                entity.Property(e => e.CategoriaId).HasColumnName("idCategoria");
                entity.Property(e => e.NombreImagen)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombreImagen");
                entity.Property(e => e.Precio)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("precio");
                entity.Property(e => e.Stock).HasColumnName("stock");
                entity.Property(e => e.UrlImagen)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("urlImagen");

                entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Productos)
                    .HasForeignKey(d => d.CategoriaId)
                    .HasConstraintName("FK__Producto__idCate__49C3F6B7");

                entity.HasOne(d => d.IdMarcaNavigation).WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdMarca)
                    .HasConstraintName("FK__Producto__IdMarca");
            });


            builder.Entity<Rol>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Rol__3C872F7677015357");

                entity.ToTable("Rol");

                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.Descripcion)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");
                entity.Property(e => e.Status).HasColumnName("esActivo");
                entity.Property(e => e.CreatedDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime")
                    .HasColumnName("fechaRegistro");
            });

            builder.Entity<RolMenu>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__RolMenu__CD2045D8E0B6BA1B");

                entity.ToTable("RolMenu");

                entity.Property(e => e.Id).HasColumnName("idRolMenu");
                entity.Property(e => e.Status).HasColumnName("esActivo");
                entity.Property(e => e.CreatedDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime")
                    .HasColumnName("fechaRegistro");
                entity.Property(e => e.IdMenu).HasColumnName("idMenu");
                entity.Property(e => e.IdRol).HasColumnName("idRol");

                entity.HasOne(d => d.IdMenuNavigation).WithMany(p => p.RolMenus)
                    .HasForeignKey(d => d.IdMenu)
                    .HasConstraintName("FK__RolMenu__idMenu__3F466844");

                entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.RolMenus)
                    .HasForeignKey(d => d.IdRol)
                    .HasConstraintName("FK__RolMenu__idRol__3E52440B");
            });

            builder.Entity<TipoDocumento>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__TipoDocu__A9D59AEEA40C4B09");

                entity.Property(e => e.Id).HasColumnName("idTipoDocumentoVenta");
                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");
                entity.Property(e => e.Status).HasColumnName("esActivo");
                entity.Property(e => e.CreatedDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime")
                    .HasColumnName("fechaRegistro");
            });

            builder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Usuario__645723A6E3765304");

                entity.ToTable("Usuario");

                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.Contrasenia)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("contrasenia");
                entity.Property(e => e.CorreoElectronico)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("correo");
                entity.Property(e => e.Status).HasColumnName("esActivo");
                entity.Property(e => e.CreatedDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime")
                    .HasColumnName("fechaRegistro");
                entity.Property(e => e.IdRol).HasColumnName("idRol");
                entity.Property(e => e.Nombres)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
                entity.Property(e => e.Apellidos)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombreFoto");
                entity.Property(e => e.NumeroTelefono)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("telefono");
                entity.Property(e => e.UrlImagen)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("urlImagen");

                entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdRol)
                    .HasConstraintName("FK__Usuario__idRol__4316F928");
            });

            builder.Entity<OrdenCompra>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Venta__077D56141980EE0E");

                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.DocumentoCliente)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("documentoCliente");
                entity.Property(e => e.CreatedDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime")
                    .HasColumnName("fechaRegistro");
                entity.Property(e => e.TipoDocumentoOrdenCompraId).HasColumnName("idTipoDocumentoVenta");
                entity.Property(e => e.IdUsuarioNavigation).HasColumnName("idUsuario");
                entity.Property(e => e.ImpuestoTotal)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("impuestoTotal");
                entity.Property(e => e.NombreCliente)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("nombreCliente");
                entity.Property(e => e.NumeroOrdenCompra)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("numeroVenta");
                entity.Property(e => e.SubTotal)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("subTotal");
                entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.TipoDocumentoNavId).WithMany(p => p.OrdenCompra)
                    .HasForeignKey(d => d.TipoDocumentoOrdenCompraId)
                    .HasConstraintName("FK__Venta__idTipoDoc__52593CB8");

                entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.OrdenCompra)
                    .HasForeignKey(d => d.Id)
                    .HasConstraintName("FK__Venta__idUsuario__534D60F1");
            });            
        }
    }
}
