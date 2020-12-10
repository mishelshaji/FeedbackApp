namespace FeedbackApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBatchToIdentityModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Batch", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Batch");
        }
    }
}
