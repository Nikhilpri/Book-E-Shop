namespace PrimaryKeyIntTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTypeBookCode : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "BookCode", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Books", "BookCode", c => c.Int(nullable: false));
        }
    }
}
