using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApi_PruebaDemo.Models;

public partial class PruebademoContext : DbContext
{
    public PruebademoContext()
    {
    }

    public PruebademoContext(DbContextOptions<PruebademoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Venta> Ventas { get; set; }

    public virtual DbSet<Ventasitem> Ventasitems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-LFTFVP5\\SQLEXPRESS;Initial Catalog=pruebademo;Integrated Security=True;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__clientes__3214EC2711F41545");

            entity.ToTable("clientes");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Cliente1)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Cliente");
            entity.Property(e => e.Correo)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__producto__3214EC27C9FC63BD");

            entity.ToTable("productos");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Categoria)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Venta>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ventas__3214EC273EE29B0D");

            entity.ToTable("ventas");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.Idcliente).HasColumnName("IDCliente");

            entity.HasOne(d => d.IdclienteNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.Idcliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ventas_clientes");
        });

        modelBuilder.Entity<Ventasitem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ventasit__3214EC27D34D9564");

            entity.ToTable("ventasitems");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Idproducto).HasColumnName("IDProducto");
            entity.Property(e => e.Idventa).HasColumnName("IDVenta");

            entity.HasOne(d => d.IdproductoNavigation).WithMany(p => p.Ventasitems)
                .HasForeignKey(d => d.Idproducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ventasitems_productos");

            entity.HasOne(d => d.IdventaNavigation).WithMany(p => p.Ventasitems)
                .HasForeignKey(d => d.Idventa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ventasitems_ventas");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
