using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<AppUser> GetByIdAsync(Guid id);
        Task<ICollection<AppUser>> GetAllAsync();
        Task UpdateAsync(AppUser user);
        Task CreateAysnc(AppUser user);
        Task RemoveAsync(Guid id);
        Task<AppUser> GetByNameAsync(string name);
    }
}
