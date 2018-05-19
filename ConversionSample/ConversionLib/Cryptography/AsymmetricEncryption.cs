﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace ConversionLib.Cryptography
{
    public static class AsymmetricEncryption
    {
        public const int KeyLengthInBits = 2048;

        // The Encoding.UTF8.GetBytes method does not prepend a preamble to the encoded byte sequence.
        static byte[] ToBytes(this string data) => Encoding.UTF8.GetBytes(data);
        static string ToText(this byte[] data) => Encoding.UTF8.GetString(data);

        public static AsymmetricKeys GenerateKeys()
        {
            using (var algorithm = new RSACryptoServiceProvider(KeyLengthInBits))
            {
                return new AsymmetricKeys
                {
                    PublicKey = algorithm.ToXmlString(false),
                    KeysPair = algorithm.ToXmlString(true),
                };
            }
        }

        public static byte[] Encrypt(byte[] data, string publicKey)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));
            if (publicKey == null) throw new ArgumentNullException(nameof(publicKey));

            using (var algorithm = new RSACryptoServiceProvider())
            {
                algorithm.FromXmlString(publicKey);

                return algorithm.Encrypt(data, false);
            }
        }

        public static byte[] Decrypt(byte[] data, string keysPair)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));
            if (keysPair == null) throw new ArgumentNullException(nameof(keysPair));

            using (var algorithm = new RSACryptoServiceProvider())
            {
                algorithm.FromXmlString(keysPair);

                return algorithm.Decrypt(data, false);
            }
        }

        public static string Encrypt(string data, string publicKey)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));

            return Convert.ToBase64String(Encrypt(data.ToBytes(), publicKey));
        }

        public static string Decrypt(string data, string keysPair)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));

            return Decrypt(Convert.FromBase64String(data), keysPair).ToText();
        }
    }

    public class AsymmetricKeys
    {
        public string PublicKey { get; internal set; }
        public string KeysPair { get; internal set; }
    }
}
