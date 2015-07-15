namespace CourseBooking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class base2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CourseTemplate", "Location_Id", "dbo.Location");
            DropIndex("dbo.CourseTemplate", new[] { "Location_Id" });
            AddColumn("dbo.CourseTemplate", "LocationId", c => c.Int(nullable: false));
            DropColumn("dbo.CourseTemplate", "Location_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CourseTemplate", "Location_Id", c => c.Int());
            DropColumn("dbo.CourseTemplate", "LocationId");
            CreateIndex("dbo.CourseTemplate", "Location_Id");
            AddForeignKey("dbo.CourseTemplate", "Location_Id", "dbo.Location", "Id");
        }
    }
}
