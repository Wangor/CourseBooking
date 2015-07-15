namespace CourseBooking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class registration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CourseRegistrations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Course_Id = c.Int(),
                        RegistrationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Course", t => t.Course_Id)
                .ForeignKey("dbo.Registrations", t => t.RegistrationId, cascadeDelete: true)
                .Index(t => t.Course_Id)
                .Index(t => t.RegistrationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseRegistrations", "RegistrationId", "dbo.Registrations");
            DropForeignKey("dbo.CourseRegistrations", "Course_Id", "dbo.Course");
            DropIndex("dbo.CourseRegistrations", new[] { "RegistrationId" });
            DropIndex("dbo.CourseRegistrations", new[] { "Course_Id" });
            DropTable("dbo.CourseRegistrations");
        }
    }
}
