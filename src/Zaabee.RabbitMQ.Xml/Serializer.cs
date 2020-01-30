﻿using System.IO;
using System.Text;
using System.Xml.Serialization;
using Zaabee.RabbitMQ.ISerialize;

namespace Zaabee.RabbitMQ.Xml
{
    public class Serializer : ISerializer
    {
        private static Encoding _encoding = Encoding.UTF8;

        public static Encoding DefaultEncoding
        {
            get => _encoding;
            set => _encoding = value ?? _encoding;
        }

        public Serializer(Encoding defaultEncoding = null)
        {
            DefaultEncoding = defaultEncoding;
        }

        public byte[] Serialize<T>(T t)
        {
            if (t is null) return new byte[0];
            var serializer = new XmlSerializer(typeof(T));
            using var stream = new MemoryStream();
            serializer.Serialize(stream, t);
            var bytes = new byte[stream.Length];
            stream.Seek(0, SeekOrigin.Begin);
            stream.Read(bytes, 0, bytes.Length);
            return bytes;
        }

        public T Deserialize<T>(byte[] bytes)
        {
            if (bytes is null || bytes.Length == 0) return default;
            var xmlSerializer = new XmlSerializer(typeof(T));
            using var ms = new MemoryStream(bytes);
            return (T) xmlSerializer.Deserialize(ms);
        }

        public string BytesToText(byte[] bytes) =>
            bytes is null ? null : DefaultEncoding.GetString(bytes);

        public T FromText<T>(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return default;
            var xmlSerializer = new XmlSerializer(typeof(T));
            using var ms = new MemoryStream(DefaultEncoding.GetBytes(text));
            return (T) xmlSerializer.Deserialize(ms);
        }
    }
}