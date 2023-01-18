using GrpcService.Protos;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebApplication.HostedServices
{
    public class ChatService : IHostedService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private Timer? _timer = null;
        private ChatMessage Reply;
        public ChatService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public void Dispose()
        {
            _timer.Dispose();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(async s => await SendMessage(s,Reply), null, TimeSpan.Zero, TimeSpan.FromSeconds(10));
            return Task.CompletedTask;
        }

        public async Task ReceiveMessage(ChatMessage message)
        {
            Reply = message;
        }
        public async Task SendMessage(object? s, ChatMessage reply)
        {

        }
        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }
    }
}
