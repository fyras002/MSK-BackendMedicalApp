using MedicalAppBackend.Data;
using MedicalAppBackend.DTOs;
using MedicalAppBackend.Models;
using MedicalAppBackend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedicalAppBackend.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly AppDbContext _context;

        public AppointmentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<AppointmentDto>> GetAllAppointmentsAsync()
        {
            return await _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                    .ThenInclude(d => d.User)
                .Include(a => a.Doctor)
                    .ThenInclude(d => d.Speciality)
                .Include(a => a.InsuranceCompany)
                .Select(a => new AppointmentDto
                {
                    IdAppointment = a.IdAppointment,
                    PatientName = a.PatientName,
                    PatientPhone = a.PatientPhone,
                    PatientEmail = a.PatientEmail,
                    PatientGender = a.PatientGender,
                    Symptoms = a.Symptoms,
                    Reason = a.Reason,
                    DateTimeAppointment = a.DateTimeAppointment,
                    IsNewPatient = a.IsNewPatient,
                    IdPatient = a.IdPatient,
                    PatientFullName = a.Patient != null ? $"{a.Patient.Firstname} {a.Patient.Lastname}" : null,
                    IdDoctor = a.IdDoctor,
                    DoctorFullName = a.Doctor != null && a.Doctor.User != null ? $"{a.Doctor.User.Firstname} {a.Doctor.User.Lastname}" : null,
                    DoctorSpeciality = a.Doctor != null && a.Doctor.Speciality != null ? a.Doctor.Speciality.SpecialityName.ToString() : null,
                    IdCompany = a.IdCompany,
                    InsuranceCompanyName = a.InsuranceCompany != null ? a.InsuranceCompany.CompanyName : null
                })
                .OrderByDescending(a => a.DateTimeAppointment)
                .ToListAsync();
        }

        public async Task<AppointmentDto?> GetAppointmentByIdAsync(int id)
        {
            return await _context.Appointments
                .Where(a => a.IdAppointment == id)
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                    .ThenInclude(d => d.User)
                .Include(a => a.Doctor)
                    .ThenInclude(d => d.Speciality)
                .Include(a => a.InsuranceCompany)
                .Select(a => new AppointmentDto
                {
                    IdAppointment = a.IdAppointment,
                    PatientName = a.PatientName,
                    PatientPhone = a.PatientPhone,
                    PatientEmail = a.PatientEmail,
                    PatientGender = a.PatientGender,
                    Symptoms = a.Symptoms,
                    Reason = a.Reason,
                    DateTimeAppointment = a.DateTimeAppointment,
                    IsNewPatient = a.IsNewPatient,
                    IdPatient = a.IdPatient,
                    PatientFullName = a.Patient != null ? $"{a.Patient.Firstname} {a.Patient.Lastname}" : null,
                    IdDoctor = a.IdDoctor,
                    DoctorFullName = a.Doctor != null && a.Doctor.User != null ? $"{a.Doctor.User.Firstname} {a.Doctor.User.Lastname}" : null,
                    DoctorSpeciality = a.Doctor != null && a.Doctor.Speciality != null ? a.Doctor.Speciality.SpecialityName.ToString() : null,
                    IdCompany = a.IdCompany,
                    InsuranceCompanyName = a.InsuranceCompany != null ? a.InsuranceCompany.CompanyName : null
                })
                .FirstOrDefaultAsync();
        }

        public async Task<List<AppointmentDto>> GetAppointmentsByDoctorAsync(int doctorId)
        {
            return await _context.Appointments
                .Where(a => a.IdDoctor == doctorId)
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                    .ThenInclude(d => d.User)
                .Include(a => a.Doctor)
                    .ThenInclude(d => d.Speciality)
                .Include(a => a.InsuranceCompany)
                .Select(a => new AppointmentDto
                {
                    IdAppointment = a.IdAppointment,
                    PatientName = a.PatientName,
                    PatientPhone = a.PatientPhone,
                    PatientEmail = a.PatientEmail,
                    PatientGender = a.PatientGender,
                    Symptoms = a.Symptoms,
                    Reason = a.Reason,
                    DateTimeAppointment = a.DateTimeAppointment,
                    IsNewPatient = a.IsNewPatient,
                    IdPatient = a.IdPatient,
                    PatientFullName = a.Patient != null ? $"{a.Patient.Firstname} {a.Patient.Lastname}" : null,
                    IdDoctor = a.IdDoctor,
                    DoctorFullName = a.Doctor != null && a.Doctor.User != null ? $"{a.Doctor.User.Firstname} {a.Doctor.User.Lastname}" : null,
                    DoctorSpeciality = a.Doctor != null && a.Doctor.Speciality != null ? a.Doctor.Speciality.SpecialityName.ToString() : null,
                    IdCompany = a.IdCompany,
                    InsuranceCompanyName = a.InsuranceCompany != null ? a.InsuranceCompany.CompanyName : null
                })
                .OrderByDescending(a => a.DateTimeAppointment)
                .ToListAsync();
        }

        public async Task<List<AppointmentDto>> GetAppointmentsByPatientAsync(int patientId)
        {
            return await _context.Appointments
                .Where(a => a.IdPatient == patientId)
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                    .ThenInclude(d => d.User)
                .Include(a => a.Doctor)
                    .ThenInclude(d => d.Speciality)
                .Include(a => a.InsuranceCompany)
                .Select(a => new AppointmentDto
                {
                    IdAppointment = a.IdAppointment,
                    PatientName = a.PatientName,
                    PatientPhone = a.PatientPhone,
                    PatientEmail = a.PatientEmail,
                    PatientGender = a.PatientGender,
                    Symptoms = a.Symptoms,
                    Reason = a.Reason,
                    DateTimeAppointment = a.DateTimeAppointment,
                    IsNewPatient = a.IsNewPatient,
                    IdPatient = a.IdPatient,
                    PatientFullName = a.Patient != null ? $"{a.Patient.Firstname} {a.Patient.Lastname}" : null,
                    IdDoctor = a.IdDoctor,
                    DoctorFullName = a.Doctor != null && a.Doctor.User != null ? $"{a.Doctor.User.Firstname} {a.Doctor.User.Lastname}" : null,
                    DoctorSpeciality = a.Doctor != null && a.Doctor.Speciality != null ? a.Doctor.Speciality.SpecialityName.ToString() : null,
                    IdCompany = a.IdCompany,
                    InsuranceCompanyName = a.InsuranceCompany != null ? a.InsuranceCompany.CompanyName : null
                })
                .OrderByDescending(a => a.DateTimeAppointment)
                .ToListAsync();
        }

        public async Task<List<AppointmentDto>> GetAppointmentsByDateAsync(DateTime date)
        {
            return await _context.Appointments
                .Where(a => a.DateTimeAppointment.HasValue && a.DateTimeAppointment.Value.Date == date.Date)
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                    .ThenInclude(d => d.User)
                .Include(a => a.Doctor)
                    .ThenInclude(d => d.Speciality)
                .Include(a => a.InsuranceCompany)
                .Select(a => new AppointmentDto
                {
                    IdAppointment = a.IdAppointment,
                    PatientName = a.PatientName,
                    PatientPhone = a.PatientPhone,
                    PatientEmail = a.PatientEmail,
                    PatientGender = a.PatientGender,
                    Symptoms = a.Symptoms,
                    Reason = a.Reason,
                    DateTimeAppointment = a.DateTimeAppointment,
                    IsNewPatient = a.IsNewPatient,
                    IdPatient = a.IdPatient,
                    PatientFullName = a.Patient != null ? $"{a.Patient.Firstname} {a.Patient.Lastname}" : null,
                    IdDoctor = a.IdDoctor,
                    DoctorFullName = a.Doctor != null && a.Doctor.User != null ? $"{a.Doctor.User.Firstname} {a.Doctor.User.Lastname}" : null,
                    DoctorSpeciality = a.Doctor != null && a.Doctor.Speciality != null ? a.Doctor.Speciality.SpecialityName.ToString() : null,
                    IdCompany = a.IdCompany,
                    InsuranceCompanyName = a.InsuranceCompany != null ? a.InsuranceCompany.CompanyName : null
                })
                .OrderBy(a => a.DateTimeAppointment)
                .ToListAsync();
        }

        public async Task<AppointmentDto> CreateAppointmentAsync(CreateAppointmentDto dto)
        {
            var appointment = new Appointments
            {
                PatientName = dto.PatientName,
                PatientPhone = dto.PatientPhone,
                PatientEmail = dto.PatientEmail,
                PatientGender = dto.PatientGender,
                Symptoms = dto.Symptoms,
                Reason = dto.Reason,
                DateTimeAppointment = dto.DateTimeAppointment,
                IsNewPatient = dto.IsNewPatient ?? true,
                IdPatient = dto.IdPatient,
                IdDoctor = dto.IdDoctor,
                IdCompany = dto.IdCompany
            };

            await _context.Appointments.AddAsync(appointment);
            await _context.SaveChangesAsync();

            return (await GetAppointmentByIdAsync(appointment.IdAppointment))!;
        }

        public async Task<bool> UpdateAppointmentAsync(int id, UpdateAppointmentDto dto)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null)
                return false;

            if (dto.PatientName != null)
                appointment.PatientName = dto.PatientName;
            if (dto.PatientPhone != null)
                appointment.PatientPhone = dto.PatientPhone;
            if (dto.PatientEmail != null)
                appointment.PatientEmail = dto.PatientEmail;
            if (dto.PatientGender != null)
                appointment.PatientGender = dto.PatientGender;
            if (dto.Symptoms != null)
                appointment.Symptoms = dto.Symptoms;
            if (dto.Reason != null)
                appointment.Reason = dto.Reason;
            if (dto.DateTimeAppointment.HasValue)
                appointment.DateTimeAppointment = dto.DateTimeAppointment;
            if (dto.IsNewPatient.HasValue)
                appointment.IsNewPatient = dto.IsNewPatient;
            if (dto.IdPatient.HasValue)
                appointment.IdPatient = dto.IdPatient;
            if (dto.IdDoctor.HasValue)
                appointment.IdDoctor = dto.IdDoctor;
            if (dto.IdCompany.HasValue)
                appointment.IdCompany = dto.IdCompany;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAppointmentAsync(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null)
                return false;

            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}