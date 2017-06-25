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
                        Password = c.String(nullable: false, maxLength: 100),
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
                        Submitter_AccountID = c.Int(nullable: false),
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
                        AccountID = c.Int(nullable: false),
                        CustomerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccountID)
                .ForeignKey("dbo.Accounts", t => t.AccountID)
                .Index(t => t.AccountID);
            
            CreateTable(
                "dbo.Submitters",
                c => new
                    {
                        AccountID = c.Int(nullable: false),
                        SubmitterID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccountID)
                .ForeignKey("dbo.Accounts", t => t.AccountID)
                .Index(t => t.AccountID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Submitters", "AccountID", "dbo.Accounts");
            DropForeignKey("dbo.Customers", "AccountID", "dbo.Accounts");
            DropForeignKey("dbo.Games", "Submitter_AccountID", "dbo.Submitters");
            DropForeignKey("dbo.GameCustomerAccounts", "CustomerAccount_AccountID", "dbo.Customers");
            DropForeignKey("dbo.GameCustomerAccounts", "Game_GameID", "dbo.Games");
            DropIndex("dbo.Submitters", new[] { "AccountID" });
            DropIndex("dbo.Customers", new[] { "AccountID" });
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
