using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityLib.Migrations
{
    public partial class initialDBPelisYa2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8");

            migrationBuilder.CreateTable(
                name: "categoriacontenido",
                columns: table => new
                {
                    idCategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idCategoria);
                })
                .Annotation("MySql:CharSet", "utf8")
                .Annotation("Relational:Collation", "utf8_general_ci");

            migrationBuilder.CreateTable(
                name: "categoriasusuarios",
                columns: table => new
                {
                    id_categoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    descripcion = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id_categoria);
                })
                .Annotation("MySql:CharSet", "utf8")
                .Annotation("Relational:Collation", "utf8_general_ci");

            migrationBuilder.CreateTable(
                name: "estadofactura",
                columns: table => new
                {
                    Id_Estado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id_Estado);
                })
                .Annotation("MySql:CharSet", "utf8")
                .Annotation("Relational:Collation", "utf8_general_ci");

            migrationBuilder.CreateTable(
                name: "peliculas",
                columns: table => new
                {
                    Id_Pelicula = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdCategoriaPeliculas = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    Descripcion = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    fecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ActorPrincipal = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    ActorPrincipal2 = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    ActorSecundario = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    ActorSecundario2 = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    IdIMDB = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    Portada = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    ranking = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id_Pelicula);
                    table.ForeignKey(
                        name: "peliculas_FK",
                        column: x => x.IdCategoriaPeliculas,
                        principalTable: "categoriacontenido",
                        principalColumn: "idCategoria");
                })
                .Annotation("MySql:CharSet", "utf8")
                .Annotation("Relational:Collation", "utf8_general_ci");

            migrationBuilder.CreateTable(
                name: "series",
                columns: table => new
                {
                    Id_Serie = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdCategoriaSeries = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    Descripcion = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    fecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ActorPrincipal = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    ActorPrincipal2 = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    ActorSecundario = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    ActorSecundario2 = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    IdIMDB = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    Portada = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: true, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id_Serie);
                    table.ForeignKey(
                        name: "series_FK",
                        column: x => x.IdCategoriaSeries,
                        principalTable: "categoriacontenido",
                        principalColumn: "idCategoria");
                })
                .Annotation("MySql:CharSet", "utf8")
                .Annotation("Relational:Collation", "utf8_general_ci");

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    id_usuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    id_categoria = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    Apellido = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    Email = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    Password = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaAlta = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id_usuario);
                    table.ForeignKey(
                        name: "usuarios_FK",
                        column: x => x.id_categoria,
                        principalTable: "categoriasusuarios",
                        principalColumn: "id_categoria");
                })
                .Annotation("MySql:CharSet", "utf8")
                .Annotation("Relational:Collation", "utf8_general_ci");

            migrationBuilder.CreateTable(
                name: "subcategorias",
                columns: table => new
                {
                    Id_Subcategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    id_Categoria = table.Column<int>(type: "int", nullable: false),
                    Id_Pelicula = table.Column<int>(type: "int", nullable: true),
                    Id_Serie = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id_Subcategoria);
                    table.ForeignKey(
                        name: "SubCategorias_FK",
                        column: x => x.id_Categoria,
                        principalTable: "categoriacontenido",
                        principalColumn: "idCategoria");
                    table.ForeignKey(
                        name: "SubCategorias_FK_1",
                        column: x => x.Id_Pelicula,
                        principalTable: "peliculas",
                        principalColumn: "Id_Pelicula");
                    table.ForeignKey(
                        name: "SubCategorias_FK_2",
                        column: x => x.Id_Serie,
                        principalTable: "series",
                        principalColumn: "Id_Serie");
                })
                .Annotation("MySql:CharSet", "utf8")
                .Annotation("Relational:Collation", "utf8_general_ci");

            migrationBuilder.CreateTable(
                name: "facturasporcobrar",
                columns: table => new
                {
                    Id_Factura = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    id_usuario = table.Column<int>(type: "int", nullable: false),
                    Id_Estado = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Periodo = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    Monto = table.Column<decimal>(type: "decimal(10)", precision: 10, nullable: false),
                    MontoTAX = table.Column<decimal>(type: "decimal(10)", precision: 10, nullable: true),
                    MontoTotal = table.Column<decimal>(type: "decimal(10)", precision: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id_Factura);
                    table.ForeignKey(
                        name: "FacturasPorCobrar_FK",
                        column: x => x.Id_Estado,
                        principalTable: "estadofactura",
                        principalColumn: "Id_Estado");
                    table.ForeignKey(
                        name: "FacturasPorCobrar_FK_1",
                        column: x => x.id_usuario,
                        principalTable: "usuarios",
                        principalColumn: "id_usuario");
                })
                .Annotation("MySql:CharSet", "utf8")
                .Annotation("Relational:Collation", "utf8_general_ci");

            migrationBuilder.CreateTable(
                name: "listas",
                columns: table => new
                {
                    Id_Lista = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Id_Usuario = table.Column<int>(type: "int", nullable: false),
                    Id_Pelicula = table.Column<int>(type: "int", nullable: true),
                    Id_Serie = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id_Lista);
                    table.ForeignKey(
                        name: "listas_FK",
                        column: x => x.Id_Serie,
                        principalTable: "series",
                        principalColumn: "Id_Serie");
                    table.ForeignKey(
                        name: "listas_FK_1",
                        column: x => x.Id_Pelicula,
                        principalTable: "peliculas",
                        principalColumn: "Id_Pelicula");
                    table.ForeignKey(
                        name: "listas_FK_2",
                        column: x => x.Id_Usuario,
                        principalTable: "usuarios",
                        principalColumn: "id_usuario");
                })
                .Annotation("MySql:CharSet", "utf8")
                .Annotation("Relational:Collation", "utf8_general_ci");

            migrationBuilder.CreateIndex(
                name: "FacturasPorCobrar_FK",
                table: "facturasporcobrar",
                column: "Id_Estado");

            migrationBuilder.CreateIndex(
                name: "FacturasPorCobrar_FK_1",
                table: "facturasporcobrar",
                column: "id_usuario");

            migrationBuilder.CreateIndex(
                name: "listas_FK",
                table: "listas",
                column: "Id_Serie");

            migrationBuilder.CreateIndex(
                name: "listas_FK_1",
                table: "listas",
                column: "Id_Pelicula");

            migrationBuilder.CreateIndex(
                name: "listas_FK_2",
                table: "listas",
                column: "Id_Usuario");

            migrationBuilder.CreateIndex(
                name: "peliculas_FK",
                table: "peliculas",
                column: "IdCategoriaPeliculas");

            migrationBuilder.CreateIndex(
                name: "series_FK",
                table: "series",
                column: "IdCategoriaSeries");

            migrationBuilder.CreateIndex(
                name: "SubCategorias_FK",
                table: "subcategorias",
                column: "id_Categoria");

            migrationBuilder.CreateIndex(
                name: "SubCategorias_FK_1",
                table: "subcategorias",
                column: "Id_Pelicula");

            migrationBuilder.CreateIndex(
                name: "SubCategorias_FK_2",
                table: "subcategorias",
                column: "Id_Serie");

            migrationBuilder.CreateIndex(
                name: "usuarios_FK",
                table: "usuarios",
                column: "id_categoria");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "facturasporcobrar");

            migrationBuilder.DropTable(
                name: "listas");

            migrationBuilder.DropTable(
                name: "subcategorias");

            migrationBuilder.DropTable(
                name: "estadofactura");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropTable(
                name: "peliculas");

            migrationBuilder.DropTable(
                name: "series");

            migrationBuilder.DropTable(
                name: "categoriasusuarios");

            migrationBuilder.DropTable(
                name: "categoriacontenido");
        }
    }
}
