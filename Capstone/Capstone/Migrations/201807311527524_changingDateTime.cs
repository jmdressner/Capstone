namespace Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changingDateTime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "DateOfArrival", c => c.String());
            AlterColumn("dbo.Students", "DateOfRegistration", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "DateOfRegistration", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Students", "DateOfArrival", c => c.DateTime(nullable: false));
        }
    }
}
