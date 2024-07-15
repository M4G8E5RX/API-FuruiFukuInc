using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_FuruiFukuInc.Migrations
{
    /// <inheritdoc />
    public partial class InitDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    FechaIngreso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImporteTotalVentas = table.Column<double>(type: "float", nullable: false),
                    Puesto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ventas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescripcionArticulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaVenta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImporteVenta = table.Column<double>(type: "float", nullable: false),
                    EstatusVenta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstatusSupervision = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ventas", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Ventas");
        }
    }
}
