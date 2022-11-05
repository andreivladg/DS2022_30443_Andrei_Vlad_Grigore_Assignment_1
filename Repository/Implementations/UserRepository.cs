using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<AppUser> GetByIdAsync(Guid id)
        {
            var user = await _context.Users
                .Include(u=>u.Devices)
                .Where(u => u.Id == id)
                .FirstOrDefaultAsync();
            return user;
        }
        public async Task<AppUser> GetByNameAsync(string name)
        {
            var user = await _context.Users
                .Include(u => u.Devices)
                .Where(u => u.UserName == name)
                .FirstOrDefaultAsync();
            return user;
        }

        public async Task<ICollection<AppUser>> GetAllAsync()
        {
            var users = await _context.Users
                .Include(u=>u.Devices)
                .AsNoTracking()
                .ToListAsync();
            return users;
        }

        public async Task UpdateAsync(AppUser newUser)
        {
            var user = await _context.Users
                .Include(u=>u.Devices)
                .Where(u => u.Id == newUser.Id)
                .FirstOrDefaultAsync();
            _context.Entry(user).CurrentValues.SetValues(newUser);
            await _context.SaveChangesAsync();
        }

        public async Task CreateAysnc(AppUser user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(Guid id)
        {
            var user = await _context.Users
                 .Where(u => u.Id == id)
                 .FirstOrDefaultAsync();
            if (user != null)
            {
                _context.Entry(user).State = EntityState.Deleted;
                _context.Users.Remove(user);
            }
            await _context.SaveChangesAsync();
        }
    }
}
