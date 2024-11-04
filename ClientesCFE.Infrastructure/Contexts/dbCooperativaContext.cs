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

    public virtual DbSet<Direccion> Direccions { get; set; }

    public virtual DbSet<Genero> Generos { get; set; }

    public virtual DbSet<Telefono> Telefonos { get; set; }

    public virtual DbSet<TipoDocumento> TipoDocumentos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.ClienteId).HasName("PK__Cliente__71ABD0A751B1569D");

            entity.ToTable("Cliente");

            entity.HasIndex(e => new { e.TipoDocumentoId, e.NumeroDocumento }, "UQ_Cliente_Documento").IsUnique();

            entity.Property(e => e.ClienteId).HasColumnName("ClienteID");
            entity.Property(e => e.Apellido1).HasMaxLength(50);
            entity.Property(e => e.Apellido2).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(200);
            entity.Property(e => e.GeneroId)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("GeneroID");
            entity.Property(e => e.Nombres).HasMaxLength(50);
            entity.Property(e => e.TipoDocumentoId).HasColumnName("TipoDocumentoID");

            entity.HasOne(d => d.Genero).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.GeneroId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cliente_Genero");

            entity.HasOne(d => d.TipoDocumento).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.TipoDocumentoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cliente_TipoDocumento");
        });

        modelBuilder.Entity<Direccion>(entity =>
        {
            entity.HasKey(e => e.DireccionId).HasName("PK__Direccio__68906D447794ADF0");

            entity.ToTable("Direccion");

            entity.Property(e => e.DireccionId).HasColumnName("DireccionID");
            entity.Property(e => e.ClienteId).HasColumnName("ClienteID");
            entity.Property(e => e.Descripcion).HasMaxLength(100);
            entity.Property(e => e.Tipo).HasMaxLength(50);

            entity.HasOne(d => d.Cliente).WithMany(p => p.Direccions)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("FK_Direccion_Cliente");
        });

        modelBuilder.Entity<Genero>(entity =>
        {
            entity.HasKey(e => e.GeneroId).HasName("PK__Genero__A99D02686DFE49BF");

            entity.ToTable("Genero");

            entity.Property(e => e.GeneroId)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("GeneroID");
            entity.Property(e => e.Descripcion).HasMaxLength(10);
        });

        modelBuilder.Entity<Telefono>(entity =>
        {
            entity.HasKey(e => e.TelefonoId).HasName("PK__Telefono__A9C6EF36E2A676B4");

            entity.ToTable("Telefono");

            entity.Property(e => e.TelefonoId).HasColumnName("TelefonoID");
            entity.Property(e => e.ClienteId).HasColumnName("ClienteID");
            entity.Property(e => e.Tipo).HasMaxLength(80);

            entity.HasOne(d => d.Cliente).WithMany(p => p.Telefonos)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("FK_Telefono_Cliente");
        });

        modelBuilder.Entity<TipoDocumento>(entity =>
        {
            entity.HasKey(e => e.TipoDocumentoId).HasName("PK__TipoDocu__A329EAA7837ECFC5");

            entity.ToTable("TipoDocumento");

            entity.Property(e => e.TipoDocumentoId).HasColumnName("TipoDocumentoID");
            entity.Property(e => e.Descripcion).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
