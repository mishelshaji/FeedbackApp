namespace FeedbackApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSubjectTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubjectName = c.String(),
                        Semester = c.Int(nullable: false),
                        TeacherId = c.String(),
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .Index(t => t.DepartmentId);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Subjects", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Subjects", new[] { "DepartmentId" });
            DropTable("dbo.Subjects");
        }
    }
}
