namespace ProjectUni.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class validation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Advs", "phone", c => c.String(nullable: false));
            AlterColumn("dbo.Advs", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.Advs", "price", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Advs", "price", c => c.String());
            AlterColumn("dbo.Advs", "Address", c => c.String());
            AlterColumn("dbo.Advs", "phone", c => c.String());
        }
    }
}
