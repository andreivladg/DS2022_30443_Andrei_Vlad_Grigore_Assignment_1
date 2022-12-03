﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.DTO
{
    public class AppUserDTO
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public ICollection<DeviceDTO> Devices { get; set; } 
    }
}
