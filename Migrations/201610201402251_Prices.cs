namespace CDSC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Prices : DbMigration
    {
        public override void Up()
        {
            CreateTable(
              "dbo.Prices",
              c => new
              {
                  Id = c.Int(nullable: false, identity: true),
                  Counter = c.String(),
                  Price = c.Decimal(),
                  Change = c.Decimal(),
                  Date = c.DateTime(nullable: false),
              })
              .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
            DropTable("dbo.Prices");
        }
    }
}
