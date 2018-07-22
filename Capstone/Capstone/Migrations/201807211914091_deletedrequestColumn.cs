namespace Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletedrequestColumn : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Availabilities", "RequestID", "dbo.Requests");
            DropIndex("dbo.Availabilities", new[] { "RequestID" });
            AddColumn("dbo.Requests", "VolunteerID", c => c.Int());
            CreateIndex("dbo.Requests", "VolunteerID");
            AddForeignKey("dbo.Requests", "VolunteerID", "dbo.Volunteers", "ID");
            DropColumn("dbo.Availabilities", "RequestID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Availabilities", "RequestID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Requests", "VolunteerID", "dbo.Volunteers");
            DropIndex("dbo.Requests", new[] { "VolunteerID" });
            DropColumn("dbo.Requests", "VolunteerID");
            CreateIndex("dbo.Availabilities", "RequestID");
            AddForeignKey("dbo.Availabilities", "RequestID", "dbo.Requests", "ID", cascadeDelete: true);
        }
    }
}
