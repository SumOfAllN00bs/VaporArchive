namespace VaporArchive.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AccountIDNamedPerAccount : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Customers", name: "AccountID", newName: "CustomerID");
            RenameColumn(table: "dbo.Submitters", name: "AccountID", newName: "SubmitterID");
            RenameIndex(table: "dbo.Customers", name: "IX_AccountID", newName: "IX_CustomerID");
            RenameIndex(table: "dbo.Submitters", name: "IX_AccountID", newName: "IX_SubmitterID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Submitters", name: "IX_SubmitterID", newName: "IX_AccountID");
            RenameIndex(table: "dbo.Customers", name: "IX_CustomerID", newName: "IX_AccountID");
            RenameColumn(table: "dbo.Submitters", name: "SubmitterID", newName: "AccountID");
            RenameColumn(table: "dbo.Customers", name: "CustomerID", newName: "AccountID");
        }
    }
}
