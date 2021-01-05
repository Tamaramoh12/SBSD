namespace ProjectUni.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "price", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "price");
        }
    }
}
