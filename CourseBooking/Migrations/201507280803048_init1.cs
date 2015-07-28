namespace CourseBooking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CourseRegistrations1", "Course_Id", "dbo.Course");
            DropForeignKey("dbo.CourseRegistrations1", "Registration_Id", "dbo.Registrations");
            DropIndex("dbo.CourseRegistrations1", new[] { "Course_Id" });
            DropIndex("dbo.CourseRegistrations1", new[] { "Registration_Id" });
            DropTable("dbo.CourseRegistrations1");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CourseRegistrations1",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Course_Id = c.Int(),
                        Registration_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.CourseRegistrations1", "Registration_Id");
            CreateIndex("dbo.CourseRegistrations1", "Course_Id");
            AddForeignKey("dbo.CourseRegistrations1", "Registration_Id", "dbo.Registrations", "Id");
            AddForeignKey("dbo.CourseRegistrations1", "Course_Id", "dbo.Course", "Id");
        }
    }
}
