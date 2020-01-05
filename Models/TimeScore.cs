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
        public Guid PlayerID { get; set; }

        [ForeignKey("PlayerID")]
        public virtual Player Player { get; set; }
    }
}