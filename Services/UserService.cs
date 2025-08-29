using LAPUsersAPI.Data;
using LAPUsersAPI.Interfaces;
using LAPUsersAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LAPUsersAPI.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserModel>> GetUsersAsync()
        {
            return await _context.Users
                .Where(u => (bool)!u.IsDeleted)
                .ToListAsync();
        }

        public async Task<UserModel?> GetUserByIdAsync(int id)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Id == id && (bool)!u.IsDeleted);
        }

        public async Task<UserModel> AddUserAsync(UserModel user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<UserModel?> UpdateUserAsync(int id, UserModel user)
        {
            var existing = await _context.Users
                .FirstOrDefaultAsync(u => u.Id == id && (bool)!u.IsDeleted);

            if (existing == null) return null;

            existing.FirstName = user.FirstName;
            existing.LastName = user.LastName;
            existing.Email = user.Email;
            existing.Phone = user.Phone;
            existing.Gender = user.Gender;
            existing.Dob = user.Dob;
            existing.Nationality = user.Nationality;
            existing.Role = user.Role;
            existing.PictureUrl = user.PictureUrl;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return false;

            user.IsDeleted = true;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteUsersAsync(List<int> ids)
        {
            var users = await _context.Users
                .Where(u => ids.Contains(u.Id))
                .ToListAsync();

            if (!users.Any()) return false;

            foreach (var user in users)
            {
                user.IsDeleted = true;
            }

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
