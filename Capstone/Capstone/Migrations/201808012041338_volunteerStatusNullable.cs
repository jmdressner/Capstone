namespace Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class volunteerStatusNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Volunteers", "BackgroundCheckStatus", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Volunteers", "BackgroundCheckStatus", c => c.Boolean(nullable: false));
        }
    }
}
