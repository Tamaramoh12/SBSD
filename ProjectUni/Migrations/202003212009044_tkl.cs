//namespace ProjectUni.Migrations
//{
//    using System;
//    using System.Data.Entity.Migrations;
    
//    public partial class tkl : DbMigration
//    {
//        public override void Up()
//        {
//            CreateTable(
//                "dbo.Feadbacks",
//                c => new
//                    {
//                        Id = c.Int(nullable: false, identity: true),
//                        name = c.String(),
//                        email = c.String(),
//                        phone = c.String(),
//                        note = c.String(),
//                        CreationTime = c.DateTime(),
//                        IsDeleted = c.Boolean(nullable: false),
//                        ModifyTime = c.DateTime(),
//                        CreateionUser = c.String(),
//                    })
//                .PrimaryKey(t => t.Id);
            
//        }
        
//        public override void Down()
//        {
//            DropTable("dbo.Feadbacks");
//        }
//    }
//}
