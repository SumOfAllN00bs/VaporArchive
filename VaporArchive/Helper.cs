using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
}
