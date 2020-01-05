using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APITrivialMaze.Models
{
    public class Player
    {
        [Key]
        public Guid PlayerID { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public virtual ICollection<TimeScore> TimeScores { get; set; }
    }
}