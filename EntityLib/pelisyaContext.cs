using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace EntityLib
{
    public partial class pelisyaContext : DbContext
    {
        public pelisyaContext()
        {
        }

        public pelisyaContext(DbContextOptions<pelisyaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categoriacontenido> Categoriacontenido { get; set; } = null!;
        public virtual DbSet<Categoriasusuarios> Categoriasusuarios { get; set; } = null!;
        public virtual DbSet<Estadofactura> Estadofactura { get; set; } = null!;
        public virtual DbSet<Facturasporcobrar> Facturasporcobrar { get; set; } = null!;
        public virtual DbSet<Listas> Listas { get; set; } = null!;
        public virtual DbSet<Peliculas> Peliculas { get; set; } = null!;
        public virtual DbSet<Series> Series { get; set; } = null!;
        public virtual DbSet<Subcategorias> Subcategorias { get; set; } = null!;
        public virtual DbSet<Usuarios> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //Buscamos el archivo .json
                var _config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("settings.json", optional: true, reloadOnChange: true);

                //usamos la conectionstring que esta guardada en el avariable ConnectionStringDesarrollo
                IConfiguration configuration = _config.Build();
                optionsBuilder.UseMySql(
                    configuration["ConnectionStringDesarrollo"], new MySqlServerVersion(new Version(8, 0, 23))
                );
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8_general_ci")
                .HasCharSet("utf8");

            modelBuilder.Entity<Categoriacontenido>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("PRIMARY");

                entity.ToTable("categoriacontenido");

                entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");

                entity.Property(e => e.Descripcion).HasMaxLength(100);
            });

            modelBuilder.Entity<Categoriasusuarios>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("PRIMARY");

                entity.ToTable("categoriasusuarios");

                entity.Property(e => e.IdCategoria).HasColumnName("id_categoria");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(20)
                    .HasColumnName("descripcion");
            });

            modelBuilder.Entity<Estadofactura>(entity =>
            {
                entity.HasKey(e => e.IdEstado)
                    .HasName("PRIMARY");

                entity.ToTable("estadofactura");

                entity.Property(e => e.IdEstado).HasColumnName("Id_Estado");

                entity.Property(e => e.Descripcion).HasMaxLength(100);
            });

            modelBuilder.Entity<Facturasporcobrar>(entity =>
            {
                entity.HasKey(e => e.IdFactura)
                    .HasName("PRIMARY");

                entity.ToTable("facturasporcobrar");

                entity.HasIndex(e => e.IdEstado, "FacturasPorCobrar_FK");

                entity.HasIndex(e => e.IdUsuario, "FacturasPorCobrar_FK_1");

                entity.Property(e => e.IdFactura).HasColumnName("Id_Factura");

                entity.Property(e => e.IdEstado).HasColumnName("Id_Estado");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.Monto).HasPrecision(10);

                entity.Property(e => e.MontoTax)
                    .HasPrecision(10)
                    .HasColumnName("MontoTAX");

                entity.Property(e => e.MontoTotal).HasPrecision(10);

                entity.Property(e => e.Periodo).HasMaxLength(100);

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.Facturasporcobrar)
                    .HasForeignKey(d => d.IdEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FacturasPorCobrar_FK");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Facturasporcobrar)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FacturasPorCobrar_FK_1");
            });

            modelBuilder.Entity<Listas>(entity =>
            {
                entity.HasKey(e => e.IdLista)
                    .HasName("PRIMARY");

                entity.ToTable("listas");

                entity.HasIndex(e => e.IdSerie, "listas_FK");

                entity.HasIndex(e => e.IdPelicula, "listas_FK_1");

                entity.HasIndex(e => e.IdUsuario, "listas_FK_2");

                entity.Property(e => e.IdLista).HasColumnName("Id_Lista");

                entity.Property(e => e.IdPelicula).HasColumnName("Id_Pelicula");

                entity.Property(e => e.IdSerie).HasColumnName("Id_Serie");

                entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");

                entity.HasOne(d => d.IdPeliculaNavigation)
                    .WithMany(p => p.Listas)
                    .HasForeignKey(d => d.IdPelicula)
                    .HasConstraintName("listas_FK_1");

                entity.HasOne(d => d.IdSerieNavigation)
                    .WithMany(p => p.Listas)
                    .HasForeignKey(d => d.IdSerie)
                    .HasConstraintName("listas_FK");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Listas)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("listas_FK_2");
            });

            modelBuilder.Entity<Peliculas>(entity =>
            {
                entity.HasKey(e => e.IdPelicula)
                    .HasName("PRIMARY");

                entity.ToTable("peliculas");

                entity.HasIndex(e => e.IdCategoriaPeliculas, "peliculas_FK");

                entity.Property(e => e.IdPelicula).HasColumnName("Id_Pelicula");

                entity.Property(e => e.ActorPrincipal).HasMaxLength(100);

                entity.Property(e => e.ActorPrincipal2).HasMaxLength(100);

                entity.Property(e => e.ActorSecundario).HasMaxLength(100);

                entity.Property(e => e.ActorSecundario2).HasMaxLength(100);

                entity.Property(e => e.Descripcion).HasMaxLength(500);

                entity.Property(e => e.Fecha).HasColumnName("fecha");

                entity.Property(e => e.Nombre).HasMaxLength(200);

                entity.HasOne(d => d.IdCategoriaPeliculasNavigation)
                    .WithMany(p => p.Peliculas)
                    .HasForeignKey(d => d.IdCategoriaPeliculas)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("peliculas_FK");
            });

            modelBuilder.Entity<Series>(entity =>
            {
                entity.HasKey(e => e.IdSerie)
                    .HasName("PRIMARY");

                entity.ToTable("series");

                entity.HasIndex(e => e.IdCategoriaSeries, "series_FK");

                entity.Property(e => e.IdSerie).HasColumnName("Id_Serie");

                entity.Property(e => e.ActorPrincipal).HasMaxLength(100);

                entity.Property(e => e.ActorPrincipal2).HasMaxLength(100);

                entity.Property(e => e.ActorSecundario).HasMaxLength(100);

                entity.Property(e => e.ActorSecundario2).HasMaxLength(100);

                entity.Property(e => e.Descripcion).HasMaxLength(500);

                entity.Property(e => e.Fecha).HasColumnName("fecha");

                entity.Property(e => e.Nombre).HasMaxLength(200);

                entity.HasOne(d => d.IdCategoriaSeriesNavigation)
                    .WithMany(p => p.Series)
                    .HasForeignKey(d => d.IdCategoriaSeries)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("series_FK");
            });

            modelBuilder.Entity<Subcategorias>(entity =>
            {
                entity.HasKey(e => e.IdSubcategoria)
                    .HasName("PRIMARY");

                entity.ToTable("subcategorias");

                entity.HasIndex(e => e.IdCategoria, "SubCategorias_FK");

                entity.HasIndex(e => e.IdPelicula, "SubCategorias_FK_1");

                entity.HasIndex(e => e.IdSerie, "SubCategorias_FK_2");

                entity.Property(e => e.IdSubcategoria).HasColumnName("Id_Subcategoria");

                entity.Property(e => e.IdCategoria).HasColumnName("id_Categoria");

                entity.Property(e => e.IdPelicula).HasColumnName("Id_Pelicula");

                entity.Property(e => e.IdSerie).HasColumnName("Id_Serie");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Subcategorias)
                    .HasForeignKey(d => d.IdCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SubCategorias_FK");

                entity.HasOne(d => d.IdPeliculaNavigation)
                    .WithMany(p => p.Subcategorias)
                    .HasForeignKey(d => d.IdPelicula)
                    .HasConstraintName("SubCategorias_FK_1");

                entity.HasOne(d => d.IdSerieNavigation)
                    .WithMany(p => p.Subcategorias)
                    .HasForeignKey(d => d.IdSerie)
                    .HasConstraintName("SubCategorias_FK_2");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PRIMARY");

                entity.ToTable("usuarios");

                entity.HasIndex(e => e.IdCategoria, "usuarios_FK");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.Apellido).HasMaxLength(100);

                entity.Property(e => e.Email).HasMaxLength(200);

                entity.Property(e => e.FechaAlta).HasColumnType("datetime");

                entity.Property(e => e.IdCategoria).HasColumnName("id_categoria");

                entity.Property(e => e.Nombre).HasMaxLength(200);

                entity.Property(e => e.Password).HasMaxLength(256);

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("usuarios_FK");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
