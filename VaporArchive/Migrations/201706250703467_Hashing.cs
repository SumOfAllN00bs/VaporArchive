namespace VaporArchive.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Hashing : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accounts", "PasswordHash", c => c.String(nullable: false, maxLength: 1000));
            DropColumn("dbo.Accounts", "Password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Accounts", "Password", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.Accounts", "PasswordHash");
        }
    }
}
