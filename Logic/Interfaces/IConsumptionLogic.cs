using Logic.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IConsumptionLogic
    {
        Task AddConsumption(ConsumptionDTO consumption);
    }
}
