namespace ProjectUni.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "link", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "link");
        }
    }
}
