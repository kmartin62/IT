namespace MVCLab5._1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FriendTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FriendModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FriendId = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Place = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FriendModels");
        }
    }
}
