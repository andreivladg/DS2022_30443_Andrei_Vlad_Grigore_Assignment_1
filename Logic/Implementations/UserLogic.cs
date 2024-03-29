﻿using Logic.DTO;
using Logic.Interfaces;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Logic.Mappers;
using System.Linq;
using Repository.Entities;
using Repository;

namespace Logic.Implementations
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserRepository _userRepository;

        public UserLogic(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task Create(AppUserDTO userDto)
        {
            var user = userDto.FromDTO();
            await _userRepository.CreateAysnc(user);
        }

        public async Task<ICollection<AppUserDTO>> GetAll()
        {
            var users = await _userRepository.GetAllAsync();
            return users.Select(u => u.ToDTO()).ToList();
        }

        public async Task<AppUserDTO> GetById(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return user.ToDTO();

        }

        public async Task<AppUserDTO> GetByName(string name)
        {
            var user = await _userRepository.GetByNameAsync(name);
            return user.ToDTO();

        }

        public async Task Remove(AppUserDTO user)
        {
            await _userRepository.RemoveAsync(user.Id);
        }

        public async Task Update(AppUserDTO userDTO)
        {
            var user = await _userRepository.GetByIdAsync(userDTO.Id);
            user.UserName = userDTO.Username;
            user.FirstName = userDTO.FirstName;
            user.LastName = userDTO.LastName;
            user.Devices = userDTO.Devices == null ? new List<Device>() : userDTO.Devices.Select(d => d.FromDTO()).ToList();
            user.Role = Enum.Parse<AppRoleEnum>(userDTO.Role);
            await _userRepository.UpdateAsync(user);
        }

    }
}
