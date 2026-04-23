using MedicalAppBackend.DTOs;

namespace MedicalAppBackend.Services.Interfaces
{
    public interface IAppointmentService
    {
        Task<List<AppointmentDto>> GetAllAppointmentsAsync();
        Task<AppointmentDto?> GetAppointmentByIdAsync(int id);
        Task<List<AppointmentDto>> GetAppointmentsByDoctorAsync(int doctorId);
        Task<List<AppointmentDto>> GetAppointmentsByPatientAsync(int patientId);
        Task<List<AppointmentDto>> GetAppointmentsByDateAsync(DateTime date);
        Task<AppointmentDto> CreateAppointmentAsync(CreateAppointmentDto dto);
        Task<bool> UpdateAppointmentAsync(int id, UpdateAppointmentDto dto);
        Task<bool> DeleteAppointmentAsync(int id);
    }
}