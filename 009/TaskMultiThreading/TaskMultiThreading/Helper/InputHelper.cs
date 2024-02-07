using System;

namespace TaskMultiThreading.Helper
{
    /// <summary>
    /// InputHelper class used for taking different type of inputs.
    /// </summary>
    internal class InputHelper
    {
        #region Public Methods

        /// <summary>
        /// Method used to read the integer type value.
        /// </summary>
        /// <param name="strDisplayMsg"> To take the display message. </param>
        /// <param name="strErrorMsg"> To take the error message. </param>
        /// <returns> Read integer. </returns>
        public static int ReadInt(string strDisplayMsg, string strErrorMsg = Constants.MSG_VALID_INPUT)
        {
            int nValue;
            bool bStop = true;

            //Infinite while loop for taking valid input, runs until user entres the right input.
            do
            {
                //To display message.
                Display.ShowMessage(strDisplayMsg);

                if (int.TryParse(Console.ReadLine(), out nValue)) //To check the input is valid integer or not.
                {
                    if (nValue > Constants.MIN) //To check the input is positive.
                    {
                        bStop = false;
                    }
                }

                if (bStop == true) //To show if the input is not valid integer.
                {
                    Display.ShowError(strErrorMsg);
                }
            } while (bStop);

            return nValue;
        }

        #endregion
    }
}