namespace CourseBooking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "City", c => c.String());
            AddColumn("dbo.Customers", "Birtdate", c => c.DateTime());
            AddColumn("dbo.Customers", "Zip", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "Zip");
            DropColumn("dbo.Customers", "Birtdate");
            DropColumn("dbo.Customers", "City");
        }
    }
}
