using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace VaporArchive
{
    class ArchiveDatabaseContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<CustomerAccount> Customers { get; set; }
        public DbSet<SubmitterAccount> Submitters { get; set; }
        public DbSet<Game> Games { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //force child class to its own table
            modelBuilder.Entity<CustomerAccount>().ToTable("Customers");
            modelBuilder.Entity<SubmitterAccount>().ToTable("Submitters");
            //rename Column in each child table to reflect table name
            //ie Customers table now has CustomerID rather than AccountID
            modelBuilder.Entity<CustomerAccount>().Property(t => t.AccountID).HasColumnName("CustomerID");
            modelBuilder.Entity<SubmitterAccount>().Property(t => t.AccountID).HasColumnName("SubmitterID");
        }
    }
}
