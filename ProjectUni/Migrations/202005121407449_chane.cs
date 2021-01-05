namespace ProjectUni.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class chane : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.comments", "idadv");
            AddForeignKey("dbo.comments", "idadv", "dbo.Advs", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.comments", "idadv", "dbo.Advs");
            DropIndex("dbo.comments", new[] { "idadv" });
        }
    }
}
