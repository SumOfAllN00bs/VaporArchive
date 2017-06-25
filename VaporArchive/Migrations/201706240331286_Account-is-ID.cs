namespace VaporArchive.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AccountisID : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customers", "CustomerID");
            DropColumn("dbo.Submitters", "SubmitterID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Submitters", "SubmitterID", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "CustomerID", c => c.Int(nullable: false));
        }
    }
}
