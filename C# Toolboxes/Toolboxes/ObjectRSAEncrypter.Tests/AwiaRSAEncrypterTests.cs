using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectRSAEncrypter.Tests
{
    public class AwiaRSAEncrypterTests
    {
        public static void Main()
        {
            var temp = new AwiaObjectRSAEncrypter(1, 6, 20);
            while(0==0)
            {
                Console.WriteLine("Input a number -> ");
                int input;
                Int32.TryParse(Console.ReadLine(), out input);
                Console.WriteLine("Input: {0}", input);
                long encryptedInt = temp.EncryptInt(input);
                Console.WriteLine("Encrypted: {0}", encryptedInt);
                long decryptedInt = temp.DecryptInt(encryptedInt);
                Console.WriteLine("Decrypted: {0}", decryptedInt);
            }
            
        }
    }
}
