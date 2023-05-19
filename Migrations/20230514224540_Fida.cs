using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMSS.Migrations
{
    /// <inheritdoc />
    public partial class Fida : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "HMSS");

            migrationBuilder.CreateTable(
                name: "Departements",
                schema: "HMSS",
                columns: table => new
                {
                    id_Dep = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom = table.Column<string>(type: "Varchar(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departements", x => x.id_Dep);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                schema: "HMSS",
                columns: table => new
                {
                    DoctorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "Varchar(250)", nullable: false),
                    password = table.Column<string>(type: "Varchar(250)", nullable: false),
                    nom = table.Column<string>(type: "Varchar(250)", nullable: false),
                    prenom = table.Column<string>(type: "Varchar(250)", nullable: false),
                    speciality = table.Column<string>(type: "Varchar(250)", nullable: false),
                    Department_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.DoctorId);
                    table.ForeignKey(
                        name: "FK_Doctors_Departements_Department_id",
                        column: x => x.Department_id,
                        principalSchema: "HMSS",
                        principalTable: "Departements",
                        principalColumn: "id_Dep",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                schema: "HMSS",
                columns: table => new
                {
                    IdPatient = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Doctor_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.IdPatient);
                    table.ForeignKey(
                        name: "FK_Patients_Doctors_Doctor_id",
                        column: x => x.Doctor_id,
                        principalSchema: "HMSS",
                        principalTable: "Doctors",
                        principalColumn: "DoctorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_Department_id",
                schema: "HMSS",
                table: "Doctors",
                column: "Department_id");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_Doctor_id",
                schema: "HMSS",
                table: "Patients",
                column: "Doctor_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Patients",
                schema: "HMSS");

            migrationBuilder.DropTable(
                name: "Doctors",
                schema: "HMSS");

            migrationBuilder.DropTable(
                name: "Departements",
                schema: "HMSS");
        }
    }
}
