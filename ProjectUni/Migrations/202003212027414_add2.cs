namespace ProjectUni.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Advs", "Address", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Advs", "Address");
        }
    }
}
