namespace CDSC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SubscriberProducts : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SubscriberProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubscriberId = c.Int(),
                        ProductId = c.Int(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SubscriberProducts");
        }
    }
}
