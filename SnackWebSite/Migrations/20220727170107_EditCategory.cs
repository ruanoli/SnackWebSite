using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SnackWebSite.Migrations
{
    public partial class EditCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categories(Name, Description)" +
                "VALUES('Natural','Lanches saudáveis')");

            migrationBuilder.Sql("INSERT INTO Categories(Name, Description)" +
                "VALUES('Normal','Lanches saborosos')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Categories");
        }
    }
}
