using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectRSAEncrypter
{
    public class AwiaRSAEncryptedObject
    {
        public string EncryptedObject { get; private set; }
        public Type ObjecType { get; private set; }
        public AwiaRSAEncryptedObject(string encryptedObject, Type objectType)
        {
            EncryptedObject = encryptedObject;
            ObjecType = objectType;
        }
    }
}
