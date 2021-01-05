namespace ProjectUni.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Images", "IdAdv", "dbo.Advs");
            DropIndex("dbo.Images", new[] { "IdAdv" });
            RenameColumn(table: "dbo.Images", name: "Donate_Id", newName: "DonateId");
            RenameIndex(table: "dbo.Images", name: "IX_Donate_Id", newName: "IX_DonateId");
            AlterColumn("dbo.Images", "IdAdv", c => c.Int());
            CreateIndex("dbo.Images", "IdAdv");
            AddForeignKey("dbo.Images", "IdAdv", "dbo.Advs", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Images", "IdAdv", "dbo.Advs");
            DropIndex("dbo.Images", new[] { "IdAdv" });
            AlterColumn("dbo.Images", "IdAdv", c => c.Int(nullable: false));
            RenameIndex(table: "dbo.Images", name: "IX_DonateId", newName: "IX_Donate_Id");
            RenameColumn(table: "dbo.Images", name: "DonateId", newName: "Donate_Id");
            CreateIndex("dbo.Images", "IdAdv");
            AddForeignKey("dbo.Images", "IdAdv", "dbo.Advs", "Id", cascadeDelete: true);
        }
    }
}
