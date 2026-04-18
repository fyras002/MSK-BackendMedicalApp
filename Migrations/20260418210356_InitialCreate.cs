using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalAppBackend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChatMessages",
                columns: table => new
                {
                    IdChatMessage = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdChat = table.Column<int>(type: "int", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserSender = table.Column<int>(type: "int", nullable: true),
                    Report = table.Column<bool>(type: "bit", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatMessages", x => x.IdChatMessage);
                });

            migrationBuilder.CreateTable(
                name: "Chats",
                columns: table => new
                {
                    IdChat = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUserSender = table.Column<int>(type: "int", nullable: true),
                    IdUserReciver = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AdminReview = table.Column<bool>(type: "bit", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chats", x => x.IdChat);
                });

            migrationBuilder.CreateTable(
                name: "DiseaseLists",
                columns: table => new
                {
                    IdDiseaseList = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleEnDiseaseList = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleFrDiseaseList = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleArDiseaseList = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescDiseaseList = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImgDiseaseList = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeCategDiseaseList = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiseaseLists", x => x.IdDiseaseList);
                });

            migrationBuilder.CreateTable(
                name: "InsuranceCompanies",
                columns: table => new
                {
                    IdCompany = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValidDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceCompanies", x => x.IdCompany);
                });

            migrationBuilder.CreateTable(
                name: "MedicalRecords",
                columns: table => new
                {
                    IdMedicalRecord = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPatient = table.Column<int>(type: "int", nullable: true),
                    BloodDraw = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Height = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weight = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedicalCheckup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HereditaryDiseases = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChronicDiseases = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalRecords", x => x.IdMedicalRecord);
                });

            migrationBuilder.CreateTable(
                name: "MedicationLists",
                columns: table => new
                {
                    IdMedication = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleMedication = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionMedication = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaysToTaken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgeRange = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SymptomesList = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Shouldnotbetaken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HowToTake = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicationLists", x => x.IdMedication);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specialities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecialityName = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    IdDocument = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleDocument = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionDocument = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AttachmentDocument = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateDocument = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdMedicalRecord = table.Column<int>(type: "int", nullable: true),
                    MedicalRecordIdMedicalRecord = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.IdDocument);
                    table.ForeignKey(
                        name: "FK_Documents_MedicalRecords_MedicalRecordIdMedicalRecord",
                        column: x => x.MedicalRecordIdMedicalRecord,
                        principalTable: "MedicalRecords",
                        principalColumn: "IdMedicalRecord");
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    IdPatient = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdMedicalRecord = table.Column<int>(type: "int", nullable: true),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CIN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notebook = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CNSS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: true),
                    MedicalRecordIdMedicalRecord = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.IdPatient);
                    table.ForeignKey(
                        name: "FK_Patients_MedicalRecords_MedicalRecordIdMedicalRecord",
                        column: x => x.MedicalRecordIdMedicalRecord,
                        principalTable: "MedicalRecords",
                        principalColumn: "IdMedicalRecord");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Prescriptions",
                columns: table => new
                {
                    IdPerscription = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DocName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedicationList = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdDocument = table.Column<int>(type: "int", nullable: true),
                    DocumentIdDocument = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescriptions", x => x.IdPerscription);
                    table.ForeignKey(
                        name: "FK_Prescriptions_Documents_DocumentIdDocument",
                        column: x => x.DocumentIdDocument,
                        principalTable: "Documents",
                        principalColumn: "IdDocument");
                });

            migrationBuilder.CreateTable(
                name: "Relationships",
                columns: table => new
                {
                    IdRelationships = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPatient1 = table.Column<int>(type: "int", nullable: true),
                    Patient1IdPatient = table.Column<int>(type: "int", nullable: true),
                    IdPatient2 = table.Column<int>(type: "int", nullable: true),
                    Patient2IdPatient = table.Column<int>(type: "int", nullable: true),
                    TitleRelationships = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NotesRelationships = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relationships", x => x.IdRelationships);
                    table.ForeignKey(
                        name: "FK_Relationships_Patients_Patient1IdPatient",
                        column: x => x.Patient1IdPatient,
                        principalTable: "Patients",
                        principalColumn: "IdPatient");
                    table.ForeignKey(
                        name: "FK_Relationships_Patients_Patient2IdPatient",
                        column: x => x.Patient2IdPatient,
                        principalTable: "Patients",
                        principalColumn: "IdPatient");
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    SpecialityId = table.Column<int>(type: "int", nullable: true),
                    LicenseNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Biography = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YearsOfExperience = table.Column<int>(type: "int", nullable: true),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctors_Specialities_SpecialityId",
                        column: x => x.SpecialityId,
                        principalTable: "Specialities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Doctors_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    IdAppointment = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientGender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Symptoms = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTimeAppointment = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsNewPatient = table.Column<bool>(type: "bit", nullable: true),
                    IdPatient = table.Column<int>(type: "int", nullable: true),
                    PatientIdPatient = table.Column<int>(type: "int", nullable: true),
                    IdDoctor = table.Column<int>(type: "int", nullable: true),
                    DoctorId = table.Column<int>(type: "int", nullable: true),
                    IdCompany = table.Column<int>(type: "int", nullable: true),
                    InsuranceCompanyIdCompany = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.IdAppointment);
                    table.ForeignKey(
                        name: "FK_Appointments_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Appointments_InsuranceCompanies_InsuranceCompanyIdCompany",
                        column: x => x.InsuranceCompanyIdCompany,
                        principalTable: "InsuranceCompanies",
                        principalColumn: "IdCompany");
                    table.ForeignKey(
                        name: "FK_Appointments_Patients_PatientIdPatient",
                        column: x => x.PatientIdPatient,
                        principalTable: "Patients",
                        principalColumn: "IdPatient");
                });

            migrationBuilder.CreateTable(
                name: "Consultations",
                columns: table => new
                {
                    IdConsultation = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPatient = table.Column<int>(type: "int", nullable: true),
                    PatientIdPatient = table.Column<int>(type: "int", nullable: true),
                    IdDoctor = table.Column<int>(type: "int", nullable: true),
                    DoctorId = table.Column<int>(type: "int", nullable: true),
                    IdMedicalRecord = table.Column<int>(type: "int", nullable: true),
                    MedicalRecordIdMedicalRecord = table.Column<int>(type: "int", nullable: true),
                    Tests = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SymptomsList = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedicationsList = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MyDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultations", x => x.IdConsultation);
                    table.ForeignKey(
                        name: "FK_Consultations_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Consultations_MedicalRecords_MedicalRecordIdMedicalRecord",
                        column: x => x.MedicalRecordIdMedicalRecord,
                        principalTable: "MedicalRecords",
                        principalColumn: "IdMedicalRecord");
                    table.ForeignKey(
                        name: "FK_Consultations_Patients_PatientIdPatient",
                        column: x => x.PatientIdPatient,
                        principalTable: "Patients",
                        principalColumn: "IdPatient");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DoctorId",
                table: "Appointments",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_InsuranceCompanyIdCompany",
                table: "Appointments",
                column: "InsuranceCompanyIdCompany");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientIdPatient",
                table: "Appointments",
                column: "PatientIdPatient");

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

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_SpecialityId",
                table: "Doctors",
                column: "SpecialityId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_UserId",
                table: "Doctors",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_MedicalRecordIdMedicalRecord",
                table: "Documents",
                column: "MedicalRecordIdMedicalRecord");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_MedicalRecordIdMedicalRecord",
                table: "Patients",
                column: "MedicalRecordIdMedicalRecord");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_DocumentIdDocument",
                table: "Prescriptions",
                column: "DocumentIdDocument");

            migrationBuilder.CreateIndex(
                name: "IX_Relationships_Patient1IdPatient",
                table: "Relationships",
                column: "Patient1IdPatient");

            migrationBuilder.CreateIndex(
                name: "IX_Relationships_Patient2IdPatient",
                table: "Relationships",
                column: "Patient2IdPatient");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "ChatMessages");

            migrationBuilder.DropTable(
                name: "Chats");

            migrationBuilder.DropTable(
                name: "Consultations");

            migrationBuilder.DropTable(
                name: "DiseaseLists");

            migrationBuilder.DropTable(
                name: "MedicationLists");

            migrationBuilder.DropTable(
                name: "Prescriptions");

            migrationBuilder.DropTable(
                name: "Relationships");

            migrationBuilder.DropTable(
                name: "InsuranceCompanies");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Specialities");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "MedicalRecords");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
