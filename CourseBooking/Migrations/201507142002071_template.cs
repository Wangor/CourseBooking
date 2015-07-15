namespace CourseBooking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class template : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CourseSetEntry", "CourseTemplate_Id", c => c.Int());
            CreateIndex("dbo.CourseSetEntry", "CourseTemplate_Id");
            AddForeignKey("dbo.CourseSetEntry", "CourseTemplate_Id", "dbo.CourseTemplate", "Id");
            DropColumn("dbo.CourseSetEntry", "CourseTemplateId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CourseSetEntry", "CourseTemplateId", c => c.Int(nullable: false));
            DropForeignKey("dbo.CourseSetEntry", "CourseTemplate_Id", "dbo.CourseTemplate");
            DropIndex("dbo.CourseSetEntry", new[] { "CourseTemplate_Id" });
            DropColumn("dbo.CourseSetEntry", "CourseTemplate_Id");
        }
    }
}
