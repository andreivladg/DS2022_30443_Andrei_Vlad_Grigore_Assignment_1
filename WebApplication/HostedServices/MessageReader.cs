using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApplication.Services;

namespace WebApplication.HostedServices
{
    public class MessageReader : IHostedService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private Timer? _timer = null;

        public MessageReader(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public void Dispose()
        {
            _timer.Dispose();
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            using (var scope = _scopeFactory.CreateScope()) 
            {
                var consumer = scope.ServiceProvider.GetRequiredService<IRabbitConsumer>();
                var connection = consumer.CreateConnection();
                _timer = new Timer(async s => await ReadMessage(s, connection), null, TimeSpan.Zero, TimeSpan.FromSeconds(10));
            }
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public async Task ReadMessage(object? state, IConnection connection)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var consumer = scope.ServiceProvider.GetRequiredService<IRabbitConsumer>();
                await consumer.ReadFromQueue(connection);
            }
        }
    }
}
