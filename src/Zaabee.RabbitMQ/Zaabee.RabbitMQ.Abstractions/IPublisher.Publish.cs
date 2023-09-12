namespace Zaabee.RabbitMQ.Abstractions;

public partial interface IPublisher
{
    /// <summary>
    /// Publish the message to the default topic.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="persistence"></param>
    /// <param name="publishRetry"></param>
    /// <typeparam name="T"></typeparam>
    void Publish<T>(
        T message,
        bool persistence,
        int publishRetry = Consts.DefaultPublishRetry);

    /// <summary>
    /// Publish the message to the specified topic.
    /// </summary>
    /// <param name="topic"></param>
    /// <param name="message"></param>
    /// <param name="persistence"></param>
    /// <param name="publishRetry"></param>
    /// <typeparam name="T"></typeparam>
    void Publish<T>(
        string topic,
        T message,
        bool persistence,
        int publishRetry = Consts.DefaultPublishRetry);

    /// <summary>
    /// Publish the message to the specified topic.
    /// </summary>
    /// <param name="topic"></param>
    /// <param name="body"></param>
    /// <param name="persistence"></param>
    /// <param name="publishRetry"></param>
    void Publish(
        string topic,
        byte[] body,
        bool persistence,
        int publishRetry = Consts.DefaultPublishRetry);
}