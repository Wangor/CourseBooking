namespace CourseBooking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Registrations", "LfaEndDateTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Registrations", "LfaEndDateTime", c => c.DateTime(nullable: false));
        }
    }
}
