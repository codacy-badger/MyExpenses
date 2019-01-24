using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace lfmachadodasilva.MyExpenses.WebApplication.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GroupDto",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupDto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserDto",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    GroupDtoId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserDto_GroupDto_GroupDtoId",
                        column: x => x.GroupDtoId,
                        principalTable: "GroupDto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserDto_GroupDtoId",
                table: "UserDto",
                column: "GroupDtoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserDto");

            migrationBuilder.DropTable(
                name: "GroupDto");
        }
    }
}
