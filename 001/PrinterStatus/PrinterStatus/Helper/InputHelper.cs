using System;

namespace PrinterStatus.Helper
{
    /// <summary>
    /// InputHelper class for helping to take inputs from the user. 
    /// </summary>
    internal class InputHelper
    {
        /// <summary>
        /// ReadInt method for inputing the int values.
        /// </summary>
        /// <param name="strShowStatement"></param>
        /// <returns>
        /// Integer that have read.
        /// </returns>
        public static int ReadInt(string strShowStatement)
        {
            Console.Write(strShowStatement);
            return Convert.ToInt32(Console.ReadLine());
        }
    }
}
