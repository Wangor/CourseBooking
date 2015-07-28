namespace CourseBooking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Registrations", "Birthdate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Registrations", "LfaEndDateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Registrations", "RegRefNr", c => c.String(nullable: false));
            AddColumn("dbo.Registrations", "Remark", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Registrations", "Remark");
            DropColumn("dbo.Registrations", "RegRefNr");
            DropColumn("dbo.Registrations", "LfaEndDateTime");
            DropColumn("dbo.Registrations", "Birthdate");
        }
    }
}
