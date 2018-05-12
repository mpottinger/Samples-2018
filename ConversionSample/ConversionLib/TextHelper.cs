﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace ConversionLib
{
    public static class TextHelper
    {
        public static byte[] Encode(this string text, Encoding encoding)
        {
            if (text == null) throw new ArgumentNullException(nameof(text));
            if (encoding == null) throw new ArgumentNullException(nameof(encoding));

            return encoding.GetBytes(text);
        }

        public static string Decode(this byte[] binary, Encoding encoding)
        {
            if (binary == null) throw new ArgumentNullException(nameof(binary));
            if (encoding == null) throw new ArgumentNullException(nameof(encoding));

            return encoding.GetString(binary);
        }

        public static byte[] FromBase64String(this string text)
        {
            if (text == null) throw new ArgumentNullException(nameof(text));

            return Convert.FromBase64String(text);
        }

        public static string ToBase64String(this byte[] binary)
        {
            if (binary == null) throw new ArgumentNullException(nameof(binary));

            return Convert.ToBase64String(binary);
        }

        public static byte[] FromHexString(this string hexString)
        {
            if (hexString == null) throw new ArgumentNullException(nameof(hexString));
            if (hexString.Length % 2 != 0) throw new FormatException("入力文字列の長さが偶数ではありません。");

            return Enumerable.Range(0, hexString.Length / 2)
                .Select(i => hexString.Substring(2 * i, 2))
                .Select(s => byte.Parse(s, NumberStyles.HexNumber))
                .ToArray();
        }

        public static string ToHexString(this byte[] binary, bool lowercase = false)
        {
            if (binary == null) throw new ArgumentNullException(nameof(binary));

            return new string(binary.SelectMany(b => b.ToString(lowercase ? "x2" : "X2")).ToArray());
        }
    }
}
