﻿namespace SuperCharacters.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class SuperPower
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string SuperPowerName { get; set; }

        public string Type { get; set; }
        public double Value { get; set; }
        public virtual Character Character { get; set; }
    }
}
