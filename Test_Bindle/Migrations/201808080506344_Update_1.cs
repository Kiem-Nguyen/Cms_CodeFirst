namespace Test_Bindle.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ImageProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Url = c.String(maxLength: 200),
                        Url1 = c.String(maxLength: 200),
                        Url2 = c.String(maxLength: 200),
                        Url3 = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        Summary = c.String(maxLength: 100),
                        Decription = c.String(maxLength: 500),
                        Prices = c.Double(nullable: false),
                        Type = c.Int(nullable: false),
                        Size = c.Int(nullable: false),
                        Image = c.Int(nullable: false),
                        Sale = c.Int(nullable: false),
                        ImageProduct_Id = c.Int(),
                        SaleProduct_Id = c.Int(),
                        SizeProduct_Id = c.Int(),
                        TypeProduct_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ImageProducts", t => t.ImageProduct_Id)
                .ForeignKey("dbo.SaleProducts", t => t.SaleProduct_Id)
                .ForeignKey("dbo.SizeProducts", t => t.SizeProduct_Id)
                .ForeignKey("dbo.TypeProducts", t => t.TypeProduct_Id)
                .Index(t => t.ImageProduct_Id)
                .Index(t => t.SaleProduct_Id)
                .Index(t => t.SizeProduct_Id)
                .Index(t => t.TypeProduct_Id);
            
            CreateTable(
                "dbo.SaleProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Sale = c.Double(nullable: false),
                        Name = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SizeProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SizeNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TypeProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameType = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User", "RoleType", "dbo.Roles");
            DropForeignKey("dbo.Products", "TypeProduct_Id", "dbo.TypeProducts");
            DropForeignKey("dbo.Products", "SizeProduct_Id", "dbo.SizeProducts");
            DropForeignKey("dbo.Products", "SaleProduct_Id", "dbo.SaleProducts");
            DropForeignKey("dbo.Products", "ImageProduct_Id", "dbo.ImageProducts");
            DropIndex("dbo.User", new[] { "RoleType" });
            DropIndex("dbo.Products", new[] { "TypeProduct_Id" });
            DropIndex("dbo.Products", new[] { "SizeProduct_Id" });
            DropIndex("dbo.Products", new[] { "SaleProduct_Id" });
            DropIndex("dbo.Products", new[] { "ImageProduct_Id" });
            DropTable("dbo.TypeProducts");
            DropTable("dbo.SizeProducts");
            DropTable("dbo.SaleProducts");
            DropTable("dbo.Products");
            DropTable("dbo.ImageProducts");
        }
    }
}
