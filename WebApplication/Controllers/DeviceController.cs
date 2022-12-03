using Logic.DTO;
using Logic.Interfaces;
using Logic.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Controllers
{
    [Authorize]
    public class DeviceController : Controller
    {
        private readonly IDeviceLogic _deviceLogic;
        private readonly IUserLogic _userLogic;
        public DeviceController(IDeviceLogic deviceLogic, IUserLogic userLogic)
        {
            _deviceLogic = deviceLogic;
            _userLogic = userLogic;
        }
        public async Task<IActionResult> UserDevices()
        {
            var user = await _userLogic.GetByName(User.Identity.Name);
            var devices = await _deviceLogic.GetUserDevices(user.Id);
            return View("UserDevices", devices);
        }
        public async Task<IActionResult> Delete(Guid id)
        {
            var device = await _deviceLogic.GetById(id);
            await _deviceLogic.RemoveDevice(device);
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "ADMINISTRATOR")]
        public async Task<IActionResult> Index()
        {
            var devices = await _deviceLogic.GetAll();
            return View("Index", devices);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var device = await _deviceLogic.GetById(id);
            return View(device);
        }
        [HttpPost]
        public async Task<IActionResult> EditDevice(DeviceDTO deviceDto)
        {
            await _deviceLogic.UpdateDevice(deviceDto);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Create()
        {
            var users = await _userLogic.GetAll();
            ViewBag.Users = users;
            return View();
        }

        [HttpPost,ActionName("Create")]
        public async Task<IActionResult> CreateDevice(DeviceDTO deviceDTO)
        {

            if (ModelState.IsValid)
            {
                await _deviceLogic.CreateDevice(deviceDTO);
                return RedirectToAction(nameof(Index));
            }
            return View("Create");
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var device = await _deviceLogic.GetWithConsumptions(id);
            var consumptions = device.Consumptions;
            if(consumptions == null)
            {
                return View(new List<ConsumptionDTO>());
            }
            return View(consumptions);
        }

        public async Task<IActionResult> GetHourlyConsumption(Guid deviceId)
        {
            var consumptions = await _deviceLogic.GetHourlyConsumptions(deviceId, DateTime.UtcNow.Day);
            return Ok(consumptions);
        } 
    }
}
