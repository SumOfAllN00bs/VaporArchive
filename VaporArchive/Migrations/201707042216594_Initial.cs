namespace VaporArchive.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        AccountID = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 100),
                        PasswordHash = c.String(nullable: false, maxLength: 1000),
                        AccountCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AccountID);
            
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        GameID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        FilePath = c.String(),
                        SizeKB = c.Int(nullable: false),
                        SubmissionDate = c.DateTime(nullable: false),
                        Price = c.Int(nullable: false),
                        Genre = c.String(),
                        SubmitterID = c.Int(nullable: false),
                        Submitter_AccountID = c.Int(),
                    })
                .PrimaryKey(t => t.GameID)
                .ForeignKey("dbo.Submitters", t => t.Submitter_AccountID)
                .Index(t => t.Submitter_AccountID);
            
            CreateTable(
                "dbo.GameCustomerAccounts",
                c => new
                    {
                        Game_GameID = c.Int(nullable: false),
                        CustomerAccount_AccountID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Game_GameID, t.CustomerAccount_AccountID })
                .ForeignKey("dbo.Games", t => t.Game_GameID, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.CustomerAccount_AccountID, cascadeDelete: true)
                .Index(t => t.Game_GameID)
                .Index(t => t.CustomerAccount_AccountID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerID)
                .ForeignKey("dbo.Accounts", t => t.CustomerID)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.Submitters",
                c => new
                    {
                        SubmitterID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SubmitterID)
                .ForeignKey("dbo.Accounts", t => t.SubmitterID)
                .Index(t => t.SubmitterID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Submitters", "SubmitterID", "dbo.Accounts");
            DropForeignKey("dbo.Customers", "CustomerID", "dbo.Accounts");
            DropForeignKey("dbo.Games", "Submitter_AccountID", "dbo.Submitters");
            DropForeignKey("dbo.GameCustomerAccounts", "CustomerAccount_AccountID", "dbo.Customers");
            DropForeignKey("dbo.GameCustomerAccounts", "Game_GameID", "dbo.Games");
            DropIndex("dbo.Submitters", new[] { "SubmitterID" });
            DropIndex("dbo.Customers", new[] { "CustomerID" });
            DropIndex("dbo.GameCustomerAccounts", new[] { "CustomerAccount_AccountID" });
            DropIndex("dbo.GameCustomerAccounts", new[] { "Game_GameID" });
            DropIndex("dbo.Games", new[] { "Submitter_AccountID" });
            DropTable("dbo.Submitters");
            DropTable("dbo.Customers");
            DropTable("dbo.GameCustomerAccounts");
            DropTable("dbo.Games");
            DropTable("dbo.Accounts");
        }
    }
}
