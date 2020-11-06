namespace FeedbackApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSubjectIdAndPostedOnToFeedbackTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Feedbacks", "SubjectId", c => c.Int(nullable: false));
            AddColumn("dbo.Feedbacks", "PostedOn", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Feedbacks", "PostedOn");
            DropColumn("dbo.Feedbacks", "SubjectId");
        }
    }
}
