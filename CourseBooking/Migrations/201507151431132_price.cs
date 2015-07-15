namespace CourseBooking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class price : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Course", "Price", c => c.String());
            AddColumn("dbo.CourseTemplate", "Price", c => c.String());
            DropColumn("dbo.Course", "EndDateTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Course", "EndDateTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.CourseTemplate", "Price");
            DropColumn("dbo.Course", "Price");
        }
    }
}
