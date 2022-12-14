// <auto-generated />
using System;
using EntityLib;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EntityLib.Migrations
{
    [DbContext(typeof(pelisyaContext))]
    partial class pelisyaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("utf8_general_ci")
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.HasCharSet(modelBuilder, "utf8");

            modelBuilder.Entity("EntityLib.Categoriacontenido", b =>
                {
                    b.Property<int>("IdCategoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idCategoria");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("IdCategoria")
                        .HasName("PRIMARY");

                    b.ToTable("categoriacontenido", (string)null);
                });

            modelBuilder.Entity("EntityLib.Categoriasusuarios", b =>
                {
                    b.Property<int>("IdCategoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_categoria");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("descripcion");

                    b.HasKey("IdCategoria")
                        .HasName("PRIMARY");

                    b.ToTable("categoriasusuarios", (string)null);
                });

            modelBuilder.Entity("EntityLib.Estadofactura", b =>
                {
                    b.Property<int>("IdEstado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id_Estado");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("IdEstado")
                        .HasName("PRIMARY");

                    b.ToTable("estadofactura", (string)null);
                });

            modelBuilder.Entity("EntityLib.Facturasporcobrar", b =>
                {
                    b.Property<int>("IdFactura")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id_Factura");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("IdEstado")
                        .HasColumnType("int")
                        .HasColumnName("Id_Estado");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int")
                        .HasColumnName("id_usuario");

                    b.Property<decimal>("Monto")
                        .HasPrecision(10)
                        .HasColumnType("decimal(10)");

                    b.Property<decimal?>("MontoTax")
                        .HasPrecision(10)
                        .HasColumnType("decimal(10)")
                        .HasColumnName("MontoTAX");

                    b.Property<decimal?>("MontoTotal")
                        .HasPrecision(10)
                        .HasColumnType("decimal(10)");

                    b.Property<string>("Periodo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("IdFactura")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdEstado" }, "FacturasPorCobrar_FK");

                    b.HasIndex(new[] { "IdUsuario" }, "FacturasPorCobrar_FK_1");

                    b.ToTable("facturasporcobrar", (string)null);
                });

            modelBuilder.Entity("EntityLib.Listas", b =>
                {
                    b.Property<int>("IdLista")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id_Lista");

                    b.Property<int?>("IdPelicula")
                        .HasColumnType("int")
                        .HasColumnName("Id_Pelicula");

                    b.Property<int?>("IdSerie")
                        .HasColumnType("int")
                        .HasColumnName("Id_Serie");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int")
                        .HasColumnName("Id_Usuario");

                    b.HasKey("IdLista")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdSerie" }, "listas_FK");

                    b.HasIndex(new[] { "IdPelicula" }, "listas_FK_1");

                    b.HasIndex(new[] { "IdUsuario" }, "listas_FK_2");

                    b.ToTable("listas", (string)null);
                });

            modelBuilder.Entity("EntityLib.Peliculas", b =>
                {
                    b.Property<int>("IdPelicula")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id_Pelicula");

                    b.Property<string>("ActorPrincipal")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("ActorPrincipal2")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("ActorSecundario")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("ActorSecundario2")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("fecha");

                    b.Property<int>("IdCategoriaPeliculas")
                        .HasColumnType("int");

                    b.Property<string>("IdImdb")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("IdIMDB");

                    b.Property<string>("Nombre")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Portada")
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)");

                    b.Property<int?>("Ranking")
                        .HasColumnType("int")
                        .HasColumnName("ranking");

                    b.HasKey("IdPelicula")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdCategoriaPeliculas" }, "peliculas_FK");

                    b.ToTable("peliculas", (string)null);
                });

            modelBuilder.Entity("EntityLib.Series", b =>
                {
                    b.Property<int>("IdSerie")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id_Serie");

                    b.Property<string>("ActorPrincipal")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("ActorPrincipal2")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("ActorSecundario")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("ActorSecundario2")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("fecha");

                    b.Property<int>("IdCategoriaSeries")
                        .HasColumnType("int");

                    b.Property<string>("IdImdb")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("IdIMDB");

                    b.Property<string>("Nombre")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Portada")
                        .HasMaxLength(1000)
                        .HasColumnType("varchar(1000)");

                    b.HasKey("IdSerie")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdCategoriaSeries" }, "series_FK");

                    b.ToTable("series", (string)null);
                });

            modelBuilder.Entity("EntityLib.Subcategorias", b =>
                {
                    b.Property<int>("IdSubcategoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id_Subcategoria");

                    b.Property<int>("IdCategoria")
                        .HasColumnType("int")
                        .HasColumnName("id_Categoria");

                    b.Property<int?>("IdPelicula")
                        .HasColumnType("int")
                        .HasColumnName("Id_Pelicula");

                    b.Property<int?>("IdSerie")
                        .HasColumnType("int")
                        .HasColumnName("Id_Serie");

                    b.HasKey("IdSubcategoria")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdCategoria" }, "SubCategorias_FK");

                    b.HasIndex(new[] { "IdPelicula" }, "SubCategorias_FK_1");

                    b.HasIndex(new[] { "IdSerie" }, "SubCategorias_FK_2");

                    b.ToTable("subcategorias", (string)null);
                });

            modelBuilder.Entity("EntityLib.Usuarios", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_usuario");

                    b.Property<string>("Apellido")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<DateTime>("FechaAlta")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("IdCategoria")
                        .HasColumnType("int")
                        .HasColumnName("id_categoria");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("IdUsuario")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdCategoria" }, "usuarios_FK");

                    b.ToTable("usuarios", (string)null);
                });

            modelBuilder.Entity("EntityLib.Facturasporcobrar", b =>
                {
                    b.HasOne("EntityLib.Estadofactura", "IdEstadoNavigation")
                        .WithMany("Facturasporcobrar")
                        .HasForeignKey("IdEstado")
                        .IsRequired()
                        .HasConstraintName("FacturasPorCobrar_FK");

                    b.HasOne("EntityLib.Usuarios", "IdUsuarioNavigation")
                        .WithMany("Facturasporcobrar")
                        .HasForeignKey("IdUsuario")
                        .IsRequired()
                        .HasConstraintName("FacturasPorCobrar_FK_1");

                    b.Navigation("IdEstadoNavigation");

                    b.Navigation("IdUsuarioNavigation");
                });

            modelBuilder.Entity("EntityLib.Listas", b =>
                {
                    b.HasOne("EntityLib.Peliculas", "IdPeliculaNavigation")
                        .WithMany("Listas")
                        .HasForeignKey("IdPelicula")
                        .HasConstraintName("listas_FK_1");

                    b.HasOne("EntityLib.Series", "IdSerieNavigation")
                        .WithMany("Listas")
                        .HasForeignKey("IdSerie")
                        .HasConstraintName("listas_FK");

                    b.HasOne("EntityLib.Usuarios", "IdUsuarioNavigation")
                        .WithMany("Listas")
                        .HasForeignKey("IdUsuario")
                        .IsRequired()
                        .HasConstraintName("listas_FK_2");

                    b.Navigation("IdPeliculaNavigation");

                    b.Navigation("IdSerieNavigation");

                    b.Navigation("IdUsuarioNavigation");
                });

            modelBuilder.Entity("EntityLib.Peliculas", b =>
                {
                    b.HasOne("EntityLib.Categoriacontenido", "IdCategoriaPeliculasNavigation")
                        .WithMany("Peliculas")
                        .HasForeignKey("IdCategoriaPeliculas")
                        .IsRequired()
                        .HasConstraintName("peliculas_FK");

                    b.Navigation("IdCategoriaPeliculasNavigation");
                });

            modelBuilder.Entity("EntityLib.Series", b =>
                {
                    b.HasOne("EntityLib.Categoriacontenido", "IdCategoriaSeriesNavigation")
                        .WithMany("Series")
                        .HasForeignKey("IdCategoriaSeries")
                        .IsRequired()
                        .HasConstraintName("series_FK");

                    b.Navigation("IdCategoriaSeriesNavigation");
                });

            modelBuilder.Entity("EntityLib.Subcategorias", b =>
                {
                    b.HasOne("EntityLib.Categoriacontenido", "IdCategoriaNavigation")
                        .WithMany("Subcategorias")
                        .HasForeignKey("IdCategoria")
                        .IsRequired()
                        .HasConstraintName("SubCategorias_FK");

                    b.HasOne("EntityLib.Peliculas", "IdPeliculaNavigation")
                        .WithMany("Subcategorias")
                        .HasForeignKey("IdPelicula")
                        .HasConstraintName("SubCategorias_FK_1");

                    b.HasOne("EntityLib.Series", "IdSerieNavigation")
                        .WithMany("Subcategorias")
                        .HasForeignKey("IdSerie")
                        .HasConstraintName("SubCategorias_FK_2");

                    b.Navigation("IdCategoriaNavigation");

                    b.Navigation("IdPeliculaNavigation");

                    b.Navigation("IdSerieNavigation");
                });

            modelBuilder.Entity("EntityLib.Usuarios", b =>
                {
                    b.HasOne("EntityLib.Categoriasusuarios", "IdCategoriaNavigation")
                        .WithMany("Usuarios")
                        .HasForeignKey("IdCategoria")
                        .IsRequired()
                        .HasConstraintName("usuarios_FK");

                    b.Navigation("IdCategoriaNavigation");
                });

            modelBuilder.Entity("EntityLib.Categoriacontenido", b =>
                {
                    b.Navigation("Peliculas");

                    b.Navigation("Series");

                    b.Navigation("Subcategorias");
                });

            modelBuilder.Entity("EntityLib.Categoriasusuarios", b =>
                {
                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("EntityLib.Estadofactura", b =>
                {
                    b.Navigation("Facturasporcobrar");
                });

            modelBuilder.Entity("EntityLib.Peliculas", b =>
                {
                    b.Navigation("Listas");

                    b.Navigation("Subcategorias");
                });

            modelBuilder.Entity("EntityLib.Series", b =>
                {
                    b.Navigation("Listas");

                    b.Navigation("Subcategorias");
                });

            modelBuilder.Entity("EntityLib.Usuarios", b =>
                {
                    b.Navigation("Facturasporcobrar");

                    b.Navigation("Listas");
                });
#pragma warning restore 612, 618
        }
    }
}
