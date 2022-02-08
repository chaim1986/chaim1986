using Microsoft.EntityFrameworkCore.Migrations;

namespace Elections.Migrations
{
    public partial class seedElection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into elections values ('jeruslem', '10/10/2020', '10/02/2021', 1, 2, null, 1)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from elections");
        }
    }
}
