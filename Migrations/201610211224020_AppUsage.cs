namespace CDSC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AppUsage : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AppUsages",
                c => new
                {   
                    Id = c.Int(nullable: false, identity: true),
                    Activity = c.String(),
                    UserId = c.String(),
                    Date = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.Id);
        }

        public override void Down()
        {
            DropTable("dbo.AppUsages");
        }
    }
}
