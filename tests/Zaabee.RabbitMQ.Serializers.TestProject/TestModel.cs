﻿using System;

namespace Zaabee.RabbitMQ.Serializers.TestProject
{
    public class TestModel
    {
        public Guid Id { get; set; }
        public int Age { get; set; }
        public string? Name { get; set; }
        public DateTime CreateTime { get; set; }
        public Gender Gender { get; set; }
    }
}