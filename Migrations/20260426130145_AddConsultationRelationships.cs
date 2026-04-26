using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalAppBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddConsultationRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultations_Doctors_DoctorId",
                table: "Consultations");

            migrationBuilder.DropForeignKey(
                name: "FK_Consultations_MedicalRecords_MedicalRecordIdMedicalRecord",
                table: "Consultations");

            migrationBuilder.DropForeignKey(
                name: "FK_Consultations_Patients_PatientIdPatient",
                table: "Consultations");

            migrationBuilder.DropIndex(
                name: "IX_Consultations_DoctorId",
                table: "Consultations");

            migrationBuilder.DropIndex(
                name: "IX_Consultations_MedicalRecordIdMedicalRecord",
                table: "Consultations");

            migrationBuilder.DropIndex(
                name: "IX_Consultations_PatientIdPatient",
                table: "Consultations");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "Consultations");

            migrationBuilder.DropColumn(
                name: "MedicalRecordIdMedicalRecord",
                table: "Consultations");

            migrationBuilder.DropColumn(
                name: "PatientIdPatient",
                table: "Consultations");

            migrationBuilder.CreateIndex(
                name: "IX_Consultations_IdDoctor",
                table: "Consultations",
                column: "IdDoctor");

            migrationBuilder.CreateIndex(
                name: "IX_Consultations_IdMedicalRecord",
                table: "Consultations",
                column: "IdMedicalRecord");

            migrationBuilder.CreateIndex(
                name: "IX_Consultations_IdPatient",
                table: "Consultations",
                column: "IdPatient");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultations_Doctors_IdDoctor",
                table: "Consultations",
                column: "IdDoctor",
                principalTable: "Doctors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultations_MedicalRecords_IdMedicalRecord",
                table: "Consultations",
                column: "IdMedicalRecord",
                principalTable: "MedicalRecords",
                principalColumn: "IdMedicalRecord");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultations_Patients_IdPatient",
                table: "Consultations",
                column: "IdPatient",
                principalTable: "Patients",
                principalColumn: "IdPatient");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultations_Doctors_IdDoctor",
                table: "Consultations");

            migrationBuilder.DropForeignKey(
                name: "FK_Consultations_MedicalRecords_IdMedicalRecord",
                table: "Consultations");

            migrationBuilder.DropForeignKey(
                name: "FK_Consultations_Patients_IdPatient",
                table: "Consultations");

            migrationBuilder.DropIndex(
                name: "IX_Consultations_IdDoctor",
                table: "Consultations");

            migrationBuilder.DropIndex(
                name: "IX_Consultations_IdMedicalRecord",
                table: "Consultations");

            migrationBuilder.DropIndex(
                name: "IX_Consultations_IdPatient",
                table: "Consultations");

            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "Consultations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MedicalRecordIdMedicalRecord",
                table: "Consultations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PatientIdPatient",
                table: "Consultations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Consultations_DoctorId",
                table: "Consultations",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Consultations_MedicalRecordIdMedicalRecord",
                table: "Consultations",
                column: "MedicalRecordIdMedicalRecord");

            migrationBuilder.CreateIndex(
                name: "IX_Consultations_PatientIdPatient",
                table: "Consultations",
                column: "PatientIdPatient");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultations_Doctors_DoctorId",
                table: "Consultations",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultations_MedicalRecords_MedicalRecordIdMedicalRecord",
                table: "Consultations",
                column: "MedicalRecordIdMedicalRecord",
                principalTable: "MedicalRecords",
                principalColumn: "IdMedicalRecord");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultations_Patients_PatientIdPatient",
                table: "Consultations",
                column: "PatientIdPatient",
                principalTable: "Patients",
                principalColumn: "IdPatient");
        }
    }
}
