using MedicalAppBackend.Data;
using MedicalAppBackend.Services;
using MedicalAppBackend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();

builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<IDoctorService, DoctorService>();
builder.Services.AddScoped<IInsuranceCompanyService, InsuranceCompanyService>();
builder.Services.AddScoped<ISpecialityService, SpecialityService>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddScoped<IMedicalRecordService, MedicalRecordService>();
builder.Services.AddScoped<IDocumentService, DocumentService>();
var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();