using Logic.DTO;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IUserLogic
    {
        Task<AppUserDTO> GetById(Guid id);
        Task<ICollection<AppUserDTO>> GetAll();
        Task Create(AppUserDTO user);
        Task Update(AppUserDTO user);
        Task Remove(AppUserDTO user);
        Task<AppUserDTO> GetByName(string name);
    }
}
