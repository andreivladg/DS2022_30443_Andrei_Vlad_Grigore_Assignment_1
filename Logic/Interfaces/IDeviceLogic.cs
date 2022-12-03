using Logic.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IDeviceLogic
    {
        Task<DeviceDTO> GetById(Guid id);
        Task<ICollection<DeviceDTO>> GetAll();
        Task CreateDevice(DeviceDTO device);
        Task UpdateDevice(DeviceDTO device);
        Task RemoveDevice(DeviceDTO device);
        Task<DeviceDTO> GetByName(string name);
        Task<ICollection<DeviceDTO>> GetUserDevices(Guid userId);
        Task<DeviceDTO> GetWithConsumptions(Guid id);
        Task<ICollection<decimal>> GetHourlyConsumptions(Guid deviceId,int day);
    }
}
