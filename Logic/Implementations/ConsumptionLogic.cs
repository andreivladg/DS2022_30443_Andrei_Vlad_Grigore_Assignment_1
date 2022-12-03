using Logic.DTO;
using Logic.Interfaces;
using Repository.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Implementations
{
    public class ConsumptionLogic : IConsumptionLogic
    {
        private readonly IConsumptionRepository _consumptionRepository;
        public ConsumptionLogic(IConsumptionRepository consumptionRepository)
        {
            _consumptionRepository = consumptionRepository;
        }
        public async Task AddConsumption(ConsumptionDTO consumptionDto)
        {
            var consumption = new Consumption()
            {
                Id = consumptionDto.Id,
                ConsumptionDate = consumptionDto.ConsumptionDate,
                DeviceId = consumptionDto.DeviceId,
                kwh = consumptionDto.kwh
            };
            await _consumptionRepository.AddConsumption(consumption);
        }
    }
}
