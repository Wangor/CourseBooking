namespace CourseBooking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Registrations", "CourseType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Registrations", "CourseType");
        }
    }
}
