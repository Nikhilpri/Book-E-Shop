namespace PrimaryKeyIntTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CartModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
      
            
        }
        
        public override void Down()
        {
            
            DropTable("dbo.Carts");
        }
    }
}
