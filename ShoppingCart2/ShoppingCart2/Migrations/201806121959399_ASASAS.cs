namespace ShoppingCart2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ASASAS : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "Total", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "Total", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
