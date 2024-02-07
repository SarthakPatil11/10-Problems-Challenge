﻿using System;

namespace Shape.Helper
{
    /// <summary>
    /// Input class used for taking different type of inputs.
    /// </summary>
    internal static class InputHelper
    {
        /// <summary>
        /// Method used to read the integer type value.
        /// </summary>
        /// <param name="DisplayMsg"></param>
        /// <returns>
        /// Read integer.
        /// </returns>
        public static int ReadInt(string DisplayMsg)
        {
            Console.WriteLine(DisplayMsg);
            return Convert.ToInt32(Console.ReadLine());
        }

        /// <summary>
        /// Method used to read the float type value.
        /// </summary>
        /// <param name="DisplayMsg"></param>
        /// <returns>
        /// Read float.
        /// </returns>
        public static float ReadFloat(string DisplayMsg)
        {
            Console.WriteLine(DisplayMsg);
            return Convert.ToSingle(Console.ReadLine());
        }
    }
}
