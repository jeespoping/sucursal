using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ProyectoSucursal.Models;

namespace ProyectoSucursal.DAL.DataContext;

public partial class SucursalContext : DbContext
{
    public SucursalContext()
    {
    }

    public SucursalContext(DbContextOptions<SucursalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Asignacion> Asignacions { get; set; }

    public virtual DbSet<Elemento> Elementos { get; set; }

    public virtual DbSet<Sucursal> Sucursals { get; set; }

    public virtual DbSet<Tecnico> Tecnicos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(local); DataBase=SUCURSAL;Integrated Security=true; TrustServerCertificate=true; MultipleActiveResultSets=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Asignacion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ASIGNACI__3213E83F661CB586");

            entity.ToTable("ASIGNACION");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdElemento).HasColumnName("idElemento");
            entity.Property(e => e.IdTecnico).HasColumnName("idTecnico");
            entity.Property(e => e.Cantidad)
                .HasColumnName("cantidad");

            entity.HasOne(d => d.IdElementoNavigation).WithMany(p => p.Asignacions)
                .HasForeignKey(d => d.IdElemento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ASIGNACIO__idEle__4E88ABD4");

            entity.HasOne(d => d.IdTecnicoNavigation).WithMany(p => p.Asignacions)
                .HasForeignKey(d => d.IdTecnico)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ASIGNACIO__idTec__4F7CD00D");
        });

        modelBuilder.Entity<Elemento>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK__ELEMENTO__40F9A207411FD16F");

            entity.ToTable("ELEMENTO");

            entity.Property(e => e.Codigo).HasColumnName("codigo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Sucursal>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK__SUCURSAL__06370DAD8A254815");

            entity.ToTable("SUCURSAL");

            entity.Property(e => e.Nombre)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
        });

        modelBuilder.Entity<Tecnico>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TECNICO__3213E83F6C032FEF");

            entity.ToTable("TECNICO");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Codigo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("codigo");
            entity.Property(e => e.IdSucursal).HasColumnName("idSucursal");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.SueldoBase)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("sueldoBase");

            entity.HasOne(d => d.IdSucursalNavigation).WithMany(p => p.Tecnicos)
                .HasForeignKey(d => d.IdSucursal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TECNICO__idSucur__4BAC3F29");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
