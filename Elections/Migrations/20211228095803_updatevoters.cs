using Microsoft.EntityFrameworkCore.Migrations;

namespace Elections.Migrations
{
    public partial class updatevoters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OptionToVoteIdNumber",
                table: "Voters",
                type: "int",
                nullable: true,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OptionToVoteIdNumber",
                table: "Voters");
        }
    }
}
