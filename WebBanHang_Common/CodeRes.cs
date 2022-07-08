using System;

namespace WebBanHang_Common
{
    public static class CodeRes
    {
        public static string CodeAuto()
        {
            Random rd = new Random();
            int Numrd = rd.Next(100, 999);
            return $"SP_{Numrd}";
        }
    }
}