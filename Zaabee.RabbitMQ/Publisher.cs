using System.Threading.Tasks;
using RabbitMQ.Client;

namespace Zaabee.RabbitMQ
{
    public partial class ZaabeeRabbitMqClient
    {
        public void PublishEvent<T>(T @event) =>
            PublishEvent(GetTypeName(typeof(T)), @event);

        public void PublishEvent<T>(string exchangeName, T @event) =>
            PublishEvent(exchangeName, _serializer.Serialize(@event));

        public void PublishEvent(string exchangeName, byte[] body)
        {
            var exchangeParam = new ExchangeParam {Exchange = exchangeName};
            using (var channel = GetPublisherChannel(exchangeParam, null))
            {
                var properties = channel.CreateBasicProperties();
                properties.Persistent = true;
                var routingKey = exchangeParam.Exchange;

                channel.BasicPublish(exchangeParam.Exchange, routingKey, properties, body);
            }
        }

        public void PublishMessage<T>(T message) =>
            PublishMessage(GetTypeName(typeof(T)), message);

        public void PublishMessage<T>(string exchangeName, T message) =>
            PublishMessage(exchangeName, _serializer.Serialize(message));

        public void PublishMessage(string exchangeName, byte[] body)
        {
            var exchangeParam = new ExchangeParam {Exchange = exchangeName, Durable = false};
            using (var channel = GetPublisherChannel(exchangeParam, null))
            {
                var routingKey = exchangeParam.Exchange;
                channel.BasicPublish(exchangeParam.Exchange, routingKey, null, body);
            }
        }

        public async Task PublishEventAsync<T>(T @event) =>
            await Task.Run(() => { PublishEvent(@event); });

        public async Task PublishEventAsync<T>(string exchangeName, T @event) =>
            await Task.Run(() => { PublishEvent(exchangeName, @event); });

        public async Task PublishEventAsync(string exchangeName, byte[] body) =>
            await Task.Run(() => { PublishEvent(exchangeName, body); });

        public async Task PublishMessageAsync<T>(T message) =>
            await Task.Run(() => { PublishMessage(message); });

        public async Task PublishMessageAsync<T>(string exchangeName, T message) =>
            await Task.Run(() => { PublishMessage(exchangeName, message); });

        public async Task PublishMessageAsync(string exchangeName, byte[] body) =>
            await Task.Run(() => { PublishMessage(exchangeName, body); });

        private IModel GetPublisherChannel(ExchangeParam exchangeParam, QueueParam queueParam)
        {
            var channel = _conn.CreateModel();

            channel.ExchangeDeclare(exchange: exchangeParam.Exchange, type: exchangeParam.Type.ToString().ToLower(),
                durable: exchangeParam.Durable, autoDelete: exchangeParam.AutoDelete,
                arguments: exchangeParam.Arguments);

            if (queueParam is null) return channel;

            channel.QueueDeclare(queue: queueParam.Queue, durable: queueParam.Durable,
                exclusive: queueParam.Exclusive, autoDelete: queueParam.AutoDelete,
                arguments: queueParam.Arguments);
            channel.QueueBind(queue: queueParam.Queue, exchange: exchangeParam.Exchange,
                routingKey: queueParam.Queue);

            return channel;
        }
    }
}