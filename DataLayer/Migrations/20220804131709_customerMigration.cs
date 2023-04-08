using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    public partial class customerMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerAdresses",
                columns: table => new
                {
                    customerAdresses_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customer_ID = table.Column<int>(type: "int", nullable: false),
                    country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    primary_adress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    secondary_adress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    third_adress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone_number = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerAdresses", x => x.customerAdresses_ID);
                });

            migrationBuilder.CreateTable(
                name: "CustomerDepartment",
                columns: table => new
                {
                    departmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    departmentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    yearsOfExperience = table.Column<int>(type: "int", nullable: false),
                    customer_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerDepartment", x => x.departmentID);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    customer_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customer_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    customer_surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    customer_email_adress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    customer_company = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    customer_job_title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    customer_registiration_date = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.customer_ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerAdresses");

            migrationBuilder.DropTable(
                name: "CustomerDepartment");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
