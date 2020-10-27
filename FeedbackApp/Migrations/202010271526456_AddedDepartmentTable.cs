namespace FeedbackApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDepartmentTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t=>t.DepartmentName, unique: true);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Departments");
        }
    }
}
