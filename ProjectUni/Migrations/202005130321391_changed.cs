namespace ProjectUni.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changed : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Advs", "Address", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Advs", "Address", c => c.String());
        }
    }
}
