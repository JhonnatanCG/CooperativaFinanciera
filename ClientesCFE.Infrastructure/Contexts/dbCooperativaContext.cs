using CooperativaFinanciera.Domain;
using Microsoft.EntityFrameworkCore;

namespace CooperativaFinanciera.Infrastructure.Contexts;

public partial class dbCooperativaContext : DbContext
{
    public dbCooperativaContext()
    {
    }

    public dbCooperativaContext(DbContextOptions<dbCooperativaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Direcciones> Direcciones { get; set; }

    public virtual DbSet<Telefono> Telefonos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>()
           .HasIndex(c => new { c.TipoDocumento, c.NumeroDocumento })
           .IsUnique();

        modelBuilder.Entity<Cliente>()
            .HasMany(c => c.Direcciones)
            .WithOne(d => d.Cliente)
            .HasForeignKey(d => d.CodigoCliente)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Cliente>()
            .HasMany(c => c.Telefonos)
            .WithOne(t => t.Cliente)
            .HasForeignKey(t => t.CodigoCliente)
            .OnDelete(DeleteBehavior.Cascade);

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
