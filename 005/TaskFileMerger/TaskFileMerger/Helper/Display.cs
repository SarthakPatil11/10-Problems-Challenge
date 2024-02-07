using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskFileMerger.Helper
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
            Console.Write($"{strMessage}");
        }

        /// <summary>
        /// Method for showing the error messages.
        /// </summary>
        /// <param name="strError"> For taking the display error message. </param>
        public static void ShowError(string strError)
        {
            Console.WriteLine($"{Constants.MSG_ERROR}{strError}");
        }

        /// <summary>
        /// Method for showing the header messages.
        /// </summary>
        public static void Header()
        {
            Console.WriteLine(Constants.HEADER_MSG_MAIN_CHOICE_APPEND);
            Console.WriteLine(Constants.HEADER_MSG_MAIN_CHOICE_CREATE);
            Console.WriteLine(Constants.HEADER_MSG_MAIN_CHOICE_OVERRIDE);
            Console.WriteLine(Constants.HEADER_MSG_MAIN_CHOICE_EXIT);
        }

        /// <summary>
        /// Method for showing the exception messages.
        /// </summary>
        /// <param name="objException"> For taking the display error message. </param>
        public static void ShowException(Exception objException)
        {
            Console.WriteLine($"{Constants.MSG_EXCEPTION}{objException.Message}");
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

        #endregion
    }
}
