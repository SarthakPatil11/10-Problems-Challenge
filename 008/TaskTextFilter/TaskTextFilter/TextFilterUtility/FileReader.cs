using System;
using System.Collections.Generic;
using System.IO;
using TaskTextFilter.EnumHolder;
using TaskTextFilter.ExceptionHolder;
using TaskTextFilter.Helper;

namespace TaskTextFilter.TextFilterUtility
{
    /// <summary>
    /// File reader class for the reading the file.
    /// </summary>
    internal class FileReader
    {
        #region Private Data Members

        /// <summary>
        /// Used to store the read file path.
        /// </summary>
        private string m_strReadFilePath;

        #endregion

        #region Public Constructors

        /// <summary>
        /// Used to initialize the read file path.
        /// </summary>
        /// <param name="strReadFile"> To take the read file path. </param>
        public FileReader(string strReadFile)
        {
            m_strReadFilePath = strReadFile;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Used to read all the text in file.
        /// </summary>
        /// <returns> Array of strings that contains all the lines of file. </returns>
        public List<string> ReadFile()
        {
            string strMethodName = $"{Constants.MSG_OCCUR_IN}{Utility.GetCurrentMethod()}{Constants.MSG_METHOD}";
            try
            {
                List<string> strlstAllLines = new List<string>();

                using (StreamReader read = new StreamReader(m_strReadFilePath))
                {
                    string strLine = string.Empty;
                    while ((strLine = read.ReadLine()) != null)
                    {
                        strlstAllLines.Add(strLine);
                    }
                }

                return strlstAllLines;
            }
            catch (UnauthorizedAccessException objException) //If file has no write permission.
            {
                throw new CustomException(ErrorCodes.UnauthorizedAccessException, $"{objException.Message}{strMethodName}");
            }
            catch (IOException objException) //If file has some IO opretion on going.
            {
                throw new CustomException(ErrorCodes.IOException, $"{objException.Message}{strMethodName}");
            }
            catch (ArgumentException objException) //If Write method throws argument exception.
            {
                throw new CustomException(ErrorCodes.ArgumentException, $"{objException.Message}{strMethodName}");
            }
            catch (NotSupportedException objException) //If Write method throws not supported exception.
            {
                throw new CustomException(ErrorCodes.ObjectDisposedException, $"{objException.Message}{strMethodName}");
            }
            catch (Exception objException) //If thre is nay other exception occured.
            {
                throw new CustomException(ErrorCodes.UndefinedException, $"{objException.Message}{strMethodName}", objException);
            }
        }

        #endregion
    }
}