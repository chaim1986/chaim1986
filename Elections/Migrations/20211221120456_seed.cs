using Microsoft.EntityFrameworkCore.Migrations;

namespace Elections.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into users (FirstName, LastName, PhoneNumber, EmailAdress, City, Street, Password, IsManager) values ('chaim','hacohen', '0556697157', 'haco3545', 'bet shemesh', 'hanachal', '1234', 0)");
            migrationBuilder.Sql("insert into users (FirstName, LastName, PhoneNumber, EmailAdress, City, Street, Password, IsManager) values ('moshe','levi', '0556697158', 'haco4667', 'berlin', 'moonStrase', '1234', 0)");
            migrationBuilder.Sql("insert into users (FirstName, LastName, PhoneNumber, EmailAdress, City, Street, Password, IsManager) values ('david','shalom', '048374646', 'white@gmail.com', 'bet lechem', 'hanachal', '1234', 0)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from users");
        }
    }
}
