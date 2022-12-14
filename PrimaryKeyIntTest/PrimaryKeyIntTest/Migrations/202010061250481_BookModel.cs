namespace PrimaryKeyIntTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BookName = c.String(nullable: false),
                        BookCode = c.Int(nullable: false),
                        BookDescription = c.String(nullable: false),
                        Author = c.String(nullable: false),
                        BookCategory = c.String(nullable: false),
                        BookType = c.String(nullable: false),
                        Option = c.String(nullable: false),
                        Rate = c.Double(nullable: false),
                        Discounts = c.Double(nullable: false),
                        TimeStamp = c.Int(nullable: false),
                        Archived = c.Boolean(nullable: false, defaultValue: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Books");
        }
    }
}
