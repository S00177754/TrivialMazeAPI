using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APITrivialMaze.Models
{
    public class TriviaQuestion
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Question { get; set; }

        [Required]
        public string Answer { get; set; }

        public string FakeAnswerOne { get; set; }
        public string FakeAnswerTwo { get; set; }
        public string FakeAnswerThree { get; set; }
    }
}