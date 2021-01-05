namespace ProjectUni.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class comment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        idadv = c.Int(nullable: false),
                        name = c.String(),
                        phone = c.String(),
                        CreationTime = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifyTime = c.DateTime(),
                        CreateionUser = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Images", "idcomment", c => c.Int());
            CreateIndex("dbo.Images", "idcomment");
            AddForeignKey("dbo.Images", "idcomment", "dbo.comments", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Images", "idcomment", "dbo.comments");
            DropIndex("dbo.Images", new[] { "idcomment" });
            DropColumn("dbo.Images", "idcomment");
            DropTable("dbo.comments");
        }
    }
}
