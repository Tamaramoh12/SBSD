namespace ProjectUni.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createactive : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Advs", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Advs", "IsActive");
        }
    }
}
