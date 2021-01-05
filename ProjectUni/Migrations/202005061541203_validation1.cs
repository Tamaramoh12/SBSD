namespace ProjectUni.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class validation1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Advs", "link", c => c.String(nullable: false));
            AlterColumn("dbo.Advs", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.Advs", "body", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Advs", "body", c => c.String());
            AlterColumn("dbo.Advs", "Address", c => c.String());
            AlterColumn("dbo.Advs", "link", c => c.String());
        }
    }
}
