using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalAppBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddCascadeDeleteToMedicalRecord : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalRecords_Patients_IdPatient",
                table: "MedicalRecords");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalRecords_Patients_IdPatient",
                table: "MedicalRecords",
                column: "IdPatient",
                principalTable: "Patients",
                principalColumn: "IdPatient",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalRecords_Patients_IdPatient",
                table: "MedicalRecords");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalRecords_Patients_IdPatient",
                table: "MedicalRecords",
                column: "IdPatient",
                principalTable: "Patients",
                principalColumn: "IdPatient");
        }
    }
}
