using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Windows;
using System.Security.Cryptography;

namespace VaporArchive
{
    class Database
    {
        //Accounts
        public bool CreateAccount(string _username, string _password, int _accountType)
        {
            using (ArchiveDatabaseContext dbContext = new ArchiveDatabaseContext())
            {
                try
                {
                    var account = dbContext.Accounts.Where(a => a.UserName == _username).FirstOrDefault();
                    if (account != null)
                    {
                        MessageBox.Show("Username taken!");
                        return false;
                    }
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
                    //fill in account type independent data
                    acc.AccountCreated = DateTime.Now;
                    var saltedPassword = _password + Helper.GetEncryptionKey(acc.AccountCreated.Day);
                    HMACSHA256 hashed = new HMACSHA256(Helper.GetEncryptionKey());
                    acc.PasswordHash = Convert.ToBase64String(hashed.ComputeHash(Encoding.Unicode.GetBytes(saltedPassword)));
                    acc.UserName = _username;
                    //add acc to proper table
                    if (_accountType == 1)
                    {
                        dbContext.Customers.Add((CustomerAccount)acc);

                    }
                    if (_accountType == 2)
                    {
                        dbContext.Submitters.Add((SubmitterAccount)acc);
                    }
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
        public bool Login(string _username, string _password)
        {
            using (ArchiveDatabaseContext dbContext = new ArchiveDatabaseContext())
            {
                Account acc = (from a in dbContext.Accounts
                               where a.UserName == _username
                               select a).FirstOrDefault();
                if (acc == null)
                {
                    MessageBox.Show("Can't find account or password combination");
                    return false;
                }
                else
                {
                    HMACSHA256 hashed = new HMACSHA256(Helper.GetEncryptionKey());
                    var saltedPassword = _password + Helper.GetEncryptionKey(acc.AccountCreated.Day);
                    var PasswordHashed = Convert.ToBase64String(hashed.ComputeHash(Encoding.Unicode.GetBytes(saltedPassword)));
                    if (PasswordHashed == acc.PasswordHash)
                    {
                        Application.Current.Properties.Add("Username", acc.UserName);
                        Application.Current.Properties.Add("AccountType", GetAccountType(acc.UserName));
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Can't find account or password combination");
                        return false;
                    }

                }


            }
        }
        public bool AlterAccount(string _username, string _password)
        {
            using (ArchiveDatabaseContext dbContext = new ArchiveDatabaseContext())
            {
                try
                {
                    var username = (string)Application.Current.Properties["Username"];
                    Account acc = dbContext.Accounts.Where(a => a.UserName == username).FirstOrDefault();
                    if (acc == null)
                    {
                        MessageBox.Show("Error: Can not alter account that does not exist");
                        return false;
                    }
                    //fill in account type independent data
                    var saltedPassword = _password + Helper.GetEncryptionKey(acc.AccountCreated.Day);
                    HMACSHA256 hashed = new HMACSHA256(Helper.GetEncryptionKey());
                    acc.PasswordHash = Convert.ToBase64String(hashed.ComputeHash(Encoding.Unicode.GetBytes(saltedPassword)));
                    acc.UserName = _username;
                    Application.Current.Properties["Username"] = acc.UserName;
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
        public bool RemoveAccount(string _username)
        {
            try
            {
                using (ArchiveDatabaseContext dbContext = new ArchiveDatabaseContext())
                {
                    Account acc = dbContext.Accounts.Where(a => a.UserName == _username).FirstOrDefault();
                    if (acc == null)
                    {
                        MessageBox.Show("Could not find account to delete");
                        return false;
                    }
                    else
                    {
                        dbContext.Accounts.Remove(acc);
                        dbContext.SaveChanges();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            return false;
        }
        public string GetAccountType(string _username)
        {
            try
            {
                using (ArchiveDatabaseContext dbContext = new ArchiveDatabaseContext())
                {
                    Account acc = dbContext.Accounts.Where(a => a.UserName == _username).FirstOrDefault();
                    if (acc != null)
                    {
                        if (dbContext.Customers.Where(c => c.AccountID == acc.AccountID).Any())
                        {
                            return "Customer";
                        }
                        else if (dbContext.Submitters.Where(s => s.AccountID == acc.AccountID).Any())
                        {
                            return "Submitter";
                        }
                        else
                        {
                            return "SysAdmin";
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error: Account missing with Username: " + _username);
                        return "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            return "";
        }

        //Games
        public List<Game> GetGames()
        {
            try
            {
                using (ArchiveDatabaseContext dbContext = new ArchiveDatabaseContext())
                {
                    List<Game> AllGames = dbContext.Games.ToList();
                    return AllGames;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            return null;
        }
        public List<Game> GetGamesBySubmitter(string _username)
        {
            try
            {
                using (ArchiveDatabaseContext dbContext = new ArchiveDatabaseContext())
                {
                    List<Game> AllGames = dbContext.Games.Where(g => g.Submitter.UserName == _username).ToList();
                    return AllGames;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            return null;
        }
    }
}
