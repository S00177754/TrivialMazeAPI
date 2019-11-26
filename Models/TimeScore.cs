using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrivialMazeAPI.Models
{
    public class TimeScore
    {
        [Key]
        public int ID { get; set; }
        public double Time { get; set; }
        public string Username { get; set; }
    }
}