using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_Flight",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    DateDeparture = table.Column<DateTime>(nullable: false),
                    TimeDeparture = table.Column<TimeSpan>(nullable: false),
                    Source = table.Column<string>(maxLength: 100, nullable: false),
                    Destiny = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Flight", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Session",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    DtCreated = table.Column<DateTime>(nullable: false),
                    DtExpire = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Session", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 100, nullable: false),
                    Username = table.Column<string>(maxLength: 100, nullable: false),
                    Password = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_User", x => x.Id);
                });

            migrationBuilder.Sql(@"SET IDENTITY_INSERT [tbl_User] ON;
                    INSERT INTO [tbl_User] ([Id], [FirstName], [Username],[Password])
                    VALUES (1, N'Usuario', N'user@domain.com', N'123456');
                    SET IDENTITY_INSERT [tbl_User] OFF;");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_Flight");

            migrationBuilder.DropTable(
                name: "tbl_Session");

            migrationBuilder.DropTable(
                name: "tbl_User");
        }
    }
}
