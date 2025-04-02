using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Common.Infrastructure
{
    public static class QueueFactory
    {
        /*
            queue : Oluşturulacak kuyruğun adını belirliyoruz.
            durable : Normal şartlarda kuyruktaki mesajların hepsi bellek üzerinde dizilirler. Hal böyleyken RabbitMQ sunucuları bir sebepten dolayı restart atarlarsa tüm veriler kaybolabilir. durable parametresine true değerini verirsek eğer verilerimiz güvenli bir şekilde sağlamlaştırılacak yani fiziksel hale getirilecektir.
            exclusive : Oluşturulacak bu kuyruğa birden fazla kanalın bağlanıp, bağlanmayacağını belirtir.
            autoDelete : True değerine karşılık tüm mesajlar bitince kuyruğu otomatik imha eder.
         */
        /*
            exchange : Eğer exchange kullanmıyorsanız boş bırakınız. Böylece default exchange devreye girecek ve kullanılmış olacaktır.
            routingKey : Eğer ki default exchange kullanıyorsanız routingKey olarak oluşturduğunuz kuyruğa verdiğiniz ismin birebir aynısını veriniz.
            body : Gönderilecek mesajın ta kendisidir.
         */

        public static async void SendMessageToExchange(string exchangeName,
                                               string exchangeType,
                                               string queueName,
                                               object obj)
        {
            var consumer = await CreateBasicConsumer();
            consumer = await consumer.EnsureExchange(exchangeName, exchangeType);
            consumer = await consumer.EnsureQueue(queueName, exchangeName);

            var channel = consumer.Channel;
            var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(obj));

            await channel.BasicPublishAsync(exchange: exchangeName,
                                 routingKey: queueName,
                                 mandatory: false,
                                 body: body);

        }
        public async static Task<AsyncEventingBasicConsumer> CreateBasicConsumer()
        {
            var factory = new ConnectionFactory()
            {
                HostName = ApplicationConstants.RabbitMqHost,
            };
            var connection = await factory.CreateConnectionAsync();
            var channel = await connection.CreateChannelAsync();

            return new AsyncEventingBasicConsumer(channel);
        }
        public async static Task<AsyncEventingBasicConsumer> EnsureExchange(this AsyncEventingBasicConsumer consumer,
                                                                            string exchangeName,
                                                                            string exchangeType = ApplicationConstants.DefaultExchangeType)
        {
            await consumer.Channel.ExchangeDeclareAsync(exchange: exchangeName, type: exchangeType, durable: false, autoDelete: false);
            return consumer;
        }
        public async static Task<AsyncEventingBasicConsumer> EnsureQueue(this AsyncEventingBasicConsumer consumer,
                                                                         string queueName,
                                                                         string exchangeName)
        {
            await consumer.Channel.QueueDeclareAsync(queue: queueName,
                                               durable: false,
                                               exclusive: false,
                                               autoDelete: false,
                                               null);
            await consumer.Channel.QueueBindAsync(queue: queueName, exchange: exchangeName, routingKey: queueName);
            return consumer;
        }
    }
}
