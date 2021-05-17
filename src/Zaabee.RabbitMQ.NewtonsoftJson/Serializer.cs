﻿using System;
using System.Text;
using Newtonsoft.Json;
using Zaabee.NewtonsoftJson;
using Zaabee.RabbitMQ.Serializer.Abstraction;

namespace Zaabee.RabbitMQ.NewtonsoftJson
{
    public class Serializer : ISerializer
    {
        private static Encoding _encoding;
        private static JsonSerializerSettings _settings;

        public Serializer(Encoding encoding = null, JsonSerializerSettings settings = null)
        {
            _encoding = encoding ?? Encoding.UTF8;
            _settings = settings;
        }

        public ReadOnlyMemory<byte> Serialize<T>(T t) => t.ToBytes(_settings, _encoding);

        public T Deserialize<T>(ReadOnlyMemory<byte> bytes) => bytes.ToArray().FromBytes<T>(_settings, _encoding);

        public string BytesToText(ReadOnlyMemory<byte> bytes) => _encoding.GetString(bytes.ToArray());

        public T FromText<T>(string text) => text.FromJson<T>(_settings);
    }
}