namespace ShoppingCart2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NV4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderDetails1",
                c => new
                    {
                        OrderDetailId = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        BookId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Price = c.String(),
                    })
                .PrimaryKey(t => t.OrderDetailId)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.BookId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails1", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.OrderDetails1", "BookId", "dbo.Books");
            DropIndex("dbo.OrderDetails1", new[] { "BookId" });
            DropIndex("dbo.OrderDetails1", new[] { "OrderId" });
            DropTable("dbo.OrderDetails1");
        }
    }
}
