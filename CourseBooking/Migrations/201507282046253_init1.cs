namespace CourseBooking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Registrations", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Registrations", new[] { "CustomerId" });
            AlterColumn("dbo.Registrations", "CustomerId", c => c.Int());
            CreateIndex("dbo.Registrations", "CustomerId");
            AddForeignKey("dbo.Registrations", "CustomerId", "dbo.Customers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Registrations", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Registrations", new[] { "CustomerId" });
            AlterColumn("dbo.Registrations", "CustomerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Registrations", "CustomerId");
            AddForeignKey("dbo.Registrations", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
        }
    }
}
