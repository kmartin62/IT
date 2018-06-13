namespace ShoppingCart2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NV5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Order1", "orderDetails_OrderDetailId", c => c.Int());
            CreateIndex("dbo.Order1", "orderDetails_OrderDetailId");
            AddForeignKey("dbo.Order1", "orderDetails_OrderDetailId", "dbo.OrderDetails1", "OrderDetailId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Order1", "orderDetails_OrderDetailId", "dbo.OrderDetails1");
            DropIndex("dbo.Order1", new[] { "orderDetails_OrderDetailId" });
            DropColumn("dbo.Order1", "orderDetails_OrderDetailId");
        }
    }
}
