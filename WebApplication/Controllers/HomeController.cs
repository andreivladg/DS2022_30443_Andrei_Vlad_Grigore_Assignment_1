using Grpc.Core;
using Grpc.Net.Client;
using GrpcService.Protos;
using Logic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using WebApplication.Hubs;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserLogic _userLogic;
        private readonly GrpcChannel _channel;
        private readonly Messenger.MessengerClient _client;
        private readonly ChatHub _chatHub;
        private static ChatMessage _reply;
        public HomeController(ILogger<HomeController> logger, IUserLogic userLogic, ChatHub chatHub)
        {
            _logger = logger;
            _userLogic = userLogic;
            _channel = GrpcChannel.ForAddress("https://localhost:5002");
            _client = new Messenger.MessengerClient(_channel);
            _chatHub = chatHub;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> AdminChat()
        {
            var admin = await _userLogic.GetByName("Admin");
            return View(admin);
        }

        [HttpPost]
        public async Task Typing()
        {
            var message = new ChatMessageVm();

            await _chatHub.SendMessage(message);

        }

        [HttpPost]
        public async Task SendMessage(ChatMessageVm chatMessage)
        {
            var input = new ChatMessage
            {
                Sender = chatMessage.Sender,
                Username = chatMessage.Username,
                Message = chatMessage.Message
            };
           // var reply = await _client.SendMessageAsync(input);
            var user = await _userLogic.GetByName(input.Username);
            var message = new ChatMessageVm
            {
                UserId = user.Id,
                Sender = input.Sender,
                Username = input.Username,
                Message = input.Message
            };
            
            await _chatHub.SendMessage(message);
            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
