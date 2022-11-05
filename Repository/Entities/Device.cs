using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Entities
{
    public class Device
    {
        public Guid Id { get; set; }
        public AppUser User { get; set; }
        public Guid UserId { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string Number { get; set; }
        public string Street { get; set; }
        public ICollection<Consumption> Consumptions { get; set; }
    }
}
