using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.DTO
{
    public class SensorReadingDTO
    {
        public Guid Id { get; set; }
        public string Timestamp { get; set; }
        public string MeasuredValue { get; set; }
    }
}
