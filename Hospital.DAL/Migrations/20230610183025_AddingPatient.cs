using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hospital.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddingPatient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("0ecfbf4a-43cb-43e3-bc1d-f65311329923"));

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("1eba0d36-22ba-4947-855d-f2d5f4bafa10"));

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("2925724d-fd2e-4358-bc5e-e4a2af0fcd57"));

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("61547fa3-fdf4-46f4-be21-b02186b206e9"));

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("66dd89dc-8c74-4f32-a498-683ae86fb9f2"));

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("7e614007-0646-47db-8294-256a136bb54f"));

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("807c4fcd-4c2e-49af-85b1-d23b02fe0bb6"));

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("ac8829b9-ecef-4b39-a8b4-be25c563c9ab"));

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("b18ed37d-cd76-4b61-ba9d-4e44ae45b719"));

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("eb9ef91d-7500-401f-bfcf-4d3af0f9ec13"));

            migrationBuilder.CreateTable(
                name: "Issues",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Issues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoctorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IssuePatient",
                columns: table => new
                {
                    IssuesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssuePatient", x => new { x.IssuesId, x.PatientsId });
                    table.ForeignKey(
                        name: "FK_IssuePatient_Issues_IssuesId",
                        column: x => x.IssuesId,
                        principalTable: "Issues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IssuePatient_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "Name", "PerformanceRate", "Salary", "Specializatuon" },
                values: new object[,]
                {
                    { new Guid("0772f2d5-23ec-4540-a07f-4af793386b7d"), "Sara", 82, 45041m, "Pediatrics" },
                    { new Guid("375447f8-f75b-4cd7-9129-b0a5d78332dc"), "Naomi", 27, 32145m, "Pediatrics" },
                    { new Guid("56f86e40-fcd8-4911-900c-7ae1255fc53a"), "Alyssa", 79, 16586m, "Gastroenterology" },
                    { new Guid("6724a92b-ea27-40c1-adc3-d6667ea07ffc"), "Judy", 32, 18711m, "Neurology" },
                    { new Guid("9d3c4cbd-3248-47ca-8934-e4315c702e11"), "Judy", 19, 48498m, "Dermatology" },
                    { new Guid("aa1e6135-fb7e-4649-9016-d8a8f96ce12c"), "Rafael", 97, 12266m, "Pediatrics" },
                    { new Guid("c74fab27-9d03-43d7-a99c-c5f25ba79987"), "Jessie", 65, 27064m, "Hematology" },
                    { new Guid("c97a676a-e3ea-4c28-92a2-90f8d0dd521b"), "Joann", 72, 9232m, "Hematology" },
                    { new Guid("d474b19d-2da7-4249-a946-a4bd73eb1d8d"), "Paula", 0, 19094m, "Urology" },
                    { new Guid("f413b97d-1de4-4da9-8d2b-c93cea7b66f8"), "Mable", 5, 33706m, "Infectious Disease" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_IssuePatient_PatientsId",
                table: "IssuePatient",
                column: "PatientsId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_DoctorId",
                table: "Patients",
                column: "DoctorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IssuePatient");

            migrationBuilder.DropTable(
                name: "Issues");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("0772f2d5-23ec-4540-a07f-4af793386b7d"));

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("375447f8-f75b-4cd7-9129-b0a5d78332dc"));

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("56f86e40-fcd8-4911-900c-7ae1255fc53a"));

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("6724a92b-ea27-40c1-adc3-d6667ea07ffc"));

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("9d3c4cbd-3248-47ca-8934-e4315c702e11"));

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("aa1e6135-fb7e-4649-9016-d8a8f96ce12c"));

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("c74fab27-9d03-43d7-a99c-c5f25ba79987"));

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("c97a676a-e3ea-4c28-92a2-90f8d0dd521b"));

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("d474b19d-2da7-4249-a946-a4bd73eb1d8d"));

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("f413b97d-1de4-4da9-8d2b-c93cea7b66f8"));

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
    }
}
