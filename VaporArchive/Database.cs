using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Windows;

namespace VaporArchive
{
    class Database
    {
        public bool CreateAccount(string _username, string _password, int _accountType)
        {
            using (ArchiveDatabaseContext dbContext = new ArchiveDatabaseContext())
            {
                try
                {
                    Account acc = new Account();
                    if (_accountType == -1)
                    {
                        throw new Exception("Error unexpected Account Type");
                    }
                    //set acc to proper account type
                    if (_accountType == 1)
                    {
                        acc = new CustomerAccount();
                    }
                    if (_accountType == 2)
                    {
                        acc = new SubmitterAccount();
                    }
                    //add acc to proper table
                    if (_accountType == 1)
                    {
                        dbContext.Customers.Add((CustomerAccount)acc);

                    }
                    if (_accountType == 2)
                    {
                        dbContext.Submitters.Add((SubmitterAccount)acc);
                    }
                    //fill in account type independent data
                    acc.AccountCreated = DateTime.Now;
                    acc.Password = _password;
                    acc.UserName = _username;
                    dbContext.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            return false;
        }
    }
}
