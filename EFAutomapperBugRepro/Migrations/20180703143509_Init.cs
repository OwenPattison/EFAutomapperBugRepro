using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFAutomapperBugRepro.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ThingTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThingTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Things",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    TypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Things", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Things_ThingTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "ThingTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ThingTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Thing type 1" });

            migrationBuilder.InsertData(
                table: "ThingTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Thing type 2" });

            migrationBuilder.InsertData(
                table: "Things",
                columns: new[] { "Id", "Name", "TypeId" },
                values: new object[] { 1, "Thing 1", 1 });

            migrationBuilder.InsertData(
                table: "Things",
                columns: new[] { "Id", "Name", "TypeId" },
                values: new object[] { 2, "Thing 2", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Things_TypeId",
                table: "Things",
                column: "TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Things");

            migrationBuilder.DropTable(
                name: "ThingTypes");
        }
    }
}
