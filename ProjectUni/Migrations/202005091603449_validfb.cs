namespace ProjectUni.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class validfb : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Feadbacks", "phone", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Feadbacks", "phone", c => c.String());
        }
    }
}
