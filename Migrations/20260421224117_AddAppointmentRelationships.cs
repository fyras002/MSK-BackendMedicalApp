using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalAppBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddAppointmentRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_InsuranceCompanies_InsuranceCompanyIdCompany",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_InsuranceCompanyIdCompany",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "InsuranceCompanyIdCompany",
                table: "Appointments");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_IdCompany",
                table: "Appointments",
                column: "IdCompany");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_InsuranceCompanies_IdCompany",
                table: "Appointments",
                column: "IdCompany",
                principalTable: "InsuranceCompanies",
                principalColumn: "IdCompany");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_InsuranceCompanies_IdCompany",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_IdCompany",
                table: "Appointments");

            migrationBuilder.AddColumn<int>(
                name: "InsuranceCompanyIdCompany",
                table: "Appointments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_InsuranceCompanyIdCompany",
                table: "Appointments",
                column: "InsuranceCompanyIdCompany");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_InsuranceCompanies_InsuranceCompanyIdCompany",
                table: "Appointments",
                column: "InsuranceCompanyIdCompany",
                principalTable: "InsuranceCompanies",
                principalColumn: "IdCompany");
        }
    }
}
