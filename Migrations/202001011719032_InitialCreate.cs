namespace APITrivialMaze.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.KeyPositions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        XPosition = c.Double(nullable: false),
                        YPosition = c.Double(nullable: false),
                        ZPosition = c.Double(nullable: false),
                        HexValue = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TimeScores",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Time = c.Double(nullable: false),
                        Username = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TriviaQuestions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Question = c.String(),
                        Answer = c.String(),
                        FakeAnswerOne = c.String(),
                        FakeAnswerTwo = c.String(),
                        FakeAnswerThree = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TriviaQuestions");
            DropTable("dbo.TimeScores");
            DropTable("dbo.KeyPositions");
        }
    }
}
