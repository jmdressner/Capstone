namespace Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zipcode = c.String(),
                        ApplicationUserID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserID)
                .Index(t => t.ApplicationUserID);
            
            CreateTable(
                "dbo.Availabilities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AdminID = c.Int(),
                        VolunteerID = c.Int(),
                        DayID = c.Int(nullable: false),
                        ServiceID = c.Int(nullable: false),
                        RequestID = c.Int(nullable: false),
                        VolunteerStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Admins", t => t.AdminID)
                .ForeignKey("dbo.Programs", t => t.ServiceID, cascadeDelete: true)
                .ForeignKey("dbo.Requests", t => t.RequestID, cascadeDelete: true)
                .ForeignKey("dbo.Volunteers", t => t.VolunteerID)
                .ForeignKey("dbo.Weeks", t => t.DayID, cascadeDelete: true)
                .Index(t => t.AdminID)
                .Index(t => t.VolunteerID)
                .Index(t => t.DayID)
                .Index(t => t.ServiceID)
                .Index(t => t.RequestID);
            
            CreateTable(
                "dbo.Programs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Service = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Requests",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Reason = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Volunteers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zipcode = c.String(),
                        ApplicationUserID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserID)
                .Index(t => t.ApplicationUserID);
            
            CreateTable(
                "dbo.Weeks",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Day = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Occasion = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zipcode = c.String(),
                        Country = c.String(),
                        ServiceID = c.Int(nullable: false),
                        Bio = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Programs", t => t.ServiceID, cascadeDelete: true)
                .Index(t => t.ServiceID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "ServiceID", "dbo.Programs");
            DropForeignKey("dbo.Availabilities", "DayID", "dbo.Weeks");
            DropForeignKey("dbo.Availabilities", "VolunteerID", "dbo.Volunteers");
            DropForeignKey("dbo.Volunteers", "ApplicationUserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Availabilities", "RequestID", "dbo.Requests");
            DropForeignKey("dbo.Availabilities", "ServiceID", "dbo.Programs");
            DropForeignKey("dbo.Availabilities", "AdminID", "dbo.Admins");
            DropForeignKey("dbo.Admins", "ApplicationUserID", "dbo.AspNetUsers");
            DropIndex("dbo.Students", new[] { "ServiceID" });
            DropIndex("dbo.Volunteers", new[] { "ApplicationUserID" });
            DropIndex("dbo.Availabilities", new[] { "RequestID" });
            DropIndex("dbo.Availabilities", new[] { "ServiceID" });
            DropIndex("dbo.Availabilities", new[] { "DayID" });
            DropIndex("dbo.Availabilities", new[] { "VolunteerID" });
            DropIndex("dbo.Availabilities", new[] { "AdminID" });
            DropIndex("dbo.Admins", new[] { "ApplicationUserID" });
            DropTable("dbo.Students");
            DropTable("dbo.Events");
            DropTable("dbo.Weeks");
            DropTable("dbo.Volunteers");
            DropTable("dbo.Requests");
            DropTable("dbo.Programs");
            DropTable("dbo.Availabilities");
            DropTable("dbo.Admins");
        }
    }
}
