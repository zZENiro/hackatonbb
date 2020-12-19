using System;
using System.Collections.Generic;

#nullable disable

namespace hackatonbb.Models
{
    public partial class Main
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Vuz { get; set; }
        public string StudentId { get; set; }
        public int? Step { get; set; }
        public int? CountQuest { get; set; }
        public int? CurrentQuest { get; set; }
        public double? Rating { get; set; }
    }
}
