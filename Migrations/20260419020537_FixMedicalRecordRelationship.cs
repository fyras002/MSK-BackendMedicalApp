using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalAppBackend.Migrations
{
    /// <inheritdoc />
    public partial class FixMedicalRecordRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_MedicalRecords_MedicalRecordIdMedicalRecord",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_MedicalRecordIdMedicalRecord",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "MedicalRecordIdMedicalRecord",
                table: "Patients");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecords_IdPatient",
                table: "MedicalRecords",
                column: "IdPatient",
                unique: true,
                filter: "[IdPatient] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalRecords_Patients_IdPatient",
                table: "MedicalRecords",
                column: "IdPatient",
                principalTable: "Patients",
                principalColumn: "IdPatient");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalRecords_Patients_IdPatient",
                table: "MedicalRecords");

            migrationBuilder.DropIndex(
                name: "IX_MedicalRecords_IdPatient",
                table: "MedicalRecords");

            migrationBuilder.AddColumn<int>(
                name: "MedicalRecordIdMedicalRecord",
                table: "Patients",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_MedicalRecordIdMedicalRecord",
                table: "Patients",
                column: "MedicalRecordIdMedicalRecord");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_MedicalRecords_MedicalRecordIdMedicalRecord",
                table: "Patients",
                column: "MedicalRecordIdMedicalRecord",
                principalTable: "MedicalRecords",
                principalColumn: "IdMedicalRecord");
        }
    }
}
