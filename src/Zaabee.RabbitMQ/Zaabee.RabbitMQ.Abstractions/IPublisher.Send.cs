namespace Zaabee.RabbitMQ.Abstractions;

public partial interface IPublisher
{
    /// <summary>
    /// Send the message to the default topic.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="persistence"></param>
    /// <param name="publishRetry"></param>
    /// <param name="consumeRetry"></param>
    /// <param name="dlx"></param>
    /// <typeparam name="T"></typeparam>
    void Send<T>(
        T message,
        bool persistence,
        int publishRetry = Consts.DefaultPublishRetry,
        int consumeRetry = Consts.DefaultConsumeRetry,
        bool dlx = true);

    /// <summary>
    /// Send the message to the specified topic.
    /// </summary>
    /// <param name="topic"></param>
    /// <param name="message"></param>
    /// <param name="persistence"></param>
    /// <param name="publishRetry"></param>
    /// <param name="consumeRetry"></param>
    /// <param name="dlx"></param>
    /// <typeparam name="T"></typeparam>
    void Send<T>(
        string topic,
        T message,
        bool persistence,
        int publishRetry = Consts.DefaultPublishRetry,
        int consumeRetry = Consts.DefaultConsumeRetry,
        bool dlx = true);

    /// <summary>
    /// Send the message to the specified topic.
    /// </summary>
    /// <param name="topic"></param>
    /// <param name="body"></param>
    /// <param name="persistence"></param>
    /// <param name="publishRetry"></param>
    /// <param name="consumeRetry"></param>
    /// <param name="dlx"></param>
    void Send(
        string topic,
        byte[] body,
        bool persistence,
        int publishRetry = Consts.DefaultPublishRetry,
        int consumeRetry = Consts.DefaultConsumeRetry,
        bool dlx = true);
}