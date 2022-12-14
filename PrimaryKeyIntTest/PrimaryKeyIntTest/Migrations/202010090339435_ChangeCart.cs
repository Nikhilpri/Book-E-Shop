namespace PrimaryKeyIntTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeCart : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Carts", "OrderStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Carts", "OrderStatus");
        }
    }
}
