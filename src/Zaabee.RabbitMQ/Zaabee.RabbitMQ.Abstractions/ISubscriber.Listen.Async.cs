namespace Zaabee.RabbitMQ.Abstractions;

public partial interface ISubscriber
{
    /// <summary>
    /// The subscriber node will get the message from its own queue, and the queue will bind with the default topic which can not be persisted.
    /// </summary>
    /// <param name="resolve"></param>
    /// <param name="prefetchCount"></param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    ValueTask ListenAsync<T>(
        Func<Action<T?>> resolve,
        ushort prefetchCount = Consts.DefaultPrefetchCount,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// The subscriber node will get the message from its own queue, and the queue will bind with the default topic which can not be persisted.
    /// </summary>
    /// <param name="resolve"></param>
    /// <param name="prefetchCount"></param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    ValueTask ListenAsync<T>(
        Func<Func<T?, Task>> resolve,
        ushort prefetchCount = Consts.DefaultPrefetchCount,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// The subscriber node will get the message from its own queue, and the queue will bind with the specified topic which can not be persisted.
    /// </summary>
    /// <param name="topic"></param>
    /// <param name="resolve"></param>
    /// <param name="prefetchCount"></param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    ValueTask ListenAsync<T>(
        string topic,
        Func<Action<T?>> resolve,
        ushort prefetchCount = Consts.DefaultPrefetchCount,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// The subscriber node will get the message from its own queue, and the queue will bind with the specified topic which can not be persisted.
    /// </summary>
    /// <param name="topic"></param>
    /// <param name="resolve"></param>
    /// <param name="prefetchCount"></param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    ValueTask ListenAsync<T>(
        string topic,
        Func<Func<T?, Task>> resolve,
        ushort prefetchCount = Consts.DefaultPrefetchCount,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// The subscriber node will get the message from its own queue, and the queue will bind with the specified topic which can not be persisted.
    /// </summary>
    /// <param name="topic"></param>
    /// <param name="resolve"></param>
    /// <param name="prefetchCount"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    ValueTask ListenAsync(
        string topic,
        Func<Action<byte[]>> resolve,
        ushort prefetchCount = Consts.DefaultPrefetchCount,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// The subscriber node will get the message from its own queue, and the queue will bind with the specified topic which can not be persisted.
    /// </summary>
    /// <param name="topic"></param>
    /// <param name="resolve"></param>
    /// <param name="prefetchCount"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    ValueTask ListenAsync(
        string topic,
        Func<Func<byte[], Task>> resolve,
        ushort prefetchCount = Consts.DefaultPrefetchCount,
        CancellationToken cancellationToken = default);
}