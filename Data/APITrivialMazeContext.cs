using APITrivialMaze.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace APITrivialMaze.Data
{
    public class APITrivialMazeContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public APITrivialMazeContext() : base("name=APITrivialMazeContext")
        {
        }

        public DbSet<KeyPosition> KeyPositions { get; set; }

        public DbSet<TimeScore> TimeScores { get; set; }

        public DbSet<TriviaQuestion> TriviaQuestions { get; set; }

        public DbSet<Player> Players { get; set; }

        public DbSet<Message> Messages { get; set; }
    }
}
