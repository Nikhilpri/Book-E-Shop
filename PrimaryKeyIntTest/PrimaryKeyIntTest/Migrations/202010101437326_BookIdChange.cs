namespace PrimaryKeyIntTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookIdChange : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Books");
            DropColumn("dbo.Books", "Id");
            AddColumn("dbo.Books", "BookId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Books", "BookId");
            
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "Id", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Books");
            DropColumn("dbo.Books", "BookId");
            AddPrimaryKey("dbo.Books", "Id");
        }
    }
}
