using System;
using System.Text;
using TaskTextFilter.EnumHolder;
using TaskTextFilter.ExceptionHolder;
using TaskTextFilter.TextFilterUtility;

namespace TaskTextFilter.Helper
{
    /// <summary>
    /// Display class used to display the output of program.
    /// </summary>
    internal class Display
    {
        #region Public Methods

        /// <summary>
        /// Method for showing the normal messages.
        /// </summary>
        /// <param name="strMessage"> For taking the display message. </param>
        public static void ShowMessage(string strMessage)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            Console.Write($"{strMessage}");
        }

        /// <summary>
        /// Method for showing the error messages.
        /// </summary>
        /// <param name="strError"> For taking the display error message. </param>
        /// <param name="objErrerCode"> For taking the display error code. </param>
        public static void ShowError(string strError, ErrorCodes objErrerCode = ErrorCodes.InvalidInput)
        {
            int nErrorNum = (int)objErrerCode;
            int nErrorNumLen = nErrorNum.ToString().Length;
            string strZeros = new string(Constants.MSG_ERROR_CODE_ZEROS, Constants.NUM_OF_ZEROS - nErrorNumLen);
            string strErrorCode = $"{strZeros}{nErrorNum}";

            Console.WriteLine($"{Constants.MSG_ERROR}{strErrorCode}{Constants.MSG_COLON}{strError}");
        }

        /// <summary>
        /// Method for showing the warning messages.
        /// </summary>
        /// <param name="strWarning"> For taking the display warning message. </param>
        public static void ShowWarning(string strWarning)
        {
            Console.WriteLine($"{Constants.MSG_WARNING}{strWarning}");
        }

        /// <summary>
        /// Method for showing the exception messages.
        /// </summary>
        /// <param name="objException"> For taking the display error message. </param>
        public static void ShowException(CustomException objException)
        {
            int nErrorNum = (int)objException.ErrorCode;
            int nErrorNumLen = nErrorNum.ToString().Length;
            string strZeros = new string(Constants.MSG_ERROR_CODE_ZEROS, Constants.NUM_OF_ZEROS - nErrorNumLen);
            string strErrorCode = $"{strZeros}{nErrorNum}";

            Console.WriteLine($"{Constants.MSG_EXCEPTION}{strErrorCode}{Constants.MSG_COLON}{objException.Message}");

            if (objException.InnerException != null) //To check there is an inner exception.
            {
                Console.WriteLine($"Inner Exception: {objException.InnerException}");
            }
        }

        /// <summary>
        /// Method for showing the header messages.
        /// </summary>
        /// <param name="strHeader"> For taking the display header message. </param>
        public static void ShowHeader(string strHeader, string strSepretor)
        {
            Console.WriteLine($"{strSepretor}{strHeader}{strSepretor}");
        }

        /// <summary>
        /// Method for showing the instruction messages.
        /// </summary>
        /// <param name="strInstruction"> For taking the display instruction message. </param>
        /// <param name="objKey"> For taking the input key for proceed. </param>
        /// <param name="bClearConsole"> For taking the clear the console. </param>
        public static void ShowInstruction(string strInstruction, ConsoleKey objKey, bool bClearConsole = false)
        {
            //For read the key and check.
            do
            {
                //Display the instruction massage.
                Console.WriteLine(strInstruction);
            } while (Console.ReadKey().Key != objKey);

            if (bClearConsole) //To clear console.
            {
                Console.Clear();
            }
        }

        /// <summary>
        /// Method used for showing the command status.
        /// </summary>
        /// <param name="objCommand"> To take the command. </param>
        /// <param name="strCommandStatus"> To take the command status. </param>
        /// <param name="strMode"> To take the mode of display </param>
        public static void ShowCommandStatus(Command objCommand, string strCommandStatus, string strMode)
        {
            if (strMode.ToLower() == Constants.DEBUG_MODE)
            {
                string strStatus = $"{Constants.MSG_COMMAND}{Constants.MSG_OPEN_SQUARE_BRACKET}";

                strStatus += objCommand.StartRange != string.Empty ? $"{objCommand.StartRange}" : "";

                strStatus += objCommand.EndRange != string.Empty ? $"{Constants.MSG_SPACE}{objCommand.EndRange}" : "";

                strStatus += $"{Constants.MSG_SPACE}{objCommand.CommandName}";

                strStatus += objCommand.SearchString != string.Empty ? $"{Constants.MSG_SPACE}{Constants.MSG_SINGLE_QUOTES}{objCommand.SearchString}{Constants.MSG_SINGLE_QUOTES}{objCommand.ReplaceString}{Constants.MSG_SINGLE_QUOTES}" : "";

                strStatus += $"{Constants.MSG_CLOSE_SQUARE_BRACKET}{Constants.MSG_COLON}{strCommandStatus}{Environment.NewLine}";

                ShowMessage(strStatus);
            }
        }

        /// <summary>
        /// To show the output line.
        /// </summary>
        /// <param name="strOutput"> To take the output line. </param>
        public static void ShowOutput(string strOutput)
        {
            ShowMessage($"{Constants.MSG_OUTPUT}{strOutput}{Environment.NewLine}");
        }

        /// <summary>
        /// To show the result after performing commands.
        /// </summary>
        /// <param name="strResult"> To take the result. </param>
        public static void ShowResult(string strResult)
        {
            ShowMessage($"{Environment.NewLine}{Constants.MSG_FILNAL_RESULT}{strResult}{Environment.NewLine}");
        }

        #endregion
    }
}