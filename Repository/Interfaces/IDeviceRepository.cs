using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IDeviceRepository
    {
        Task<Device> GetById(Guid Id);
        Task<ICollection<Device>> GetAll();
        Task CreateDevice(Device device);
        Task UpdateDevice(Device newDevice);
        Task RemoveDevice(Guid id);
        Task<Device> GetByName(string name);
        Task<ICollection<Device>> GetUserDevices(Guid userId);
    }
}
