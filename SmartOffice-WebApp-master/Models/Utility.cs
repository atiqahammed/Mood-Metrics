﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;

namespace SmOffice.Models
{
    public static class Utility
    {
        // 24 = 192 bits
        private const int SaltByteSize = 24;
        private const int HashByteSize = 24;
        private const int HasingIterationsCount = 10101;

        public static byte[] ComputeHash(string password, byte[] salt, int iterations = HasingIterationsCount, int hashByteSize = HashByteSize)
        {
            Rfc2898DeriveBytes hashGenerator = new Rfc2898DeriveBytes(password, salt)
            {
                IterationCount = iterations
            };
            return hashGenerator.GetBytes(hashByteSize);
        }

        public static byte[] GenerateSalt(int saltByteSize = SaltByteSize)
        {
            RNGCryptoServiceProvider saltGenerator = new RNGCryptoServiceProvider();
            byte[] salt = new byte[saltByteSize];
            saltGenerator.GetBytes(salt);
            return salt;
        }

        public static bool VerifyPassword(String password, byte[] passwordSalt, byte[] passwordHash)
        {
            byte[] computedHash = ComputeHash(password, passwordSalt);
            return AreHashesEqual(computedHash, passwordHash);
        }

        //Length constant verification - prevents timing attack
        private static bool AreHashesEqual(byte[] firstHash, byte[] secondHash)
        {
            int minHashLenght = firstHash.Length <= secondHash.Length ? firstHash.Length : secondHash.Length;
            var xor = firstHash.Length ^ secondHash.Length;
            for (int i = 0; i < minHashLenght; i++)
                xor |= firstHash[i] ^ secondHash[i];
            return 0 == xor;
        }

        public static DateTime EmptyDate
        {
            get { return DateTime.Now; }
        }
    }
}