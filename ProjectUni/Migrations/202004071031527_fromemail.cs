namespace ProjectUni.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fromemail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Donates", "FromEmail", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Donates", "FromEmail");
        }
    }
}
