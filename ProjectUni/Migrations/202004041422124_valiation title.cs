namespace ProjectUni.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class valiationtitle : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Advs", "title", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Advs", "title", c => c.String());
        }
    }
}
