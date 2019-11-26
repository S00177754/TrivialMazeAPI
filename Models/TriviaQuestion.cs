using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrivialMazeAPI.Models
{
    public class TriviaQuestion
    {
        [Key]
        public int ID { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public string FakeAnswerOne { get; set; }
        public string FakeAnswerTwo { get; set; }
        public string FakeAnswerThree { get; set; }
    }
}