namespace ProjectUni.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vidfb : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Advs", "price", c => c.String());
            AlterColumn("dbo.Feadbacks", "name", c => c.String(nullable: false));
            AlterColumn("dbo.Feadbacks", "email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Feadbacks", "email", c => c.String());
            AlterColumn("dbo.Feadbacks", "name", c => c.String());
            AlterColumn("dbo.Advs", "price", c => c.String(nullable: false));
        }
    }
}
