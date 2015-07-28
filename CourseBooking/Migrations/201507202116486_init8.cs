namespace CourseBooking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init8 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Registrations", "RegRefNr", c => c.String());
            AlterColumn("dbo.Registrations", "Remark", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Registrations", "Remark", c => c.String(nullable: false));
            AlterColumn("dbo.Registrations", "RegRefNr", c => c.String(nullable: false));
        }
    }
}
