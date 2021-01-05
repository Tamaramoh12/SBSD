namespace ProjectUni.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createmenu : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.menus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        text = c.String(),
                        link = c.String(),
                        Type = c.String(),
                        auth = c.Int(nullable: false),
                        CreationTime = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifyTime = c.DateTime(),
                        CreateionUser = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.menus");
        }
    }
}
