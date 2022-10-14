using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleAppEntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class Categorias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "tblProductos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "tblCategorias",
                columns: table => new
                {
                    CategoriaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCategorias", x => x.CategoriaId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblProductos_CategoriaId",
                table: "tblProductos",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblProductos_tblCategorias_CategoriaId",
                table: "tblProductos",
                column: "CategoriaId",
                principalTable: "tblCategorias",
                principalColumn: "CategoriaId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblProductos_tblCategorias_CategoriaId",
                table: "tblProductos");

            migrationBuilder.DropTable(
                name: "tblCategorias");

            migrationBuilder.DropIndex(
                name: "IX_tblProductos_CategoriaId",
                table: "tblProductos");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "tblProductos");
        }
    }
}
