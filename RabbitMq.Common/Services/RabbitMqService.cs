using Microsoft.Extensions.Options;
using RabbitMq.Common.Models;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMq.Common.Services
{
    public interface IRabbitMqService
    {
        IConnection CreateChannel();
    }

    public class RabbitMqService : IRabbitMqService
    {
        private readonly RabbitMqConfiguration _configuration;
        public RabbitMqService(IOptions<RabbitMqConfiguration> options)
        {
            _configuration = options.Value;
        }
        public IConnection CreateChannel()
        {
            ConnectionFactory connection = new ConnectionFactory()
            {
                //UserName = "twlnacps", //_configuration.Username,
                //Password = "ai4rMKIGhr-Q722am9_DgWhJcOst7mfH",//"rabbitmq@693", //_configuration.Password,
                //HostName = "puffin.rmq2.cloudamqp.com", //_configuration.HostName
                //VirtualHost = "twlnacps",
                //Port = 5672,
                Uri = new Uri("amqps://twlnacps:ai4rMKIGhr-Q722am9_DgWhJcOst7mfH@puffin.rmq2.cloudamqp.com/twlnacps")
            };
            connection.DispatchConsumersAsync = true;
            var channel = connection.CreateConnection();
            return channel;

            //var factory = new ConnectionFactory
            //{
            //    Uri = new Uri("amqps://twlnacps:ai4rMKIGhr-Q722am9_DgWhJcOst7mfH@puffin.rmq2.cloudamqp.com/twlnacps")
            //};
        }
    }
}
