namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedCurrentDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dates", "CurrentDate", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Dates", "CurrentDate");
        }
    }
}
