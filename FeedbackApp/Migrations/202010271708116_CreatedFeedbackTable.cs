namespace FeedbackApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedFeedbackTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Feedbacks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentId = c.String(),
                        TeacherId = c.String(),
                        Option1 = c.Int(nullable: false),
                        Option2 = c.Int(nullable: false),
                        Option3 = c.Int(nullable: false),
                        Option4 = c.Int(nullable: false),
                        Option5 = c.Int(nullable: false),
                        Option6 = c.Int(nullable: false),
                        Option7 = c.Int(nullable: false),
                        Option8 = c.Int(nullable: false),
                        Option9 = c.Int(nullable: false),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Feedbacks");
        }
    }
}
