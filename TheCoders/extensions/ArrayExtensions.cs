using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace TheCoders.extensions
{
    public static class ArrayExtensions
    {
        /// <summary>
        /// Checks if two arrays are identical
        /// </summary>
        /// <typeparam name="T">Data type of arrays</typeparam>
        /// <param name="a">First array being compared</param>
        /// <param name="b">Second Array being compared</param>
        /// <returns>True if every elementy in both arrays are identical</returns>
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
        /// <summary>
        /// Checks if one value is inside of an array atleast once
        /// </summary>
        /// <typeparam name="T">Data type of data value and array</typeparam>
        /// <param name="a">The value to look for</param>
        /// <param name="b">The array to look in</param>
        /// <returns>True if a is in b atleast once </returns>
        public static bool IsIn<T>(this T a, T[] b)
        {
            //Loop through b and compare every value against a
            foreach (var item in b)
            {
                //EqualityComparer has various array comparison methods
                if (EqualityComparer<T>.Default.Equals(item, a))
                {
                    return true;
                }
            }
            return false;
        }
    }
}

