using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_basics.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Image { get; set; }
        public string Description { get; set; } = null!;
        public int Price { get; set; }
        public bool IsActive { get; set; }
        public bool IsHome { get; set; }
    }
}