using Microsoft.EntityFrameworkCore.Migrations;

namespace AssessoriaCartoesApi.Data.Migrations
{
    public partial class addcolumnclientetipousuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoDeUsuario",
                table: "Clientes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoDeUsuario",
                table: "Clientes");
        }
    }
}
