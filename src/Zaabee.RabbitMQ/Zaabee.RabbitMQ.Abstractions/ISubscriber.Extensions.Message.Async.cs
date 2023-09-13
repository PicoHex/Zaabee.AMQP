﻿namespace Zaabee.RabbitMQ.Abstractions;

public static partial class SubscriberExtension
{
    /// <summary>
    /// The subscriber cluster will get the message from its own queue which bind the default topic.
    /// </summary>
    /// <param name="subscriber"></param>
    /// <param name="resolve"></param>
    /// <param name="prefetchCount"></param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static ValueTask SubscribeMessageAsync<T>(
        this ISubscriber subscriber,
        Func<Action<T?>> resolve,
        ushort prefetchCount = Consts.DefaultPrefetchCount,
        CancellationToken cancellationToken = default) =>
        subscriber.SubscribeAsync(resolve, true, prefetchCount, 0, false, true, cancellationToken);

    /// <summary>
    /// The subscriber cluster will get the message from its own queue which bind the default topic.
    /// </summary>
    /// <param name="subscriber"></param>
    /// <param name="resolve"></param>
    /// <param name="prefetchCount"></param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static ValueTask SubscribeMessageAsync<T>(
        this ISubscriber subscriber,
        Func<Func<T?, Task>> resolve,
        ushort prefetchCount = Consts.DefaultPrefetchCount,
        CancellationToken cancellationToken = default) =>
        subscriber.SubscribeAsync(resolve, true, prefetchCount, 0, false, true, cancellationToken);

    /// <summary>
    /// The subscriber cluster will get the message from its own queue which bind the specified topic.
    /// </summary>
    /// <param name="subscriber"></param>
    /// <param name="topic"></param>
    /// <param name="resolve"></param>
    /// <param name="prefetchCount"></param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static ValueTask SubscribeMessageAsync<T>(
        this ISubscriber subscriber,
        string topic,
        Func<Action<T?>> resolve,
        ushort prefetchCount = Consts.DefaultPrefetchCount,
        CancellationToken cancellationToken = default) =>
        subscriber.SubscribeAsync(topic, resolve, true, prefetchCount, 0, false, true, cancellationToken);

    /// <summary>
    /// The subscriber cluster will get the message from its own queue which bind the specified topic.
    /// </summary>
    /// <param name="subscriber"></param>
    /// <param name="topic"></param>
    /// <param name="resolve"></param>
    /// <param name="prefetchCount"></param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static ValueTask SubscribeMessageAsync<T>(
        this ISubscriber subscriber,
        string topic,
        Func<Func<T?, Task>> resolve,
        ushort prefetchCount = Consts.DefaultPrefetchCount,
        CancellationToken cancellationToken = default) =>
        subscriber.SubscribeAsync(topic, resolve, true, prefetchCount, 0, false, true, cancellationToken);

    /// <summary>
    /// The subscriber cluster will get the message from its own queue which bind the specified topic.
    /// </summary>
    /// <param name="subscriber"></param>
    /// <param name="topic"></param>
    /// <param name="resolve"></param>
    /// <param name="prefetchCount"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static ValueTask SubscribeMessageAsync(
        this ISubscriber subscriber,
        string topic,
        Func<Action<byte[]>> resolve,
        ushort prefetchCount = Consts.DefaultPrefetchCount,
        CancellationToken cancellationToken = default) =>
        subscriber.SubscribeAsync(topic, resolve, true, prefetchCount, 0, false, true, cancellationToken);

    /// <summary>
    /// The subscriber cluster will get the message from its own queue which bind the specified topic.
    /// </summary>
    /// <param name="subscriber"></param>
    /// <param name="topic"></param>
    /// <param name="resolve"></param>
    /// <param name="prefetchCount"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static ValueTask SubscribeMessageAsync(
        this ISubscriber subscriber,
        string topic,
        Func<Func<byte[], Task>> resolve,
        ushort prefetchCount = Consts.DefaultPrefetchCount,
        CancellationToken cancellationToken = default) =>
        subscriber.SubscribeAsync(topic, resolve, true, prefetchCount, 0, false, true, cancellationToken);
}