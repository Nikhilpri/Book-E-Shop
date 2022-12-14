namespace PrimaryKeyIntTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookCartTableLinkOneToMany : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Carts", "BookId");
            AddForeignKey("dbo.Carts", "BookId", "dbo.Books", "BookId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carts", "BookId", "dbo.Books");
            DropIndex("dbo.Carts", new[] { "BookId" });
        }
    }
}
