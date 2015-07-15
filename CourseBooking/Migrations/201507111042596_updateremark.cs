namespace CourseBooking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateremark : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Course", "Remark", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Course", "Remark", c => c.Int(nullable: false));
        }
    }
}
