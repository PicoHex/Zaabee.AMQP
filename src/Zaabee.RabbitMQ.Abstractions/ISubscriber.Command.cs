namespace Zaabee.RabbitMQ.Abstractions;

public partial interface ISubscriber
{
    /// <summary>
    /// The subscriber cluster will get the command from the queue which bind the default topic.
    /// </summary>
    /// <param name="resolve"></param>
    /// <param name="prefetchCount"></param>
    /// <typeparam name="T"></typeparam>
    void ReceiveEvent<T>(Func<Action<T?>> resolve, ushort prefetchCount = 10);

    /// <summary>
    /// The subscriber cluster will get the command from the queue which bind the default topic.
    /// </summary>
    /// <param name="resolve"></param>
    /// <param name="prefetchCount"></param>
    /// <typeparam name="T"></typeparam>
    void ReceiveEvent<T>(Func<Func<T?, Task>> resolve, ushort prefetchCount = 10);

    /// <summary>
    /// The subscriber cluster will get the command from the queue which bind the specified topic.
    /// </summary>
    /// <param name="topic"></param>
    /// <param name="resolve"></param>
    /// <param name="prefetchCount"></param>
    /// <typeparam name="T"></typeparam>
    void ReceiveEvent<T>(string topic, Func<Action<T?>> resolve, ushort prefetchCount = 10);

    /// <summary>t
    /// The subscriber cluster will get the command from the queue which bind the specified topic.
    /// </summary>
    /// <param name="topic"></param>
    /// <param name="resolve"></param>
    /// <param name="prefetchCount"></param>
    /// <typeparam name="T"></typeparam>
    void ReceiveEvent<T>(string topic, Func<Func<T?, Task>> resolve, ushort prefetchCount = 10);

    /// <summary>
    /// The subscriber cluster will get the command from the queue which bind the specified topic.
    /// </summary>
    /// <param name="topic"></param>
    /// <param name="resolve"></param>
    /// <param name="prefetchCount"></param>
    /// <typeparam name="T"></typeparam>
    void ReceiveEvent<T>(string topic, Func<Action<byte[]>> resolve, ushort prefetchCount = 10);

    /// <summary>
    /// The subscriber cluster will get the command from the queue which bind the specified topic.
    /// </summary>
    /// <param name="topic"></param>
    /// <param name="resolve"></param>
    /// <param name="prefetchCount"></param>
    /// <typeparam name="T"></typeparam>
    void ReceiveEvent<T>(string topic, Func<Func<byte[], Task>> resolve, ushort prefetchCount = 10);
}