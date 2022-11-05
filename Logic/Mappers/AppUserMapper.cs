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
                Email = user.Email,
                Devices = null, //user.Devices.Select(d => d.ToDTO()).ToList(), TO ADD
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
                Email = userDto.Email,
                Devices = null,// to add
                Role = Enum.Parse<AppRoleEnum>(userDto.Role)
            };
            return user;
        }
    }
}
