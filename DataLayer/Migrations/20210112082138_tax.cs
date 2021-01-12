using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class tax : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_driver",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameFamily = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true),
                    Adress = table.Column<string>(nullable: true),
                    Lat = table.Column<string>(nullable: true),
                    Len = table.Column<string>(nullable: true),
                    token = table.Column<string>(nullable: true),
                    type_car = table.Column<string>(nullable: true),
                    pelak = table.Column<string>(nullable: true),
                    profile_img = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_driver", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Travels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserPhone = table.Column<string>(nullable: true),
                    Origin = table.Column<string>(nullable: true),
                    Destination = table.Column<string>(nullable: true),
                    Distance = table.Column<string>(nullable: true),
                    Price = table.Column<string>(nullable: true),
                    Time = table.Column<string>(nullable: true),
                    DateDay = table.Column<DateTime>(nullable: false),
                    DriverId = table.Column<int>(nullable: false),
                    TypePay = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Travels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameFamily = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true),
                    Adress = table.Column<string>(nullable: true),
                    Lat = table.Column<string>(nullable: true),
                    Len = table.Column<string>(nullable: true),
                    token = table.Column<string>(nullable: true),
                    photo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_driver");

            migrationBuilder.DropTable(
                name: "tbl_Travels");

            migrationBuilder.DropTable(
                name: "tbl_Users");
        }
    }
}
