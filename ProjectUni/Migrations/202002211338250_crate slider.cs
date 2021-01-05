namespace ProjectUni.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class crateslider : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.sliders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Links = c.String(),
                        photo = c.Binary(),
                        CreationTime = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifyTime = c.DateTime(),
                        CreateionUser = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.sliders");
        }
    }
}
