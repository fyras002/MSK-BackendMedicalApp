using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalAppBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddPrescriptionRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_Documents_DocumentIdDocument",
                table: "Prescriptions");

            migrationBuilder.DropIndex(
                name: "IX_Prescriptions_DocumentIdDocument",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "DocumentIdDocument",
                table: "Prescriptions");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_IdDocument",
                table: "Prescriptions",
                column: "IdDocument");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_Documents_IdDocument",
                table: "Prescriptions",
                column: "IdDocument",
                principalTable: "Documents",
                principalColumn: "IdDocument");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_Documents_IdDocument",
                table: "Prescriptions");

            migrationBuilder.DropIndex(
                name: "IX_Prescriptions_IdDocument",
                table: "Prescriptions");

            migrationBuilder.AddColumn<int>(
                name: "DocumentIdDocument",
                table: "Prescriptions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_DocumentIdDocument",
                table: "Prescriptions",
                column: "DocumentIdDocument");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_Documents_DocumentIdDocument",
                table: "Prescriptions",
                column: "DocumentIdDocument",
                principalTable: "Documents",
                principalColumn: "IdDocument");
        }
    }
}
