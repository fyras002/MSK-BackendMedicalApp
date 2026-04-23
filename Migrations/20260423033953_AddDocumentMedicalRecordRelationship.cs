using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalAppBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddDocumentMedicalRecordRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_MedicalRecords_MedicalRecordIdMedicalRecord",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_MedicalRecordIdMedicalRecord",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "MedicalRecordIdMedicalRecord",
                table: "Documents");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_IdMedicalRecord",
                table: "Documents",
                column: "IdMedicalRecord");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_MedicalRecords_IdMedicalRecord",
                table: "Documents",
                column: "IdMedicalRecord",
                principalTable: "MedicalRecords",
                principalColumn: "IdMedicalRecord");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_MedicalRecords_IdMedicalRecord",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_IdMedicalRecord",
                table: "Documents");

            migrationBuilder.AddColumn<int>(
                name: "MedicalRecordIdMedicalRecord",
                table: "Documents",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Documents_MedicalRecordIdMedicalRecord",
                table: "Documents",
                column: "MedicalRecordIdMedicalRecord");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_MedicalRecords_MedicalRecordIdMedicalRecord",
                table: "Documents",
                column: "MedicalRecordIdMedicalRecord",
                principalTable: "MedicalRecords",
                principalColumn: "IdMedicalRecord");
        }
    }
}
