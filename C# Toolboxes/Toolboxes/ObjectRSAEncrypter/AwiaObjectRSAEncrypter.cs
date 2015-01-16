using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ObjectRSAEncrypter
{
    public class AwiaObjectRSAEncrypter
    {
        public long PublicKey { get; set; }
        private long _primeProduct { get; set; }
        private long _totient { get; set; }
        private long _privateKey { get; set; }
        private long[] _primes { get; set; }

        public Random RandomGenerator { get; set; }

        public AwiaObjectRSAEncrypter(int seed, long minPrime, long maxPrime)
        {
            RandomGenerator = new Random(seed);
            _primes = GeneratePrimes(minPrime, maxPrime);
            GenerateKeys();
        }

        private long[] GeneratePrimes(long minPrime, long maxPrime)
        {
            var primes = new List<long>();
            if (minPrime >= 1 && maxPrime >= minPrime)
            {
                for (long i = minPrime; i <= maxPrime; i++)
                {
                    if (IsPrime(i))
                    {
                        primes.Add(i);
                    }
                }
            }
            return primes.ToArray();
        }

        private bool IsPrime(long number)
        {
            if (number <= 3)
            {
                return number > 1;
            }
            else if (number%2 == 0 || number%3 == 0)
            {
                return false;
            }
            else
            {
                for (int i = 5; i*i <= number; i += 6)
                {
                    if (number%i == 0 || number%(i + 2) == 0)
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        private void GenerateKeys()
        {
            // Generate primes.
            long firstPrime = _primes[RandomGenerator.Next(0, _primes.Length - 1)];
            long secondPrime;
            do
            {
                secondPrime = _primes[RandomGenerator.Next(0, _primes.Length - 1)];
            } while (secondPrime == firstPrime);

            // Generate Product and Totient
            _primeProduct = firstPrime*secondPrime;
            _totient = (firstPrime - 1)*(secondPrime - 1);

            // Generate public key
            PublicKey = GenerateRelativePrimeToZ(firstPrime, secondPrime);

            // Generate private key
            _privateKey = GeneratePrivateKey();
        }

        private long GeneratePrivateKey()
        {
            for (int i = 3; i < _totient; i++)
            {
                if (_totient%(PublicKey*i - 1) == 0)
                {
                    return i;
                }
                if (PublicKey*i - 1 == _totient)
                {
                    return i;
                }
            }
            throw new Exception();
        }

        private long GenerateRelativePrimeToZ(long prime1, long prime2)
        {
            for (long i = 3; i < _totient; i++)
            {
                if (GCD(i, prime2 - 1) == 1 && GCD(i, prime1 - 1) == 1 && GCD(i, _totient) == 1)
                {
                    return i;
                }
            }
            throw new Exception("Private key generation failed.");
        }

        public long GCD(long a, long b)
        {
            while (b != 0)
            {
                long tmp = b;
                b = a%b;
                a = tmp;
            }

            return a;
        }

        public long EncryptInt(int intToEncrypt)
        {
            return (long) Math.Pow(intToEncrypt, PublicKey)%_primeProduct;
        }

        public long DecryptInt(long intToDencrypt)
        {
            return (long) Math.Pow(intToDencrypt, _privateKey)%_primeProduct;
        }

        public AwiaRSAEncryptedObject EncryptObject<T>(T objectToEncrypt)
        {
            return new AwiaRSAEncryptedObject(objectToEncrypt.ToString(), objectToEncrypt.GetType());
        }

        public T DecryptObject<T>(AwiaRSAEncryptedObject objectToDencrypt)
        {
            throw new Exception();
        }
    }
}