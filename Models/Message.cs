using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace APITrivialMaze.Models
{
    public class Message
    {
        [Key]
        public int ID { get; set; }

        public string PlayerUsername { get; set; }

        [Required]
        public string MessageText { get; set; }

        [Required]
        public DateTime DateSent { get; set; }

        //Navigation Properties
        [JsonIgnore]
        [ForeignKey("PlayerUsername")]
        public virtual Player Player { get; set; }
    }
}