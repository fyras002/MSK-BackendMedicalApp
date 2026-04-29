using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalAppBackend.Migrations
{
    /// <inheritdoc />
    public partial class FixMedicalRecordCascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultations_MedicalRecords_IdMedicalRecord",
                table: "Consultations");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultations_MedicalRecords_IdMedicalRecord",
                table: "Consultations",
                column: "IdMedicalRecord",
                principalTable: "MedicalRecords",
                principalColumn: "IdMedicalRecord",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultations_MedicalRecords_IdMedicalRecord",
                table: "Consultations");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultations_MedicalRecords_IdMedicalRecord",
                table: "Consultations",
                column: "IdMedicalRecord",
                principalTable: "MedicalRecords",
                principalColumn: "IdMedicalRecord");
        }
    }
}
