using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APITrivialMaze.Classes
{
    public class TimeScoreResponse
    {
        public int ID { get; set; }
        public double Time { get; set; }
        public string PlayerUsername { get; set; }
    }
}