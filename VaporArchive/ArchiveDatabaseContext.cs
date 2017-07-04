using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Validation;

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
        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
        }
    }
}
