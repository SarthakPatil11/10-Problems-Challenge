using System;
using TaskFileMerger.EnumHolder;

namespace TaskFileMerger.Helper
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
                    bStop = false;
                }
                else //To show if the input is not valid integer.
                {
                    Display.ShowError(strErrorMsg);
                }
            } while (bStop);

            return nValue;
        }

        /// <summary>
        /// Method used to read the Enum type value.
        /// </summary>
        /// <param name="strDisplayMsg"> To take the display message. </param>
        /// <returns> FileOpretionChoice </returns>
        public static FileOpretionChoice ReadEnum(string strDisplayMsg)
        {
            FileOpretionChoice Opretion;
            bool bStop = true;

            do
            {
                //To take the choice of Choice form the user.
                Display.Header();
                Opretion = (FileOpretionChoice)ReadInt(strDisplayMsg);

                if (Enum.IsDefined(typeof(FileOpretionChoice), Opretion)) //To check the input is valid enum or not
                {
                    bStop = false;
                }
                else //To show if the input is not valid enum.
                {
                    Display.ShowError(Constants.MSG_VALID_INPUT);
                    Display.ShowInstruction(Constants.MSG_CONTINUE, ConsoleKey.Enter, true);
                }
            } while (bStop);

            return Opretion;
        }

        #endregion
    }
}
