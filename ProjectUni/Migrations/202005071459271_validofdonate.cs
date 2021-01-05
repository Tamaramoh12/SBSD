namespace ProjectUni.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class validofdonate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Donates", "FromEmail", c => c.String(nullable: false));
            AlterColumn("dbo.Donates", "name", c => c.String(nullable: false));
            AlterColumn("dbo.Donates", "Phone", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Donates", "Phone", c => c.String());
            AlterColumn("dbo.Donates", "name", c => c.String());
            AlterColumn("dbo.Donates", "FromEmail", c => c.String());
        }
    }
}
