using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hospital.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specializatuon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PerformanceRate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "Name", "PerformanceRate", "Salary", "Specializatuon" },
                values: new object[,]
                {
                    { new Guid("0ecfbf4a-43cb-43e3-bc1d-f65311329923"), "Joann", 72, 9232m, "Hematology" },
                    { new Guid("1eba0d36-22ba-4947-855d-f2d5f4bafa10"), "Rafael", 97, 12266m, "Pediatrics" },
                    { new Guid("2925724d-fd2e-4358-bc5e-e4a2af0fcd57"), "Mable", 5, 33706m, "Infectious Disease" },
                    { new Guid("61547fa3-fdf4-46f4-be21-b02186b206e9"), "Sara", 82, 45041m, "Pediatrics" },
                    { new Guid("66dd89dc-8c74-4f32-a498-683ae86fb9f2"), "Judy", 32, 18711m, "Neurology" },
                    { new Guid("7e614007-0646-47db-8294-256a136bb54f"), "Jessie", 65, 27064m, "Hematology" },
                    { new Guid("807c4fcd-4c2e-49af-85b1-d23b02fe0bb6"), "Alyssa", 79, 16586m, "Gastroenterology" },
                    { new Guid("ac8829b9-ecef-4b39-a8b4-be25c563c9ab"), "Paula", 0, 19094m, "Urology" },
                    { new Guid("b18ed37d-cd76-4b61-ba9d-4e44ae45b719"), "Judy", 19, 48498m, "Dermatology" },
                    { new Guid("eb9ef91d-7500-401f-bfcf-4d3af0f9ec13"), "Naomi", 27, 32145m, "Pediatrics" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doctors");
        }
    }
}
