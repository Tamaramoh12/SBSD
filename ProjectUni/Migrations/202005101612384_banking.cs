namespace ProjectUni.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class banking : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Advs", "ispro", c => c.Boolean());
            AddColumn("dbo.AspNetUsers", "numberofadvs", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "numberofadvs");
            DropColumn("dbo.Advs", "ispro");
        }
    }
}
