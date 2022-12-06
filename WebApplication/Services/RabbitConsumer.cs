using Logic.DTO;
using Logic.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Hubs;

namespace WebApplication.Services
{
    public class RabbitConsumer : IRabbitConsumer
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly NotificationsHub _notifyHub;
        public RabbitConsumer(IServiceScopeFactory scopeFactory, NotificationsHub notifyHub)
        {
            _scopeFactory = scopeFactory;
            _notifyHub = notifyHub;
        }
        public IConnection CreateConnection()
        {
            var factory = new ConnectionFactory()
            {
                UserName = "hrbhrnve",
                VirtualHost = "hrbhrnve",
                Password = "0b1f1MYorDX_bmI5P1aLgMg98OYDMmXe",
                Uri = new Uri("amqps://hrbhrnve:0b1f1MYorDX_bmI5P1aLgMg98OYDMmXe@goose.rmq2.cloudamqp.com/hrbhrnve")
            };
            var connection = factory.CreateConnection();

            return connection;
        }

        public async Task ReadFromQueue(IConnection connection)
        {
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare("measurements", exclusive: false, durable: true,
                    autoDelete: false, arguments: null);
                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += async (model, eventArgs) =>
                {
                    var body = eventArgs.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    var sensorReadingDTO = JsonConvert.DeserializeObject<SensorReadingDTO>(message);
                    var consumptionDTO = new ConsumptionDTO()
                    {
                        Id = Guid.NewGuid(),
                        DeviceId = sensorReadingDTO.Id,
                        ConsumptionDate = DateTime.Parse(sensorReadingDTO.Timestamp),
                        kwh = Decimal.Parse(sensorReadingDTO.MeasuredValue)

                    };
                    using (var scope = _scopeFactory.CreateScope())
                    {
                        var consumptionLogic = scope.ServiceProvider.GetRequiredService<IConsumptionLogic>();
                        await consumptionLogic.AddConsumption(consumptionDTO);
                        await _notifyHub.SendMessage(consumptionDTO.kwh.ToString());
                    }
                    Console.WriteLine(sensorReadingDTO.MeasuredValue);
                };
                channel.BasicConsume(queue: "measurements", autoAck: true, consumer: consumer);
            }
        }
    }
}
