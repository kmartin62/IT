namespace ShoppingCart2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NV3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderDetailId = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        BookId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Price = c.String(),
                    })
                .PrimaryKey(t => t.OrderDetailId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.OrderDetails");
        }
    }
}
