namespace ProjectUni.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Advs", "link", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Advs", "link");
        }
    }
}
