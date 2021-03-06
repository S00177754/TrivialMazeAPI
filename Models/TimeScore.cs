﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace APITrivialMaze.Models
{
    public class TimeScore
    {
        [Key]
        public int ID { get; set; }
        public double Time { get; set; }
        public string PlayerUsername { get; set; }

        [JsonIgnore]
        [ForeignKey("PlayerUsername")]
        public virtual Player Player { get; set; }
    }
}