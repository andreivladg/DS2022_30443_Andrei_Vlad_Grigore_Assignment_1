using Logic.DTO;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Mappers
{
    public static class ConsumptionMapper
    {
        public static ConsumptionDTO ToDTO(this Consumption consumption)
        {
            ConsumptionDTO consumptionDto = new ConsumptionDTO()
            {
                Id = consumption.Id,
                DeviceId= consumption.DeviceId,
                ConsumptionDate = consumption.ConsumptionDate,
                kwh = consumption.kwh
            };
            return consumptionDto;
        }

        public static Consumption FromDTO(this ConsumptionDTO consumptionDto)
        {
            Consumption consumption = new Consumption()
            {
                Id = consumptionDto.Id,
                DeviceId = consumptionDto.DeviceId,
                ConsumptionDate = consumptionDto.ConsumptionDate,
                kwh = consumptionDto.kwh

            };
            return consumption;
        }
    }
}
