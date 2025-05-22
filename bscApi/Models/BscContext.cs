using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace bscApi.Models;

public partial class BscContext : DbContext
{
    public BscContext()
    {
    }

    public BscContext(DbContextOptions<BscContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CatEstatusPedido> CatEstatusPedidos { get; set; }

    public virtual DbSet<CatEstatusUsuario> CatEstatusUsuarios { get; set; }

    public virtual DbSet<CategoriaProducto> CategoriaProductos { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<Perfile> Perfiles { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<ProductoPedido> ProductoPedidos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CatEstatusPedido>(entity =>
        {
            entity.HasKey(e => e.IdEstatusPedidos).HasName("PK__cat_esta__A855B05D52DD310E");

            entity.ToTable("cat_estatus_pedidos");

            entity.Property(e => e.IdEstatusPedidos).HasColumnName("id_estatus_pedidos");
            entity.Property(e => e.EstatusPedidos)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("estatus_pedidos");
        });

        modelBuilder.Entity<CatEstatusUsuario>(entity =>
        {
            entity.HasKey(e => e.IdEstatusUsuario).HasName("PK__cat_esta__0630AC9039F3D1BC");

            entity.ToTable("cat_estatus_usuarios");

            entity.Property(e => e.IdEstatusUsuario).HasColumnName("id_estatus_usuario");
            entity.Property(e => e.EstatusUsuarios)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("estatus_usuarios");
        });

        modelBuilder.Entity<CategoriaProducto>(entity =>
        {
            entity.HasKey(e => e.IdCategoriaProducto).HasName("PK__categori__876435019E012D7B");

            entity.ToTable("categoria_productos");

            entity.Property(e => e.IdCategoriaProducto).HasColumnName("id_categoria_producto");
            entity.Property(e => e.CategoriaProducto1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("categoria_producto");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__clientes__677F38F504EC0367");

            entity.ToTable("clientes");

            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.IdPersona).HasColumnName("id_persona");

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.IdPersona)
                .HasConstraintName("FK__clientes__id_per__5FB337D6");
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.IdPedido).HasName("PK__pedidos__6FF01489A5AF524F");

            entity.ToTable("pedidos");

            entity.Property(e => e.IdPedido).HasColumnName("id_pedido");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.IdEstatusPedido).HasColumnName("id_estatus_pedido");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.PrecioTotal)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precio_total");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK__pedidos__id_clie__68487DD7");

            entity.HasOne(d => d.IdEstatusPedidoNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.IdEstatusPedido)
                .HasConstraintName("FK__pedidos__id_esta__693CA210");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__pedidos__id_usua__6754599E");
        });

        modelBuilder.Entity<Perfile>(entity =>
        {
            entity.HasKey(e => e.IdPerfil).HasName("PK__perfiles__1D1C8768F972D4F4");

            entity.ToTable("perfiles");

            entity.Property(e => e.IdPerfil).HasColumnName("id_perfil");
            entity.Property(e => e.Perfil)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("perfil");
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.IdPersona).HasName("PK__persona__228148B0EAFB6EDA");

            entity.ToTable("persona");

            entity.Property(e => e.IdPersona).HasColumnName("id_persona");
            entity.Property(e => e.AMaterno)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("a_materno");
            entity.Property(e => e.APaterno)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("a_paterno");
            entity.Property(e => e.Contrasenia)
               .HasMaxLength(100)
               .IsUnicode(false)
               .HasColumnName("contrasenia");
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.Domicilio)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("domicilio");
            entity.Property(e => e.FCreacion)
                .HasColumnType("datetime")
                .HasColumnName("f_creacion");
            entity.Property(e => e.FModifico)
                .HasColumnType("datetime")
                .HasColumnName("f_modifico");
            entity.Property(e => e.FNacimiento)
                .HasColumnType("datetime")
                .HasColumnName("f_nacimiento");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK__producto__FF341C0D6ACA38DE");

            entity.ToTable("productos");

            entity.Property(e => e.IdProducto).HasColumnName("id_producto");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.IdCategoriaProducto).HasColumnName("id_categoria_producto");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precio");
            entity.Property(e => e.Producto1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("producto");

            entity.HasOne(d => d.IdCategoriaProductoNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdCategoriaProducto)
                .HasConstraintName("FK__productos__id_ca__5AEE82B9");
        });

        modelBuilder.Entity<ProductoPedido>(entity =>
        {
            entity.HasKey(e => e.IdProductoPedido).HasName("PK__producto__878B1FAF0F418A83");

            entity.ToTable("producto_pedido");

            entity.Property(e => e.IdProductoPedido).HasColumnName("id_producto_pedido");
            entity.Property(e => e.IdPedido).HasColumnName("id_pedido");
            entity.Property(e => e.IdProducto).HasColumnName("id_producto");

            entity.HasOne(d => d.IdPedidoNavigation).WithMany(p => p.ProductoPedidos)
                .HasForeignKey(d => d.IdPedido)
                .HasConstraintName("FK__producto___id_pe__6D0D32F4");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.ProductoPedidos)
                .HasForeignKey(d => d.IdProducto)
                .HasConstraintName("FK__producto___id_pr__6C190EBB");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__usuarios__4E3E04ADF74BECDF");

            entity.ToTable("usuarios");

            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.IdEstatusUsuario).HasColumnName("id_estatus_usuario");
            entity.Property(e => e.IdPerfil).HasColumnName("id_perfil");
            entity.Property(e => e.IdPersona).HasColumnName("id_persona");

            entity.HasOne(d => d.IdEstatusUsuarioNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdEstatusUsuario)
                .HasConstraintName("FK__usuarios__id_est__6477ECF3");

            entity.HasOne(d => d.IdPerfilNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdPerfil)
                .HasConstraintName("FK__usuarios__id_per__6383C8BA");

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdPersona)
                .HasConstraintName("FK__usuarios__id_per__628FA481");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
