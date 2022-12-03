using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Logic.DTO;
using Repository;
using Repository.Entities;

namespace Logic.Mappers
{
    public static class AppUserMapper
    {
        public static AppUserDTO ToDTO(this AppUser user)
        {
            AppUserDTO userDto = new AppUserDTO()
            {
                Id = user.Id,
                Username = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Devices = user.Devices.Count != 0 ? user.Devices.Select(d => d.ToDTO()).ToList() : new List<DeviceDTO>(),
                Role = user.Role.ToString()

            };
            return userDto;
        }

        public static AppUser FromDTO(this AppUserDTO userDto)
        {
            AppUser user = new AppUser()
            {
                Id = userDto.Id,
                UserName = userDto.Username,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Devices = userDto.Devices.Select(d => d.FromDTO()).ToList(),
                Role = Enum.Parse<AppRoleEnum>(userDto.Role)
            };
            return user;
        }
    }
}
