namespace PrimaryKeyIntTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaymentDetailsModelTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PaymentDetails",
                c => new
                    {
                        txnId = c.Int(nullable: false, identity: true),
                        CardType = c.String(nullable: false),
                        CardMode = c.String(nullable: false),
                        CardNumber = c.String(nullable: false),
                        Cvv = c.String(nullable: false),
                        ExpMonthYear = c.DateTime(nullable: false),
                        NameOnCard = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.txnId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PaymentDetails");
        }
    }
}
