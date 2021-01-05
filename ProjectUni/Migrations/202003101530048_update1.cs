namespace ProjectUni.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Advs", "ForSwap", c => c.Boolean(nullable: false));
            AddColumn("dbo.Advs", "userid", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Advs", "userid");
            DropColumn("dbo.Advs", "ForSwap");
        }
    }
}
