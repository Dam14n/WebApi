namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMatch : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Matches", "Played", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Matches", "Played");
        }
    }
}
