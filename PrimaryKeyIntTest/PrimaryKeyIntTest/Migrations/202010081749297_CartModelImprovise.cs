namespace PrimaryKeyIntTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CartModelImprovise : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Carts", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.Carts", "OrderType", c => c.String(nullable: false));
            AddColumn("dbo.Carts", "Address", c => c.String(nullable: false));
            AddColumn("dbo.Carts", "DueDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Carts", "DueDate");
            DropColumn("dbo.Carts", "Address");
            DropColumn("dbo.Carts", "OrderType");
            DropColumn("dbo.Carts", "Quantity");
        }
    }
}
