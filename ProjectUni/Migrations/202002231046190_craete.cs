namespace ProjectUni.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class craete : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Advs", "forswapping", c => c.Boolean(nullable: false));
            DropColumn("dbo.Advs", "forswap");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Advs", "forswap", c => c.Boolean(nullable: false));
            DropColumn("dbo.Advs", "forswapping");
        }
    }
}
