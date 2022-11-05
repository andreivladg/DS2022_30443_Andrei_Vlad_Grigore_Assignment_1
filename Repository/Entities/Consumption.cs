using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Entities
{
    public class Consumption
    {
        public Guid Id { get; set; }
        public Device Device { get; set; }
        public Guid DeviceId { get; set; }
        public DateTime ConsumptionDate { get; set; }
        public decimal kwh { get; set; }
    }
}
