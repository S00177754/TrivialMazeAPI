namespace APITrivialMaze.Migrations
{
    using APITrivialMaze.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<APITrivialMaze.Data.APITrivialMazeContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "APITrivialMaze.Data.APITrivialMazeContext";
        }

        protected override void Seed(APITrivialMaze.Data.APITrivialMazeContext context)
        {
            List<TriviaQuestion> Questions = new List<TriviaQuestion>()
           {
               new TriviaQuestion()
               {
                   Question="What date is never a good day for Lara Croft?",
                   Answer="May 15th",
                   FakeAnswerOne = "June 10th",
                   FakeAnswerTwo = "December 29th",
                   FakeAnswerThree = "July 4th"
               },
               new TriviaQuestion()
               {
                   Question="Which state is known as the Empire State?",
                   Answer="New York",
                   FakeAnswerOne = "Texas",
                   FakeAnswerTwo = "California",
                   FakeAnswerThree = "New Jersey"
               },
               new TriviaQuestion()
               {
                   Question="Who is the patron saint of Ireland?",
                   Answer="Saint Patrick",
                   FakeAnswerOne = "Saint Brigid",
                   FakeAnswerTwo = "Bono",
                   FakeAnswerThree = "Fionn Mac Cumhaill"
               },
               new TriviaQuestion()
               {
                   Question="Who discovered the Cell?",
                   Answer="Robert Hooke",
                   FakeAnswerOne = "Thomas Jefferson",
                   FakeAnswerTwo = "Leonardo da Vinci",
                   FakeAnswerThree = "Robert Boyle"
               },
               new TriviaQuestion()
               {
                   Question="Who owns Facebook?",
                   Answer="Mark Zuckerburg",
                   FakeAnswerOne = "Phil Swift",
                   FakeAnswerTwo = "Steve Jobs",
                   FakeAnswerThree = "Bill Gates"
               },
               new TriviaQuestion()
               {
                   Question="What artist(s) released the song 'Pac-Man Fever'?",
                   Answer="Buckner & Garcia",
                   FakeAnswerOne = "Ed Sheeran",
                   FakeAnswerTwo = "Tommy Wiseau",
                   FakeAnswerThree = "The Rolling Stones"
               },
           };
            foreach (var item in Questions)
            {
                context.TriviaQuestions.AddOrUpdate(x => x.Question, item);
            }

            List<TimeScore> Times = new List<TimeScore>()
            {
                new TimeScore()
                {
                    Username = "Cl0UD_St1f3",
                    Time = 100
                },
                new TimeScore()
                {
                    Username = "NanoPulse",
                    Time = 300
                },
                new TimeScore()
                {
                    Username = "SamCroft",
                    Time = 200
                },
            };
            foreach (var item in Times)
            {
                context.TimeScores.AddOrUpdate(item);
            }


            context.SaveChanges();
        }
    }
}
