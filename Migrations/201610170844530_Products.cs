namespace CDSC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Products : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    Active = c.String(),
                    Charge = c.String(),
                    Date = c.DateTime(nullable: false)
                })
                .PrimaryKey(t => t.Id);

        }

        public override void Down()
        {
            DropTable("dbo.Products");
        }
    }
}
