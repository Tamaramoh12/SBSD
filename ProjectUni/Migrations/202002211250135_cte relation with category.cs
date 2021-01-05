namespace ProjectUni.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cterelationwithcategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Advs", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Advs", "CategoryId");
            AddForeignKey("dbo.Advs", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Advs", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Advs", new[] { "CategoryId" });
            DropColumn("dbo.Advs", "CategoryId");
        }
    }
}
