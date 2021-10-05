using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace P1_AP1_Carlos_20190720.Migrations
{
    public partial class Migracion_inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aportes",
                columns: table => new
                {
                    aporteID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    fechaAporte = table.Column<DateTime>(type: "TEXT", nullable: false),
                    persona = table.Column<string>(type: "TEXT", nullable: true),
                    concepto = table.Column<string>(type: "TEXT", nullable: true),
                    monto = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aportes", x => x.aporteID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aportes");
        }
    }
}
