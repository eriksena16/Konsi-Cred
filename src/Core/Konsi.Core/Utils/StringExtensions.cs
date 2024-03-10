﻿using System.Text.RegularExpressions;

namespace Konsi.Core
{
    public static class StringExtensions
    {
        public static bool IsCpfValid(this string cpf)
        {
            string pattern = @"^\d{3}\.\d{3}\.\d{3}-\d{2}$";
            return Regex.IsMatch(cpf, pattern);
        }

        public static string FormatCPF(this string CPF)
        {
            return Convert.ToUInt64(CPF).ToString(@"000\.000\.000\-00");
        }
    }
}
