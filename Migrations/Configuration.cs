namespace APITrivialMaze.Migrations
{
    using APITrivialMaze.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<APITrivialMaze.Data.APITrivialMazeContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(APITrivialMaze.Data.APITrivialMazeContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Players.AddOrUpdate(new Player() { Username = "Nanopulse_", Password = "Nano2020!" });
            context.SaveChanges();

            context.TriviaQuestions.AddOrUpdate(
                new TriviaQuestion
                {
                    Question = "What year was the first Tomb Riader game released?",
                    Answer = "1996",
                    FakeAnswerOne = "1995",
                    FakeAnswerTwo = "1997",
                    FakeAnswerThree = "2000"
                },
                new TriviaQuestion
                {
                    Question = "Test Question",
                    Answer = "Correct answer",
                    FakeAnswerOne = "Fake 1",
                    FakeAnswerTwo = "Fake 2",
                    FakeAnswerThree = "Fake 3"
                },
                new TriviaQuestion
                {
                    Question = "What is Megaman called in Japan?",
                    Answer = "Rock Man",
                    FakeAnswerOne = "Rocketman",
                    FakeAnswerTwo = "Robot Man",
                    FakeAnswerThree = "Jeremy"
                },
                new TriviaQuestion
                {
                    Question = "Which PS1 Classic game featured in Uncharted 4?",
                    Answer = "Crach Bandicoot",
                    FakeAnswerOne = "Final Fantasy 7",
                    FakeAnswerTwo = "Tomb Raider",
                    FakeAnswerThree = "Metal Gear Solid"
                },
                new TriviaQuestion
                {
                    Question = "How many Power Stars can be collected in Super Mario 64?",
                    Answer = "120",
                    FakeAnswerOne = "100",
                    FakeAnswerTwo = "50",
                    FakeAnswerThree = "47"
                },
                new TriviaQuestion
                {
                    Question = "What is the name of the orange ghost in Pac Man?",
                    Answer = "Clyde",
                    FakeAnswerOne = "Inky",
                    FakeAnswerTwo = "Blinky",
                    FakeAnswerThree = "Pinky"
                });
        }
    }
}
