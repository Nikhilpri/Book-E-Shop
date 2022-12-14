namespace PrimaryKeyIntTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TimeStampType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "TimeStamp", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Books", "TimeStamp", c => c.Int(nullable: false));
        }
    }
}
