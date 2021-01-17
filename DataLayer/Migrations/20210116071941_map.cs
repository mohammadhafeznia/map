using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class map : Migration
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
                name: "Tbl_paydriver",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Driverid = table.Column<string>(nullable: true),
                    Travelid = table.Column<string>(nullable: true),
                    NameFamily = table.Column<string>(nullable: true),
                    Pay = table.Column<int>(nullable: false),
                    Harvest = table.Column<int>(nullable: false),
                    Paytime = table.Column<DateTime>(nullable: false),
                    havesttime = table.Column<DateTime>(nullable: false),
                    status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_paydriver", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_pays",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Phone = table.Column<string>(nullable: true),
                    NameFamily = table.Column<string>(nullable: true),
                    Pay = table.Column<int>(nullable: false),
                    Harvest = table.Column<int>(nullable: false),
                    Paytime = table.Column<DateTime>(nullable: false),
                    havesttime = table.Column<DateTime>(nullable: false),
                    status = table.Column<bool>(nullable: false),
                    idtravel = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_pays", x => x.Id);
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
                name: "Tbl_paydriver");

            migrationBuilder.DropTable(
                name: "Tbl_pays");

            migrationBuilder.DropTable(
                name: "tbl_Travels");

            migrationBuilder.DropTable(
                name: "tbl_Users");
        }
    }
}
