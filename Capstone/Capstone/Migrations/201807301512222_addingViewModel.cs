namespace Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingViewModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EventViewModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AdminID = c.Int(),
                        VolunteerID = c.Int(),
                        EventID = c.Int(nullable: false),
                        ResponseID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Admins", t => t.AdminID)
                .ForeignKey("dbo.Events", t => t.EventID, cascadeDelete: true)
                .ForeignKey("dbo.EventResponses", t => t.ResponseID)
                .ForeignKey("dbo.Volunteers", t => t.VolunteerID)
                .Index(t => t.AdminID)
                .Index(t => t.VolunteerID)
                .Index(t => t.EventID)
                .Index(t => t.ResponseID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EventViewModels", "VolunteerID", "dbo.Volunteers");
            DropForeignKey("dbo.EventViewModels", "ResponseID", "dbo.EventResponses");
            DropForeignKey("dbo.EventViewModels", "EventID", "dbo.Events");
            DropForeignKey("dbo.EventViewModels", "AdminID", "dbo.Admins");
            DropIndex("dbo.EventViewModels", new[] { "ResponseID" });
            DropIndex("dbo.EventViewModels", new[] { "EventID" });
            DropIndex("dbo.EventViewModels", new[] { "VolunteerID" });
            DropIndex("dbo.EventViewModels", new[] { "AdminID" });
            DropTable("dbo.EventViewModels");
        }
    }
}
