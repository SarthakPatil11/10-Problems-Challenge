using System;
using System.Collections.Generic;
using System.IO;
using System.Security.AccessControl;
using TaskTextFilter.ExceptionHolder;
using TaskTextFilter.Helper;
using TaskTextFilter.Modal;
using TaskTextFilter.TextFilterUtility;
using TaskTextFilter.Validator;

namespace TaskTextFilter.Execution
{
    /// <summary>
    /// Class ExecutionManager for managing the execution of the program.
    /// </summary>
    internal class ExecutionManager
    {
        #region Private Data Members

        /// <summary>
        /// To store the parameter file path.
        /// </summary>
        private static string m_strParamFilePath;

        /// <summary>
        /// To store the source file path.
        /// </summary>
        private static string m_strSrcFilePath;

        /// <summary>
        /// To store the mode of display.
        /// </summary>
        private static string m_strMode = string.Empty;

        #endregion

        #region Private Methods

        /// <summary>
        /// To save the result in to the file.
        /// </summary>
        /// <param name="strFilePath"> To take the input file path. </param>
        /// <param name="lstResult"> To take the result text. </param>
        private static void SaveResult(string strFilePath, List<string> lstResult)
        {
            string strResultFilePath = Path.GetDirectoryName(strFilePath);
            string strFileName = Path.GetFileNameWithoutExtension(strFilePath);
            string strFileExtention = Path.GetExtension(strFilePath);
            string strNewFileName = $"{strFileName}{Constants.MSG_RESULT}{strFileExtention}";

            strResultFilePath = Path.Combine(strResultFilePath, strNewFileName);

            FileWriter.WriteFile(strResultFilePath, lstResult);

            Display.ShowMessage($"{Environment.NewLine}{Constants.MSG_DOUBLE_SEPARATOR}" +
                                $"{Constants.MSG_OUTPUT_FILE}{strResultFilePath}" +
                                $"{Environment.NewLine}{Constants.MSG_DOUBLE_SEPARATOR}");
        }

        /// <summary>
        /// To perform list of vaidetion on athe inputs.
        /// </summary>
        /// <param name="strarrArgs"> To get the inputs. </param>
        /// <returns> Return tru if all inputs are valid else false. </returns>
        private static bool PerformValidations(string[] strarrArgs)
        {
            if (strarrArgs.Length < Constants.MIN_ARGS) //If user have not passes paths.
            {
                Display.ShowError(Constants.MSG_CORRECT_PATH);
                return false;
            }

            m_strParamFilePath = strarrArgs[Constants.ZEROTH_IDX];
            m_strSrcFilePath = strarrArgs[Constants.FIRST_IDX];

            if (strarrArgs.Length == Constants.MODE_ARG) //I there is a thired (mode) argument.
            {
                m_strMode = strarrArgs[Constants.SECOND_IDX];
            }

            Result objPramFileResult = Validations.PerformValidationsOnFile(m_strParamFilePath, FileSystemRights.Read, Constants.MSG_XML_EXTENTION);
            Result objSrcFileResult = Validations.PerformValidationsOnFile(m_strSrcFilePath, FileSystemRights.Read, Constants.MSG_TXT_EXTENTION);

            if (!objPramFileResult.IsSuccess)  //If the file is not valid.
            {
                Display.ShowError(objPramFileResult.ErrorMessage, objPramFileResult.ErrorCode);
                return false;
            }

            if (!objSrcFileResult.IsSuccess) //If the file is not valid.
            {
                Display.ShowError(objSrcFileResult.ErrorMessage, objSrcFileResult.ErrorCode);
                return false;
            }

            return true;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Method Execute for executing the execution flow.
        /// </summary>
        /// <param name="strarrArgs"> To take the parameter and source file paths from the user. </param>
        public static void Execute(string[] strarrArgs)
        {
            bool bIsValid = PerformValidations(strarrArgs);

            if (bIsValid) //To check the all inputs are valid.
            {
                try
                {
                    Display.ShowHeader(Constants.MSG_START, Constants.MSG_SEPARATOR);

                    //To store the list of commands.
                    List<Command> lstParameters = XMLParser.ReadXML(m_strParamFilePath);

                    //To read the source file.
                    FileReader objfileReader = new FileReader(m_strSrcFilePath);
                    List<string> strlstAllFileLines = objfileReader.ReadFile();

                    //To perform filteration on the text.
                    List<string> lstResult = TextFilter.Filter(lstParameters, strlstAllFileLines, m_strMode);

                    Display.ShowHeader(Constants.MSG_END, Constants.MSG_SEPARATOR);

                    //Dispalying save result option and reading key for it.
                    ConsoleKey Key = InputHelper.ReadKey(Constants.MSG_WANT_TO_SAVE);

                    if (Key == ConsoleKey.Y) //if user press Y key then it will save the result.
                    {
                        SaveResult(m_strSrcFilePath, lstResult);
                    }
                }
                catch (CustomException objException) // To hgandle if any exception occured.
                {
                    Display.ShowException(objException);
                }
            }
        }

        #endregion
    }
}