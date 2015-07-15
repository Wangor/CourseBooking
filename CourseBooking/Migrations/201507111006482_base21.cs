namespace CourseBooking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class base21 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CourseSetEntry", "CourseTemplate_Id", "dbo.CourseTemplate");
            DropIndex("dbo.CourseSetEntry", new[] { "CourseTemplate_Id" });
            AddColumn("dbo.CourseSet", "Price", c => c.String());
            AddColumn("dbo.CourseSetEntry", "CourseTemplateId", c => c.Int(nullable: false));
            DropColumn("dbo.CourseSetEntry", "CourseTemplate_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CourseSetEntry", "CourseTemplate_Id", c => c.Int());
            DropColumn("dbo.CourseSetEntry", "CourseTemplateId");
            DropColumn("dbo.CourseSet", "Price");
            CreateIndex("dbo.CourseSetEntry", "CourseTemplate_Id");
            AddForeignKey("dbo.CourseSetEntry", "CourseTemplate_Id", "dbo.CourseTemplate", "Id");
        }
    }
}
