namespace ProjectUni.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Advs", "phone", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Advs", "phone");
        }
    }
}
