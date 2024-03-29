﻿using Logic.DTO;
using Logic.Interfaces;
using Logic.Mappers;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Implementations
{
    public class DeviceLogic : IDeviceLogic
    {
        private readonly IDeviceRepository _deviceRepository;
        public DeviceLogic(IDeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }
        public async Task CreateDevice(DeviceDTO device)
        {
            await _deviceRepository.CreateDevice(device.FromDTO());
        }

        public async Task<ICollection<DeviceDTO>> GetAll()
        {
            var devices = await _deviceRepository.GetAll();
            return devices.Select(d => d.ToDTO()).ToList();
        }

        public async Task<ICollection<DeviceDTO>> GetUserDevices(Guid userId)
        {
            var devices = await _deviceRepository.GetUserDevices(userId);
            return devices.Select(d => d.ToDTO()).ToList();
        }

        public async Task<DeviceDTO> GetById(Guid id)
        {
            var device = await _deviceRepository.GetById(id);
            return device.ToDTO();
        }
        public async Task<DeviceDTO> GetByName(string name)
        {
            var device = await _deviceRepository.GetByName(name);
            return device.ToDTO();
        }

        public async Task RemoveDevice(DeviceDTO device)
        {
            await _deviceRepository.RemoveDevice(device.Id);
        }

        public async Task UpdateDevice(DeviceDTO device)
        {
           await _deviceRepository.UpdateDevice(device.FromDTO());
        }

        public async Task<DeviceDTO> GetWithConsumptions(Guid id)
        {
            var device = await _deviceRepository.GetWithConsumptions(id);
            return device.ToDTO();
        }

        public async Task<ICollection<decimal>> GetHourlyConsumptions(Guid deviceId, int day)
        {
            var device = await _deviceRepository.GetWithConsumptions(deviceId);
            var dayConsumptions = device.Consumptions.Where(c => c.ConsumptionDate.Day == day).ToList();
            var hourlyConsumptions = new List<decimal>();
            for(int i = 0; i < 23; i++)
            {
                decimal data = 0;
                foreach(var consumption in dayConsumptions)
                {
                    if(consumption.ConsumptionDate.Hour == i)
                    {
                        data += consumption.kwh;
                    }
                }
                hourlyConsumptions.Add(data);
            }
            return hourlyConsumptions;
        }
    }
}
