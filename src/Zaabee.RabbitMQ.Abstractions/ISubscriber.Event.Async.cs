namespace Zaabee.RabbitMQ.Abstractions;

public partial interface ISubscriber
{
    /// <summary>
    /// The subscriber cluster will receive the Event by the default queue.
    /// </summary>
    /// <param name="resolve"></param>
    /// <param name="prefetchCount"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    Task ReceiveEventAsync<T>(Func<Action<T?>> resolve, ushort prefetchCount = 10);

    /// <summary>
    /// The subscriber cluster will receive the Event by the default queue.
    /// </summary>
    /// <param name="resolve"></param>
    /// <param name="prefetchCount"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    Task ReceiveEventAsync<T>(Func<Func<T?, Task>> resolve, ushort prefetchCount = 10);

    /// <summary>
    /// The subscriber cluster will receive the Event by its own queue.
    /// </summary>
    /// <param name="resolve"></param>
    /// <param name="prefetchCount"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    Task SubscribeEventAsync<T>(Func<Action<T?>> resolve, ushort prefetchCount = 10);

    /// <summary>
    /// The subscriber cluster will receive the Event by its own queue.
    /// </summary>
    /// <param name="resolve"></param>
    /// <param name="prefetchCount"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    Task SubscribeEventAsync<T>(Func<Func<T?, Task>> resolve, ushort prefetchCount = 10);

    /// <summary>
    /// The subscriber cluster will receive the Event by the specified exchange.
    /// </summary>
    /// <param name="exchange"></param>
    /// <param name="resolve"></param>
    /// <param name="prefetchCount"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    Task SubscribeEventAsync<T>(string exchange, Func<Action<T?>> resolve, ushort prefetchCount = 10);

    /// <summary>
    /// The subscriber cluster will receive the Event by the specified exchange.
    /// </summary>
    /// <param name="exchange"></param>
    /// <param name="resolve"></param>
    /// <param name="prefetchCount"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    Task SubscribeEventAsync<T>(string exchange, Func<Func<T?, Task>> resolve, ushort prefetchCount = 10);

    /// <summary>
    /// The subscriber cluster will receive the Event by the specified exchange and queue.
    /// </summary>
    /// <param name="exchange"></param>
    /// <param name="queue"></param>
    /// <param name="resolve"></param>
    /// <param name="prefetchCount"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    Task SubscribeEventAsync<T>(string exchange, string queue, Func<Action<T?>> resolve, ushort prefetchCount = 10);

    /// <summary>
    /// The subscriber cluster will receive the Event by the specified exchange and queue.
    /// </summary>
    /// <param name="exchange"></param>
    /// <param name="queue"></param>
    /// <param name="resolve"></param>
    /// <param name="prefetchCount"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    Task SubscribeEventAsync<T>(string exchange, string queue, Func<Func<T?, Task>> resolve,
        ushort prefetchCount = 10);
}