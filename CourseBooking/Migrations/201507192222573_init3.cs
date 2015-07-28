namespace CourseBooking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Registrations", "Zip", c => c.String(nullable: false));
            AddColumn("dbo.Registrations", "City", c => c.String(nullable: false));
            AlterColumn("dbo.Registrations", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Registrations", "PreName", c => c.String(nullable: false));
            AlterColumn("dbo.Registrations", "AddressLine", c => c.String(nullable: false));
            AlterColumn("dbo.Registrations", "Phone", c => c.String(nullable: false));
            AlterColumn("dbo.Registrations", "EMail", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Registrations", "EMail", c => c.String());
            AlterColumn("dbo.Registrations", "Phone", c => c.String());
            AlterColumn("dbo.Registrations", "AddressLine", c => c.String());
            AlterColumn("dbo.Registrations", "PreName", c => c.String());
            AlterColumn("dbo.Registrations", "Name", c => c.String());
            DropColumn("dbo.Registrations", "City");
            DropColumn("dbo.Registrations", "Zip");
        }
    }
}
