namespace CourseBooking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Remark = c.String(),
                        MessageField = c.Int(nullable: false),
                        StartDateTime = c.DateTime(nullable: false),
                        CourseTemplateId = c.Int(nullable: false),
                        LocationId = c.Int(nullable: false),
                        MaxParticipants = c.Int(nullable: false),
                        Price = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Registrations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AddressLine = c.String(nullable: false),
                        AddressLine2 = c.String(),
                        City = c.String(nullable: false),
                        Confirmed = c.Boolean(nullable: false),
                        CourseType = c.String(),
                        EMail = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        PreName = c.String(nullable: false),
                        Title = c.String(),
                        Zip = c.String(nullable: false),
                        Birthdate = c.DateTime(nullable: false),
                        LfaEndDateTime = c.DateTime(),
                        RegRefNr = c.String(),
                        Remark = c.String(),
                        AdditionalInfo = c.String(),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AddressLine = c.String(),
                        AddressLine2 = c.String(),
                        City = c.String(),
                        EMail = c.String(),
                        Name = c.String(),
                        Phone = c.String(),
                        PreName = c.String(),
                        Title = c.String(),
                        Birtdate = c.DateTime(),
                        Zip = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CourseSetEntry",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Sorting = c.Int(nullable: false),
                        CourseSetId = c.Int(nullable: false),
                        CourseTemplate_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CourseSet", t => t.CourseSetId, cascadeDelete: true)
                .ForeignKey("dbo.CourseTemplate", t => t.CourseTemplate_Id)
                .Index(t => t.CourseSetId)
                .Index(t => t.CourseTemplate_Id);
            
            CreateTable(
                "dbo.CourseSet",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Price = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CourseTemplate",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        NumberOfHours = c.Int(nullable: false),
                        LocationId = c.Int(nullable: false),
                        MaxParticipants = c.Int(nullable: false),
                        Price = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Location",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Street = c.String(),
                        Zip = c.String(),
                        City = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CourseRegistrations",
                c => new
                    {
                        RegistrationId = c.Int(nullable: false),
                        Course_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RegistrationId, t.Course_Id })
                .ForeignKey("dbo.Registrations", t => t.RegistrationId, cascadeDelete: true)
                .ForeignKey("dbo.Course", t => t.Course_Id, cascadeDelete: true)
                .Index(t => t.RegistrationId)
                .Index(t => t.Course_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseSetEntry", "CourseTemplate_Id", "dbo.CourseTemplate");
            DropForeignKey("dbo.CourseSetEntry", "CourseSetId", "dbo.CourseSet");
            DropForeignKey("dbo.Registrations", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.CourseRegistrations", "Course_Id", "dbo.Course");
            DropForeignKey("dbo.CourseRegistrations", "RegistrationId", "dbo.Registrations");
            DropIndex("dbo.CourseSetEntry", new[] { "CourseTemplate_Id" });
            DropIndex("dbo.CourseSetEntry", new[] { "CourseSetId" });
            DropIndex("dbo.Registrations", new[] { "CustomerId" });
            DropIndex("dbo.CourseRegistrations", new[] { "Course_Id" });
            DropIndex("dbo.CourseRegistrations", new[] { "RegistrationId" });
            DropTable("dbo.CourseRegistrations");
            DropTable("dbo.Location");
            DropTable("dbo.CourseTemplate");
            DropTable("dbo.CourseSet");
            DropTable("dbo.CourseSetEntry");
            DropTable("dbo.Customers");
            DropTable("dbo.Registrations");
            DropTable("dbo.Course");
        }
    }
}
