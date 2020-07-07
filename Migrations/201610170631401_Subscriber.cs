namespace CDSC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Subscriber : DbMigration
    {
        public override void Up()
        {

            CreateTable(
               "dbo.Subscribers",
               c => new
               {
                   Id = c.Int(nullable: false, identity: true),
                   PhoneNumber = c.String(nullable: true),
                   Email = c.String(),
                   Username = c.String(),
                   Password = c.String(),
                   Active = c.Boolean(),
                   Date = c.DateTime(),
               })
               .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
            DropTable("dbo.Subscriber");
        }
    }
}
