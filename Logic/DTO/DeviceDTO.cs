using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.DTO
{
    public class DeviceDTO
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public ICollection<ConsumptionDTO> Consumptions { get; set; }
    }

}
