using System;
using System.Collections.Generic;
using System.Text;

namespace TheCoders.extensions
{
    public static class ArrayExtensions
    {
        public static bool EqualTo<T>(this T[] a, T[] b)
        {
            if (a is null || b is null)
            {
                return a == b;
            }
            else
            {
                return a.SequenceEqual(b);
            }
        }

        public static bool IsIn<T>(this T a, T[] b)
        {
            foreach (var item in b)
            {
                if (EqualityComparer<T>.Default.Equals(item, a))
                {
                    return true;
                }
            }
            return false;
        }
    }
}

