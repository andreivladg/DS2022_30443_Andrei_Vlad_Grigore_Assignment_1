using Logic.DTO;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic.Mappers
{
    public static class DeviceMapper
    {
        public static DeviceDTO ToDTO(this Device device)
        {
            DeviceDTO deviceDto = new DeviceDTO()
            {
                Id = device.Id,
                UserId = device.UserId,
                Description = device.Description,
                City = device.City,
                Street = device.Street,
                Number = Int32.Parse(device.Number),
                Consumptions = device.Consumptions != null ? device.Consumptions.Select(c => c.ToDTO()).ToList() : new List<ConsumptionDTO>()
            };
            return deviceDto;
        }

        public static Device FromDTO(this DeviceDTO deviceDto)
        {
            Device device = new Device()
            {
                Id = (deviceDto.Id == null? Guid.NewGuid():deviceDto.Id),
                UserId = deviceDto.UserId,
                Description = deviceDto.Description,
                Street = deviceDto.Street,
                City = deviceDto.City,
                Number = deviceDto.Number.ToString(),
                Consumptions = deviceDto.Consumptions != null ? deviceDto.Consumptions.Select(c => c.FromDTO()).ToList() : new List<Consumption>()
            };
            return device;
        }
    }
}
