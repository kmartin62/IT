namespace ShoppingCart2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V100 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Order1", "orderDetails_OrderDetailId", "dbo.OrderDetails1");
            DropIndex("dbo.Order1", new[] { "orderDetails_OrderDetailId" });
            AddForeignKey("dbo.OrderDetails1", "OrderId", "dbo.Order1", "OrderId", cascadeDelete: true);
            DropColumn("dbo.Order1", "orderDetails_OrderDetailId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Order1", "orderDetails_OrderDetailId", c => c.Int());
            DropForeignKey("dbo.OrderDetails1", "OrderId", "dbo.Order1");
            CreateIndex("dbo.Order1", "orderDetails_OrderDetailId");
            AddForeignKey("dbo.Order1", "orderDetails_OrderDetailId", "dbo.OrderDetails1", "OrderDetailId");
        }
    }
}
