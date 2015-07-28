namespace CourseBooking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init7 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerRegistrations",
                c => new
                    {
                        CustomerId = c.Int(nullable: false),
                        RegistrationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CustomerId, t.RegistrationId })
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Registrations", t => t.RegistrationId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.RegistrationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerRegistrations", "RegistrationId", "dbo.Registrations");
            DropForeignKey("dbo.CustomerRegistrations", "CustomerId", "dbo.Customers");
            DropIndex("dbo.CustomerRegistrations", new[] { "RegistrationId" });
            DropIndex("dbo.CustomerRegistrations", new[] { "CustomerId" });
            DropTable("dbo.CustomerRegistrations");
        }
    }
}
