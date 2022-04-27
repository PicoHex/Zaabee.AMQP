namespace Zaabee.RabbitMQ.Abstractions;

public partial interface ISubscriber
{
    /// <summary>
    /// The subscriber cluster will receive the Event by the default queue.
    /// </summary>
    /// <param name="resolve"></param>
    /// <param name="prefetchCount"></param>
    /// <typeparam name="T"></typeparam>
    void ReceiveEvent<T>(Func<Action<T?>> resolve, ushort prefetchCount = 10);

    /// <summary>
    /// The subscriber cluster will receive the Event by the default queue.
    /// </summary>
    /// <param name="resolve"></param>
    /// <param name="prefetchCount"></param>
    /// <typeparam name="T"></typeparam>
    void ReceiveEvent<T>(Func<Func<T?, Task>> resolve, ushort prefetchCount = 10);

    /// <summary>
    /// The subscriber cluster will receive the Event by its own queue.
    /// </summary>
    /// <param name="resolve"></param>
    /// <param name="prefetchCount"></param>
    /// <typeparam name="T"></typeparam>
    void SubscribeEvent<T>(Func<Action<T?>> resolve, ushort prefetchCount = 10);

    /// <summary>
    /// The subscriber cluster will receive the Event by its own queue.
    /// </summary>
    /// <param name="resolve"></param>
    /// <param name="prefetchCount"></param>
    /// <typeparam name="T"></typeparam>
    void SubscribeEvent<T>(Func<Func<T?, Task>> resolve, ushort prefetchCount = 10);

    /// <summary>
    /// The subscriber cluster will receive the Event by the specified topic.
    /// </summary>
    /// <param name="topic"></param>
    /// <param name="resolve"></param>
    /// <param name="prefetchCount"></param>
    /// <typeparam name="T"></typeparam>
    void SubscribeEvent<T>(string topic, Func<Action<T?>> resolve, ushort prefetchCount = 10);

    /// <summary>
    /// The subscriber cluster will receive the Event by the specified topic.
    /// </summary>
    /// <param name="topic"></param>
    /// <param name="resolve"></param>
    /// <param name="prefetchCount"></param>
    /// <typeparam name="T"></typeparam>
    void SubscribeEvent<T>(string topic, Func<Func<T?, Task>> resolve, ushort prefetchCount = 10);
}