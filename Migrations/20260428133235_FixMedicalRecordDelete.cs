using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalAppBackend.Migrations
{
    /// <inheritdoc />
    public partial class FixMedicalRecordDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalRecords_Patients_IdPatient",
                table: "MedicalRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_Documents_IdDocument",
                table: "Prescriptions");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalRecords_Patients_IdPatient",
                table: "MedicalRecords",
                column: "IdPatient",
                principalTable: "Patients",
                principalColumn: "IdPatient",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_Documents_IdDocument",
                table: "Prescriptions",
                column: "IdDocument",
                principalTable: "Documents",
                principalColumn: "IdDocument",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalRecords_Patients_IdPatient",
                table: "MedicalRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_Documents_IdDocument",
                table: "Prescriptions");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalRecords_Patients_IdPatient",
                table: "MedicalRecords",
                column: "IdPatient",
                principalTable: "Patients",
                principalColumn: "IdPatient",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_Documents_IdDocument",
                table: "Prescriptions",
                column: "IdDocument",
                principalTable: "Documents",
                principalColumn: "IdDocument");
        }
    }
}
