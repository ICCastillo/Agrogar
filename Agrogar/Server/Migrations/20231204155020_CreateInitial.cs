using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Agrogar.Server.Migrations
{
    /// <inheritdoc />
    public partial class CreateInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobTitles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTitles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LicensePP = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkPhase",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkPhase", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    WorkPhaseId = table.Column<int>(type: "int", nullable: false),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Municipality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CadasterReference = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    Crop = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Properties_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Properties_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Properties_WorkPhase_WorkPhaseId",
                        column: x => x.WorkPhaseId,
                        principalTable: "WorkPhase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TaskType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkPhaseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskType_WorkPhase_WorkPhaseId",
                        column: x => x.WorkPhaseId,
                        principalTable: "WorkPhase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Works",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyId = table.Column<int>(type: "int", nullable: false),
                    TaskTypeId = table.Column<int>(type: "int", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Works", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Works_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Works_TaskType_TaskTypeId",
                        column: x => x.TaskTypeId,
                        principalTable: "TaskType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Assignment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    WorkId = table.Column<int>(type: "int", nullable: false),
                    JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LicensePP = table.Column<bool>(type: "bit", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkedHours = table.Column<int>(type: "int", nullable: true),
                    DateCompleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assignment_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Assignment_Works_WorkId",
                        column: x => x.WorkId,
                        principalTable: "Works",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name", "Url" },
                values: new object[,]
                {
                    { 1, "Campo de cultivo", "images/fields.png" },
                    { 2, "Huerto Frutal", "images/treefield.png" },
                    { 3, "Invernadero", "images/greenhouse.png" },
                    { 4, "Almacen", "images/warehouse.png" }
                });

            migrationBuilder.InsertData(
                table: "JobTitles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Conductor de Tractor" },
                    { 2, "Peón" },
                    { 3, "Operario" },
                    { 4, "Conductor de Camión" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateCreated", "Email", "LicensePP", "Name", "PasswordHash", "PasswordSalt", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 4, 16, 50, 20, 844, DateTimeKind.Local).AddTicks(1343), "Test@Te.st", true, "Test", new byte[] { 177, 209, 203, 25, 48, 151, 158, 74, 121, 40, 4, 77, 111, 116, 75, 101, 113, 67, 152, 87, 107, 226, 17, 165, 171, 221, 141, 63, 31, 222, 142, 200, 88, 188, 215, 138, 94, 161, 30, 179, 51, 107, 119, 92, 195, 178, 134, 180, 227, 175, 52, 67, 17, 56, 165, 26, 203, 79, 64, 169, 8, 48, 248, 105 }, new byte[] { 118, 141, 4, 5, 113, 42, 233, 249, 150, 72, 23, 73, 244, 228, 243, 129, 121, 47, 240, 177, 171, 156, 152, 128, 143, 232, 221, 93, 87, 32, 193, 221, 48, 1, 26, 108, 145, 157, 83, 94, 106, 135, 34, 185, 165, 210, 150, 21, 60, 209, 12, 105, 157, 149, 190, 1, 58, 219, 224, 43, 182, 94, 70, 227, 77, 185, 199, 146, 110, 147, 194, 15, 99, 136, 209, 95, 195, 96, 17, 221, 65, 71, 64, 0, 109, 196, 29, 228, 73, 18, 149, 68, 248, 248, 163, 181, 89, 29, 132, 104, 9, 95, 29, 222, 25, 23, 249, 56, 86, 206, 56, 254, 214, 87, 114, 57, 27, 59, 202, 37, 77, 146, 18, 185, 86, 77, 43, 207 }, "1234567890" },
                    { 2, new DateTime(2023, 12, 4, 16, 50, 20, 844, DateTimeKind.Local).AddTicks(1349), "Test2@Te.st", true, "Test2", new byte[] { 177, 209, 203, 25, 48, 151, 158, 74, 121, 40, 4, 77, 111, 116, 75, 101, 113, 67, 152, 87, 107, 226, 17, 165, 171, 221, 141, 63, 31, 222, 142, 200, 88, 188, 215, 138, 94, 161, 30, 179, 51, 107, 119, 92, 195, 178, 134, 180, 227, 175, 52, 67, 17, 56, 165, 26, 203, 79, 64, 169, 8, 48, 248, 105 }, new byte[] { 118, 141, 4, 5, 113, 42, 233, 249, 150, 72, 23, 73, 244, 228, 243, 129, 121, 47, 240, 177, 171, 156, 152, 128, 143, 232, 221, 93, 87, 32, 193, 221, 48, 1, 26, 108, 145, 157, 83, 94, 106, 135, 34, 185, 165, 210, 150, 21, 60, 209, 12, 105, 157, 149, 190, 1, 58, 219, 224, 43, 182, 94, 70, 227, 77, 185, 199, 146, 110, 147, 194, 15, 99, 136, 209, 95, 195, 96, 17, 221, 65, 71, 64, 0, 109, 196, 29, 228, 73, 18, 149, 68, 248, 248, 163, 181, 89, 29, 132, 104, 9, 95, 29, 222, 25, 23, 249, 56, 86, 206, 56, 254, 214, 87, 114, 57, 27, 59, 202, 37, 77, 146, 18, 185, 86, 77, 43, 207 }, "1234567890" }
                });

            migrationBuilder.InsertData(
                table: "WorkPhase",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Preparación del suelo" },
                    { 2, "Siembra" },
                    { 3, "Riego" },
                    { 4, "Control de Biodiversidad" },
                    { 5, "Mantenimiento" },
                    { 6, "Fertilización" },
                    { 7, "Cosecha" }
                });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "CadasterReference", "CategoryId", "Crop", "Municipality", "Province", "Size", "UserId", "WorkPhaseId" },
                values: new object[,]
                {
                    { 1, "33054A026001080000RI", 1, "Trigo", "Las Regueras", "Asturias", 3, 1, 2 },
                    { 2, "52014A011002030000KJ", 1, "Maiz", "Carreño", "Asturias", 3, 1, 7 },
                    { 3, "52014A011001880000KP", 3, "Fresa", "Carreño", "Asturias", 3, 2, 3 },
                    { 4, "52076A101004200000LL", 4, "Nave industrial", "Villaviciosa", "Asturias", 3, 2, 5 }
                });

            migrationBuilder.InsertData(
                table: "TaskType",
                columns: new[] { "Id", "Name", "WorkPhaseId" },
                values: new object[,]
                {
                    { 1, "Arar", 1 },
                    { 2, "Nivelar", 1 },
                    { 3, "Abonar", 1 },
                    { 4, "Sembrar", 2 },
                    { 5, "Inundación", 3 },
                    { 6, "Gravedad", 3 },
                    { 7, "Aspersión", 3 },
                    { 8, "Goteo", 3 },
                    { 9, "Hidropónico", 3 },
                    { 10, "Fumigar", 4 },
                    { 11, "Escardar", 4 },
                    { 12, "Quemar", 4 },
                    { 13, "Poda", 5 },
                    { 14, "Reparación", 5 },
                    { 15, "Limpieza", 5 },
                    { 16, "Fertilizar", 6 },
                    { 17, "Recogida", 7 },
                    { 18, "Transporte", 7 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assignment_UserId",
                table: "Assignment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignment_WorkId",
                table: "Assignment",
                column: "WorkId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_CategoryId",
                table: "Properties",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_UserId",
                table: "Properties",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_WorkPhaseId",
                table: "Properties",
                column: "WorkPhaseId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskType_WorkPhaseId",
                table: "TaskType",
                column: "WorkPhaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Works_PropertyId",
                table: "Works",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_Works_TaskTypeId",
                table: "Works",
                column: "TaskTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assignment");

            migrationBuilder.DropTable(
                name: "JobTitles");

            migrationBuilder.DropTable(
                name: "Works");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "TaskType");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "WorkPhase");
        }
    }
}
