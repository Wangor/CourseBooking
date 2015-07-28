namespace CourseBooking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CourseRegistrations1",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Course_Id = c.Int(),
                        Registration_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Course", t => t.Course_Id)
                .ForeignKey("dbo.Registrations", t => t.Registration_Id)
                .Index(t => t.Course_Id)
                .Index(t => t.Registration_Id);
            
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
                        Title = c.String(),
                        Name = c.String(),
                        PreName = c.String(),
                        AddressLine = c.String(),
                        AddressLine2 = c.String(),
                        Phone = c.String(),
                        EMail = c.String(),
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
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Name = c.String(),
                        PreName = c.String(),
                        AddressLine = c.String(),
                        AddressLine2 = c.String(),
                        Phone = c.String(),
                        EMail = c.String(),
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
            DropForeignKey("dbo.CourseRegistrations1", "Registration_Id", "dbo.Registrations");
            DropForeignKey("dbo.CourseRegistrations", "Course_Id", "dbo.Course");
            DropForeignKey("dbo.CourseRegistrations", "RegistrationId", "dbo.Registrations");
            DropForeignKey("dbo.CourseRegistrations1", "Course_Id", "dbo.Course");
            DropIndex("dbo.CourseSetEntry", new[] { "CourseTemplate_Id" });
            DropIndex("dbo.CourseSetEntry", new[] { "CourseSetId" });
            DropIndex("dbo.CourseRegistrations1", new[] { "Registration_Id" });
            DropIndex("dbo.CourseRegistrations", new[] { "Course_Id" });
            DropIndex("dbo.CourseRegistrations", new[] { "RegistrationId" });
            DropIndex("dbo.CourseRegistrations1", new[] { "Course_Id" });
            DropTable("dbo.CourseRegistrations");
            DropTable("dbo.Location");
            DropTable("dbo.Customers");
            DropTable("dbo.CourseTemplate");
            DropTable("dbo.CourseSet");
            DropTable("dbo.CourseSetEntry");
            DropTable("dbo.Registrations");
            DropTable("dbo.Course");
            DropTable("dbo.CourseRegistrations1");
        }
    }
}
