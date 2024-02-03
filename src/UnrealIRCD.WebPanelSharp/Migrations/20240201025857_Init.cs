using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UnrealIRCD.WebPanelSharp.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SysUsers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 120, nullable: true),
                    Password = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysUsers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "SysUsers",
                columns: new[] { "Id", "Name", "Password" },
                values: new object[] { 1L, "root", "password" });

            migrationBuilder.CreateIndex(
                name: "IX_SysUsers_Name",
                table: "SysUsers",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SysUsers");
        }
    }
}
