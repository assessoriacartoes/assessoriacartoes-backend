using Microsoft.EntityFrameworkCore.Migrations;

namespace AssessoriaCartoesApi.Data.Migrations
{
    public partial class addcolumncliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Img",
                table: "Clientes",
                type: "longblob",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Img",
                table: "Clientes");
        }
    }
}