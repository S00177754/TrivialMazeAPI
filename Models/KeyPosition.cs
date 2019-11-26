using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrivialMazeAPI.Models
{
    public class KeyPosition
    {
        [Key]
        public int ID { get; set; }
        public double XPosition { get; set; }
        public double YPosition { get; set; }
        public double ZPosition { get; set; }
        public string HexValue { get; set; }

    }
}