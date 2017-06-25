using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VaporArchive
{
    class Helper
    {
        public static byte[] GetEncryptionKey()
        {
            return GetEncryptionKey(9999699);
        }
        public static byte[] GetEncryptionKey(Int32 seed)
        {
            byte[] key = new byte[64];
            Random r = new Random(seed);
            for (int i = 0; i < 64; i++)
            {
                key[i] = (byte)r.Next();
            }
            return key;
        }

        public static bool CheckValidText(string input, string type)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                System.Windows.MessageBox.Show("Please supply valid " + type);
                return false;
            }
            if (type == "username")
            {
                string pattern1 = @"\[^a-zA-Z0-9 -_]";
                Regex validUsername = new Regex(pattern1);

                if (validUsername.IsMatch(input))
                {
                    System.Windows.MessageBox.Show("Invalid symbols in username: only letters, numbers, spaces, and '-' or '_'");
                    return false;
                }
            }
            if (type == "password")
            {
                string pattern1 = @"[a-z]";
                Regex lowercase = new Regex(pattern1);

                string pattern2 = @"[A-Z]";
                Regex uppercase = new Regex(pattern2);

                string pattern3 = @"[0-9]";
                Regex numbers = new Regex(pattern3);

                //string pattern4 = @"[!~@#$%^&*()]";
                //Regex symbols = new Regex(pattern4);

                if (!lowercase.IsMatch(input))
                {
                    System.Windows.MessageBox.Show("Warning password must contain lowercase letters");
                    return false;
                }
                else if (!uppercase.IsMatch(input))
                {
                    System.Windows.MessageBox.Show("Warning password must contain uppercase letters");
                    return false;
                }
                else if (!numbers.IsMatch(input))
                {
                    System.Windows.MessageBox.Show("Warning password must contain numbers");
                    return false;
                }
            }
            //if (input.Contains(" "))
            //{
            //    System.Windows.MessageBox.Show("Warning contains spaces");
            //}

            return true;
        }
    }
}
