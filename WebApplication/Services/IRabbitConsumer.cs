using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Services
{
    public interface IRabbitConsumer
    {
        IConnection CreateConnection();
        Task ReadFromQueue(IConnection connection);
    }
}
