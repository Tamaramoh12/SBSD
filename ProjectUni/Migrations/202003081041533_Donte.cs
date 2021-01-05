namespace ProjectUni.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Donte : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Donates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        Phone = c.String(),
                        Longitude = c.String(),
                        Latitude = c.String(),
                        CreationTime = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifyTime = c.DateTime(),
                        CreateionUser = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Images", "Donate_Id", c => c.Int());
            CreateIndex("dbo.Images", "Donate_Id");
            AddForeignKey("dbo.Images", "Donate_Id", "dbo.Donates", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Images", "Donate_Id", "dbo.Donates");
            DropIndex("dbo.Images", new[] { "Donate_Id" });
            DropColumn("dbo.Images", "Donate_Id");
            DropTable("dbo.Donates");
        }
    }
}
