namespace CDSC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Dividents : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dividends",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    CdsNumber = c.String(nullable: true),
                    DivNumber = c.String(nullable: false),
                    Issuer = c.String(nullable: false),
                    Value =c.Decimal(),
                    PaymentDate =c.DateTime()
                })
                .PrimaryKey(t => t.Id);
        }

        public override void Down()
        {
            DropTable("dbo.Dividends");
        }
    }
}
