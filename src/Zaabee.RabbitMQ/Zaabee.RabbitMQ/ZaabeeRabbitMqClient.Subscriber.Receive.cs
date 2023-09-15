namespace Zaabee.RabbitMQ;

public partial class ZaabeeRabbitMqClient
{
    /// <inheritdoc />
    public void Receive<T>(
        Func<Action<T?>> resolve,
        bool persistence,
        ushort prefetchCount = Consts.DefaultPrefetchCount,
        int consumeRetry = Consts.DefaultConsumeRetry) =>
        Receive(GetTypeName(typeof(T)),
            resolve,
            persistence,
            prefetchCount,
            consumeRetry);

    /// <inheritdoc />
    public void Receive<T>(
        Func<Func<T?, Task>> resolve,
        bool persistence,
        ushort prefetchCount = Consts.DefaultPrefetchCount,
        int consumeRetry = Consts.DefaultConsumeRetry) =>
        Receive(GetTypeName(typeof(T)),
            resolve,
            persistence,
            prefetchCount,
            consumeRetry);

    /// <inheritdoc />
    public void Receive<T>(
        string topic,
        Func<Action<T?>> resolve,
        bool persistence,
        ushort prefetchCount = Consts.DefaultPrefetchCount,
        int consumeRetry = Consts.DefaultConsumeRetry)
    {
        var normalExchangeParam = GetExchangeParam(topic, persistence);
        var normalQueueParam = GetQueueParam(topic, persistence);
        Consume(
            normalExchangeParam,
            normalQueueParam,
            null,
            null,
            resolve,
            prefetchCount,
            consumeRetry);
    }

    /// <inheritdoc />
    public void Receive<T>(
        string topic,
        Func<Func<T?, Task>> resolve,
        bool persistence,
        ushort prefetchCount = Consts.DefaultPrefetchCount,
        int consumeRetry = Consts.DefaultConsumeRetry)
    {
        var normalExchangeParam = GetExchangeParam(topic, persistence);
        var normalQueueParam = GetQueueParam(topic, persistence);
        Consume(
            normalExchangeParam,
            normalQueueParam,
            null,
            null,
            resolve,
            prefetchCount,
            consumeRetry);
    }

    /// <inheritdoc />
    public void Receive(
        string topic,
        Func<Action<byte[]>> resolve,
        bool persistence,
        ushort prefetchCount = Consts.DefaultPrefetchCount,
        int consumeRetry = Consts.DefaultConsumeRetry)
    {
        var normalExchangeParam = GetExchangeParam(topic, persistence);
        var normalQueueParam = GetQueueParam(topic, persistence);
        Consume(
            normalExchangeParam,
            normalQueueParam,
            null,
            null,
            resolve,
            prefetchCount,
            consumeRetry);
    }

    /// <inheritdoc />
    public void Receive(string topic,
        Func<Func<byte[], Task>> resolve,
        bool persistence,
        ushort prefetchCount = 10,
        int consumeRetry = Consts.DefaultConsumeRetry)
    {
        var normalExchangeParam = GetExchangeParam(topic, persistence);
        var normalQueueParam = GetQueueParam(topic, persistence);
        Consume(
            normalExchangeParam,
            normalQueueParam,
            null,
            null,
            resolve,
            prefetchCount,
            consumeRetry);
    }
}