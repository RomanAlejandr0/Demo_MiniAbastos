using Demo_MiniAbastos.Shared.Catalogos;
using Demo_MiniAbastos.Shared.Catologos;
using Microsoft.EntityFrameworkCore;
namespace Demo_MiniAbastos.Shared.AccesoDatos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Producto> DemoMiniabastos_Carrito { get; set; }
        public DbSet<Ubicacion> DemoMiniabastos_Ubicaciones { get; set; }
        public DbSet<CuentaBanco> DemoMiniabastos_CuentasBanco { get; set; }
        public DbSet<Venta_DemoMiniabastos> DemoMiniabastos_Ventas { get; set; }

        public DbSet<Domicilio> DemoMiniabastos_Domicilios { get; set; }

        public DbSet<Estados> Catalogo_Estados { get; set; }
        public DbSet<Localidades> Catalogo_Localidades { get; set; }
        public DbSet<Municipios> Catalogo_Municipios { get; set; }
        public DbSet<Colonias> Catalogo_Colonias { get; set; }
        public DbSet<CodigosPostales> Catalogo_CodigosPostales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Producto>().Ignore(x => x.Marca);
            modelBuilder.Entity<Producto>().Ignore(x => x.CantidadEmpaques);
            modelBuilder.Entity<Producto>().Ignore(x => x.NombreSegundoEmpaque);
            modelBuilder.Entity<Producto>().Ignore(x => x.NombreTercerEmpaque);
            modelBuilder.Entity<Producto>().Ignore(x => x.CantidadProductoSegundoEmpaque);
            modelBuilder.Entity<Producto>().Ignore(x => x.CantidadProductoTercerEmpaque);
            modelBuilder.Entity<Producto>().Ignore(x => x.TienePromocion);
            modelBuilder.Entity<Producto>().Ignore(x => x.PrecioIndividualPromocion);
            modelBuilder.Entity<Producto>().Ignore(x => x.PrecioIndividual);
            modelBuilder.Entity<Producto>().Ignore(x => x.PrecioSegundoEmpaque);
            modelBuilder.Entity<Producto>().Ignore(x => x.PrecioTercerEmpaque);
            modelBuilder.Entity<Producto>().Ignore(x => x.EmpaqueSeleccionado);

            modelBuilder.Entity<CodigosPostales>().Ignore(u => u.Estado);
            modelBuilder.Entity<CodigosPostales>().Ignore(u => u.Localidad);
            modelBuilder.Entity<CodigosPostales>().Ignore(u => u.Municipio);
            modelBuilder.Entity<CodigosPostales>().Ignore(u => u.Colonias);
            
            modelBuilder.Entity<Domicilio>().Ignore(u => u.NombreDomicilio);
        }
    }
}
