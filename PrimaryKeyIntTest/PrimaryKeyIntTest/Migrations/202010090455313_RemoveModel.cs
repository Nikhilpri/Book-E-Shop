namespace PrimaryKeyIntTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BookCart", "CartId", "dbo.Carts");
            DropForeignKey("dbo.BookCart", "BookId", "dbo.Books");
            DropIndex("dbo.BookCart", new[] { "CartId" });
            DropIndex("dbo.BookCart", new[] { "BookId" });
            AddColumn("dbo.Carts", "BookId", c => c.Int(nullable: false));
            DropTable("dbo.BookCarts");
            DropTable("dbo.BookCart");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.BookCart",
                c => new
                    {
                        CartId = c.Int(nullable: false),
                        BookId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CartId, t.BookId });
            
            CreateTable(
                "dbo.BookCarts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BookId = c.Int(nullable: false),
                        CartId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Carts", "BookId");
            CreateIndex("dbo.BookCart", "BookId");
            CreateIndex("dbo.BookCart", "CartId");
            AddForeignKey("dbo.BookCart", "BookId", "dbo.Books", "Id", cascadeDelete: true);
            AddForeignKey("dbo.BookCart", "CartId", "dbo.Carts", "Id", cascadeDelete: true);
        }
    }
}
