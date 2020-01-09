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
        }
    }
}
