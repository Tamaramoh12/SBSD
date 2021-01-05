namespace ProjectUni.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedonate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Donates", "Longitude", c => c.String(nullable: false));
            AlterColumn("dbo.Feadbacks", "note", c => c.String(nullable: false));
            DropColumn("dbo.Donates", "Latitude");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Donates", "Latitude", c => c.String());
            AlterColumn("dbo.Feadbacks", "note", c => c.String());
            AlterColumn("dbo.Donates", "Longitude", c => c.String());
        }
    }
}
