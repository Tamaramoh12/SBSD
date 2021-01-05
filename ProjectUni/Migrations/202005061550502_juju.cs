namespace ProjectUni.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class juju : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Advs", "link", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Advs", "link", c => c.String(nullable: false));
        }
    }
}
