namespace CourseBooking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _base : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Remark = c.Int(nullable: false),
                        MessageField = c.Int(nullable: false),
                        StartDateTime = c.DateTime(nullable: false),
                        EndDateTime = c.DateTime(nullable: false),
                        CourseTemplateId = c.Int(nullable: false),
                        LocationId = c.Int(nullable: false),
                        MaxParticipants = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CourseSet",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CourseSetEntry",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Sorting = c.Int(nullable: false),
                        CourseTemplate_Id = c.Int(),
                        CourseSetId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CourseTemplate", t => t.CourseTemplate_Id)
                .ForeignKey("dbo.CourseSet", t => t.CourseSetId, cascadeDelete: true)
                .Index(t => t.CourseTemplate_Id)
                .Index(t => t.CourseSetId);
            
            CreateTable(
                "dbo.CourseTemplate",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        NumberOfHours = c.Int(nullable: false),
                        MaxParticipants = c.Int(nullable: false),
                        Location_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Location", t => t.Location_Id)
                .Index(t => t.Location_Id);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseSetEntry", "CourseSetId", "dbo.CourseSet");
            DropForeignKey("dbo.CourseSetEntry", "CourseTemplate_Id", "dbo.CourseTemplate");
            DropForeignKey("dbo.CourseTemplate", "Location_Id", "dbo.Location");
            DropIndex("dbo.CourseSetEntry", new[] { "CourseSetId" });
            DropIndex("dbo.CourseSetEntry", new[] { "CourseTemplate_Id" });
            DropIndex("dbo.CourseTemplate", new[] { "Location_Id" });
            DropTable("dbo.Location");
            DropTable("dbo.CourseTemplate");
            DropTable("dbo.CourseSetEntry");
            DropTable("dbo.CourseSet");
            DropTable("dbo.Course");
        }
    }
}
