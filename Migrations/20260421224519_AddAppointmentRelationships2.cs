using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalAppBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddAppointmentRelationships2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Doctors_DoctorId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Patients_PatientIdPatient",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_DoctorId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_PatientIdPatient",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "PatientIdPatient",
                table: "Appointments");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_IdDoctor",
                table: "Appointments",
                column: "IdDoctor");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_IdPatient",
                table: "Appointments",
                column: "IdPatient");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Doctors_IdDoctor",
                table: "Appointments",
                column: "IdDoctor",
                principalTable: "Doctors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Patients_IdPatient",
                table: "Appointments",
                column: "IdPatient",
                principalTable: "Patients",
                principalColumn: "IdPatient");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Doctors_IdDoctor",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Patients_IdPatient",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_IdDoctor",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_IdPatient",
                table: "Appointments");

            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "Appointments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PatientIdPatient",
                table: "Appointments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DoctorId",
                table: "Appointments",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientIdPatient",
                table: "Appointments",
                column: "PatientIdPatient");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Doctors_DoctorId",
                table: "Appointments",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Patients_PatientIdPatient",
                table: "Appointments",
                column: "PatientIdPatient",
                principalTable: "Patients",
                principalColumn: "IdPatient");
        }
    }
}
