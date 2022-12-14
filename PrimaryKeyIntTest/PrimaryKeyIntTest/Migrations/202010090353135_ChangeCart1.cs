namespace PrimaryKeyIntTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeCart1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Carts", "OrderStatus", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Carts", "OrderStatus", c => c.Boolean(nullable: false));
        }
    }
}
