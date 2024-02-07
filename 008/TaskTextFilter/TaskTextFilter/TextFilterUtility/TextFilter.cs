using System;
using System.Collections.Generic;
using TaskTextFilter.EnumHolder;
using TaskTextFilter.ExceptionHolder;
using TaskTextFilter.Helper;

namespace TaskTextFilter.TextFilterUtility
{
    /// <summary>
    /// Class is used for performin specific command on a text.
    /// </summary>
    internal class TextFilter
    {
        #region Private Data Members

        /// <summary>
        /// To store the result.
        /// </summary>
        private static List<string> m_strlstResult;

        #endregion

        #region Private Methods

        /// <summary>
        /// Method to convert the string range to integer range.
        /// </summary>
        /// <param name="strRange"> To get the range in string format. </param>
        /// <param name="nLastLineNum"> To get the last line number. </param>
        /// <returns> Integer range. </returns>
        private static int Range(string strRange, int nLastLineNum)
        {
            if (strRange == string.Empty || strRange == Constants.MSG_END_OF_FILE_WITH_QUOTE || strRange == Constants.MSG_WITH_QUOTE) //If the range is empty.
            {
                return Constants.MIN;
            }
            else if (strRange == Constants.MSG_END_OF_FILE) //If the range is set to end of the file.
            {
                return nLastLineNum;
            }
            else // If the range has digits.
            {
                int nRange = int.Parse(strRange);
                if (nRange <= nLastLineNum) // If the range has digits.
                {
                    return nRange;
                }
                else // If range is not empty but does not contain digits.
                {
                    return Constants.END_RANGE;
                }
            }
        }

        /// <summary>
        /// Method to get start and end ranges.
        /// </summary>
        /// <param name="objCommand"> To take the command details. </param>
        /// <param name="nLastLineNum"> To get the last line number. </param>
        /// <returns> Start and End range. </returns>
        /// <exception cref="CustomException"> Start and end range is not set properly. </exception>
        private static Tuple<int, int> GetRanges(Command objCommand, int nLastLineNum)
        {
            //To get the start range and end range.
            int nStartRange = Range(objCommand.StartRange, nLastLineNum);
            int nEndRange = Range(objCommand.EndRange, nLastLineNum);

            if (nStartRange != Constants.END_RANGE && nEndRange != Constants.END_RANGE) // If start and end range are correct.
            {
                bool bEndRangeSet = false;

                if (nStartRange == Constants.MIN) // If start range is empty.
                {
                    nStartRange = Constants.START_RANGE;
                }

                if (nEndRange == Constants.MIN) // If end range is empty.
                {
                    if (nStartRange != Constants.MIN) // To check start range is not empty.
                    {
                        bEndRangeSet = true;
                        nEndRange = nStartRange;
                    }
                    else // If end and start ranges are empty. 
                    {
                        nEndRange = nLastLineNum;
                    }
                }

                if (nStartRange == nEndRange && bEndRangeSet == false) // If start and end range are qwual and end range is not set by here.
                {
                    nEndRange = nLastLineNum;
                }
            }
            else
            {
                string strErrorMsg = $"{Constants.MSG_PROPER_RANGES}{Constants.MSG_SPACE}" +
                                     $"{Constants.MSG_OPEN_SQUARE_BRACKET}{objCommand.StartRange}" +
                                     $"{Constants.MSG_SPACE}{objCommand.EndRange}" +
                                     $"{Constants.MSG_SPACE}{objCommand.CommandName}{Constants.MSG_CLOSE_SQUARE_BRACKET}";

                throw new CustomException(ErrorCodes.RangesNotCorrect, strErrorMsg);
            }

            return Tuple.Create(nStartRange, nEndRange);
        }

