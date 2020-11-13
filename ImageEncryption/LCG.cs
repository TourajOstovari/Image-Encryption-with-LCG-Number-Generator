using System;
using System.Collections.Generic;

namespace ImageEncryption
{
    public static class LCG
    {
        public static List<Int64> lst = new List<long>();
        public static void LCG_(Int64 a, Int64 Xi, Int64 c, Int64 width)
        {
            Int64 width_ = 0;
            while (width_ < width)
            {
                Int64 m = Xi + c;
                Int64 temp = ((a * Xi + c)) % m;
                if (!lst.Contains(temp)) { lst.Add(temp);width_++; }
                else { m *= 2; Xi += 500; c += 550; }
                a = temp;
                
            }
        }
    }
}
