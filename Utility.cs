using System;
using System.Security.Cryptography;

namespace Utility
{
    public class Utils
    {
        public static string SafeRandomNumber()
        {
            byte[] randomBytes = new byte[64];
            RandomNumberGenerator.Fill(randomBytes);
            return Convert.ToHexString(randomBytes);
        }
    }
}