using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.DTO
{
    public class ConsumptionDTO
    {
        public Guid Id { get; set; }
        public Guid DeviceId { get; set; }
        public DateTime ConsumptionDate { get; set; }
        public decimal kwh { get; set; }
    }
}
