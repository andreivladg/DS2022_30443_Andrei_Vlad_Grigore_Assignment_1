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
    public class DeviceRepository : IDeviceRepository
    {
        private readonly ApplicationDbContext _context;
        public DeviceRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateDevice(Device device)
        {
            device.Id = Guid.NewGuid();
            await _context.Devices.AddAsync(device);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Device>> GetAll()
        {
            var devices = await _context.Devices
                .Include(ud=>ud.User)
                .AsNoTracking()
                .ToListAsync();
            return devices;
        }

        public async Task<ICollection<Device>> GetUserDevices(Guid userId)
        {
            var devices = await _context.Devices
                .Include(ud => ud.User)
                .Where(ud=>ud.UserId == userId)
                .AsNoTracking()
                .ToListAsync();
            return devices;
        }

        public async Task<Device> GetById(Guid id)
        {
            var device = await _context.Devices
                .Where(d => d.Id == id)
                .AsNoTracking()
                .FirstOrDefaultAsync();
            return device;
        }
        public async Task<Device> GetByName(string name)
        {
            var device = await _context.Devices
                .Where(d => d.Description == name)
                .AsNoTracking()
                .FirstOrDefaultAsync();
            return device;
        }


        public async Task RemoveDevice(Guid id)
        {
            var device = await _context.Devices
                        .Where(u => u.Id == id)
                        .AsNoTracking()
                        .FirstOrDefaultAsync();
            _context.Remove(device);
            await _context.SaveChangesAsync();
        }

        public async Task<Device> GetWithConsumptions(Guid id)
        {
            var device = await _context.Devices
                .Include(d=>d.Consumptions)
                .Where(d => d.Id == id)
                .AsNoTracking()
                .FirstOrDefaultAsync();
            return device;
        }

        public async Task UpdateDevice(Device newDevice)
        {
            var device = await _context.Devices
                        .Where(u => u.Id == newDevice.Id)
                        .FirstOrDefaultAsync();
            _context.Entry(device).CurrentValues.SetValues(newDevice);
            await _context.SaveChangesAsync();
        }
    }
}
