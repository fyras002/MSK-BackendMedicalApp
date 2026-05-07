using MedicalAppBackend.Data;
using MedicalAppBackend.DTOs;
using MedicalAppBackend.Models;
using MedicalAppBackend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedicalAppBackend.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        private readonly JwtService _jwtService;

        public UserService(AppDbContext context, JwtService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }

        public async Task<List<UserDto>> GetAllUsersAsync()
        {
            return await _context.Users
                .Select(u => new UserDto
                {
                    Id = u.Id,
                    Username = u.Username,
                    Email = u.Email,
                    Firstname = u.Firstname,
                    Lastname = u.Lastname,
                    Photo = u.Photo,
                    Role = u.Role
                })
                .ToListAsync();
        }
        public async Task<UserDto?> UpdateUserAsync(int id, UpdateUserDto dto)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return null;

            if (!string.IsNullOrEmpty(dto.Firstname)) user.Firstname = dto.Firstname;
            if (!string.IsNullOrEmpty(dto.Lastname)) user.Lastname = dto.Lastname;
            if (!string.IsNullOrEmpty(dto.Email)) user.Email = dto.Email;

            await _context.SaveChangesAsync();
            return await GetUserByIdAsync(id);
        }

        public async Task<UserDto?> UploadPhotoAsync(int id, IFormFile file)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return null;

            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var path = Path.Combine("wwwroot", "images", "users", fileName);

            Directory.CreateDirectory(Path.GetDirectoryName(path)!);
            using var stream = new FileStream(path, FileMode.Create);
            await file.CopyToAsync(stream);

            user.Photo = $"http://localhost:5039/images/users/{fileName}";
            await _context.SaveChangesAsync();
            return await GetUserByIdAsync(id);
        }

        public async Task<UserDto?> GetUserByIdAsync(int id)
        {
            return await _context.Users
                .Where(u => u.Id == id)
                .Select(u => new UserDto
                {
                    Id = u.Id,
                    Username = u.Username,
                    Email = u.Email,
                    Firstname = u.Firstname,
                    Lastname = u.Lastname,
                    Photo = u.Photo,
                    Role = u.Role
                })
                .FirstOrDefaultAsync();
        }

        public async Task<UserDto> CreateUserAsync(CreateUserDto dto)
        {
            var user = new Users
            {
                Username = dto.Username,
                Email = dto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                Firstname = dto.Firstname,
                Lastname = dto.Lastname,
                Role = dto.Role
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                Photo = user.Photo,
                Role = user.Role
            };
        }

        public async Task<UserDto?> LoginAsync(LoginUserDto dto)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == dto.Username);

            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
                return null;

            var token = _jwtService.GenerateToken(user.Id, user.Username, user.Role ?? 0);

            return new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                Photo = user.Photo,
                Role = user.Role,
                Token = token
            };
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return false;

            var doctor = await _context.Doctors.FirstOrDefaultAsync(d => d.UserId == id);
            if (doctor != null)
                _context.Doctors.Remove(doctor);

            var patient = await _context.Patients.FirstOrDefaultAsync(p => p.UserId == id);
            if (patient != null)
                _context.Patients.Remove(patient);

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}