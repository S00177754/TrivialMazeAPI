using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APITrivialMaze.Models
{
    [Serializable]
    public class Player
    {
        [Key]
        [Required]
        [MaxLength(25),MinLength(2)]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [JsonIgnore]
        public virtual ICollection<Message> SentMessages { get; set; }
        [JsonIgnore]
        public virtual ICollection<TimeScore> TimeScores { get; set; }
    }
}