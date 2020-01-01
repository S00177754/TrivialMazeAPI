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

        public System.Data.Entity.DbSet<APITrivialMaze.Models.KeyPosition> KeyPositions { get; set; }

        public System.Data.Entity.DbSet<APITrivialMaze.Models.TimeScore> TimeScores { get; set; }

        public System.Data.Entity.DbSet<APITrivialMaze.Models.TriviaQuestion> TriviaQuestions { get; set; }
    }
}
