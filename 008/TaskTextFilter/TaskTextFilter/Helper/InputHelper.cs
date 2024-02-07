using System;

namespace TaskTextFilter.Helper
{
    /// <summary>
    /// InputHelper class used for taking different type of inputs.
    /// </summary>
    internal class InputHelper
    {
        #region Public Methods

        /// <summary>
        /// Method used to read the key.
        /// </summary>
        /// <param name="strDisplayMessage"> To take the display message. </param>
        /// <returns> Object of console key that is read </returns>
        public static ConsoleKey ReadKey(string strDisplayMessage)
        {
            Display.ShowMessage($"{Environment.NewLine}{strDisplayMessage}");
            return Console.ReadKey().Key;
        }

        #endregion
    }
}