        /// <summary>
        /// Method to execute the command on line.
        /// </summary>
        /// <param name="objCommand"> To take the command details. </param>
        /// <param name="strLine"> To take the line. </param>
        /// <param name="strMode"> To take the display mode. </param>
        /// <returns> Command name that is executed. </returns>
        private static CommandNames ExecuteCommand(Command objCommand, ref string strLine, string strMode)
        {
            CommandNames objCommandName;
            Enum.TryParse(objCommand.CommandName, out objCommandName);

            switch (objCommandName)
            {
                case CommandNames.s:
                    strLine = strLine.Replace(objCommand.SearchString, objCommand.ReplaceString);
                    return CommandNames.s;

                case CommandNames.d:
                    return CommandNames.d;

                case CommandNames.q:
                    return CommandNames.q;

                case CommandNames.p:
                    if (strMode == Constants.DEBUG_MODE)
                    {
                        Display.ShowOutput(strLine);
                    }
                    return CommandNames.p;
            }

            return CommandNames.q;
        }

        /// <summary>
        /// Method to add remaining lines to the to the result list.
        /// </summary>
        /// <param name="strlstAllFileLines"> To take the source file lines. </param>
        /// <param name="nLineNum"> To take the line number. </param>
        private static void AddRemaningLines(List<string> strlstAllFileLines, int nLineNum)
        {
            for (int i = nLineNum - Constants.DECREMENTER_ONE; i < strlstAllFileLines.Count; i++)
            {
                m_strlstResult.Add(strlstAllFileLines[i]);
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Method to perform filters on the text.
        /// </summary>
        /// <param name="lstParameters"> To take the parameters. </param>
        /// <param name="strlstAllFileLines"> To take the text. </param>
        public static List<string> Filter(List<Command> lstParameters, List<string> strlstAllFileLines, string strMode)
        {
            m_strlstResult = new List<string>();
            int nLineNum = 0;

            try
            {
                //To store the last line number.
                int nLastLineNum = strlstAllFileLines.Count - Constants.DECREMENTER_ONE;

                //To iterate through each and every line of file.
                for (int i = Constants.MIN; i < nLastLineNum; i++)
                {
                    nLineNum = i + Constants.INCREMENTER_ONE;
                    string strLine = strlstAllFileLines[i].Trim();
                    bool bDelLine = false;

                    Display.ShowHeader($"{Constants.MSG_PROCESSING_LINE}{nLineNum}", Constants.MSG_SEPARATOR);

                    //To perform each and every command.
                    foreach (Command objCommand in lstParameters)
                    {
                        //To get start and end ranges.
                        Tuple<int, int> objRanges = GetRanges(objCommand, nLastLineNum);
                        int nStartRange = objRanges.Item1;
                        int nEndRange = objRanges.Item2;

                        if (nLineNum < nStartRange || nLineNum > nEndRange) // If line is not in range of command.
                        {
                            Display.ShowCommandStatus(objCommand, Constants.MSG_NOT_APPLICABLE, strMode);
                            continue;
                        }

                        Display.ShowCommandStatus(objCommand, Constants.MSG_EXECUTED, strMode);

                        //To execute the command on a line.
                        CommandNames objCommandName = ExecuteCommand(objCommand, ref strLine, strMode);
                        if (objCommandName == CommandNames.q) //If quit command is executed.
                        {
                            //To add remaning lines of source file to the result list.
                            AddRemaningLines(strlstAllFileLines, nLineNum);
                            return m_strlstResult;
                        }
                        else if (objCommandName == CommandNames.d) //If delete command is executed.
                        {
                            bDelLine = true;
                            break;
                        }
                    }

                    if (!bDelLine)
                    {
                        Display.ShowResult(strLine);
                        m_strlstResult.Add(strLine);
                    }

                    Display.ShowMessage($"{Constants.MSG_LONG_SEPARATOR}{Environment.NewLine}");
                }
            }
            catch (CustomException objException) //To catch the custom exception.
            {
                Display.ShowException(objException);
            }

            //To add remaning lines of source file to the result list.
            AddRemaningLines(strlstAllFileLines, nLineNum);
            return m_strlstResult;
        }

        #endregion
    }
}