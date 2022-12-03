using Repository.Data;
using Repository.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementations
{
    public class ConsumptionRepository : IConsumptionRepository
    {
        private readonly ApplicationDbContext _context;
        public ConsumptionRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddConsumption(Consumption consumption)
        {
            await _context.Consumptions
                .AddAsync(consumption);
            await _context.SaveChangesAsync();
        }
    }
}
