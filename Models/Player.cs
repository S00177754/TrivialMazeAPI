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

        [Required]
        [MaxLength(25),MinLength(2)]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public virtual ICollection<Message> SentMessages { get; set; }
        public virtual ICollection<TimeScore> TimeScores { get; set; }
    }
}