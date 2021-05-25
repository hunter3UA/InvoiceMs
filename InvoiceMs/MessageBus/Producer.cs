using InvoiceMs.Models.Events;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceMs.MessageBus
{
    public class Producer
    {
        private static string rmqServiceAddress = "localhost";
        private static ConnectionFactory rmqConnection =
            new ConnectionFactory() { HostName = rmqServiceAddress };
        private static string invoiceMsQueueName = "InvoicesMs-events";
        public static void InvoicePaid(long cartID)
        {
            using(IConnection connection = rmqConnection.CreateConnection())
            {
                using(IModel channel = connection.CreateModel())
                {
                    channel.QueueDeclare(
                        queue: invoiceMsQueueName,
                        durable: false,
                        exclusive:false,
                        autoDelete:true
                        );
                    InvoiceEvent message = new InvoiceEvent() { EventType="InvoicePaid",PayLoad= cartID.ToString()};
                    string messageJSON = JsonConvert.SerializeObject(message);
                    byte[] messageBinary = Encoding.UTF8.GetBytes(messageJSON);
                    channel.BasicPublish(
                        exchange: "",
                        routingKey: invoiceMsQueueName,
                        mandatory: false,
                        basicProperties: null,
                        body: messageBinary
                        ); 
                }
            }
        }
    }
}
