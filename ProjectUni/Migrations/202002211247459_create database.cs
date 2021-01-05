namespace ProjectUni.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Advs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        title = c.String(),
                        body = c.String(),
                        price = c.String(),
                        forswap = c.Boolean(nullable: false),
                        CreationTime = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifyTime = c.DateTime(),
                        CreateionUser = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        image = c.Binary(),
                        IdAdv = c.Int(nullable: false),
                        CreationTime = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifyTime = c.DateTime(),
                        CreateionUser = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Advs", t => t.IdAdv, cascadeDelete: true)
                .Index(t => t.IdAdv);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        img = c.String(),
                        CreationTime = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifyTime = c.DateTime(),
                        CreateionUser = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Images", "IdAdv", "dbo.Advs");
            DropIndex("dbo.Images", new[] { "IdAdv" });
            DropTable("dbo.Categories");
            DropTable("dbo.Images");
            DropTable("dbo.Advs");
        }
    }
}
