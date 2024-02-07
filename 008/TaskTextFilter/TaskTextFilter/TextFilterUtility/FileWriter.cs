using System;
using System.Collections.Generic;
using System.IO;
using System.Security;
using TaskTextFilter.EnumHolder;
using TaskTextFilter.ExceptionHolder;
using TaskTextFilter.Helper;

namespace TaskTextFilter.TextFilterUtility
{
    /// <summary>
    /// File reader class for the reading the file.
    /// </summary>
    internal class FileWriter
    {
        #region Public Methods

        /// <summary>
        /// Used to write the file.
        /// </summary>
        /// <param name="strFilePath"> Used to take file path. </param>
        /// <param name="lstText"> Used to take file data. </param>
        /// <exception cref="CustomException"> If there is any exception occured. </exception>
        public static void WriteFile(string strFilePath, List<string> lstText)
        {
            string strMethodName = $"{Constants.MSG_OCCUR_IN}{Utility.GetCurrentMethod()}{Constants.MSG_METHOD}";
            try
            {
                File.WriteAllLines(strFilePath, lstText);
            }
            catch (UnauthorizedAccessException objException) //If file has no write permission.
            {
                throw new CustomException(ErrorCodes.UnauthorizedAccessException, $"{objException.Message}{strMethodName}");
            }
            catch (DirectoryNotFoundException objException) //If Write method throws object disposed exception.
            {
                throw new CustomException(ErrorCodes.DirectoryNotFoundException, $"{objException.Message}{strMethodName}");
            }
            catch (PathTooLongException objException) //If Write method throws not supported exception.
            {
                throw new CustomException(ErrorCodes.PathTooLongException, $"{objException.Message}{strMethodName}");
            }
            catch (SecurityException objException) //If Write method throws not supported exception.
            {
                throw new CustomException(ErrorCodes.SecurityException, $"{objException.Message}{strMethodName}");
            }
            catch (IOException objException) //If file has some IO opretion on going.
            {
                throw new CustomException(ErrorCodes.IOException, $"{objException.Message}{strMethodName}");
            }
            catch (ArgumentNullException objException) //If Write method throws object disposed exception.
            {
                throw new CustomException(ErrorCodes.ArgumentNullException, $"{objException.Message}{strMethodName}");
            }
            catch (ArgumentException objException) //If Write method throws argument exception.
            {
                throw new CustomException(ErrorCodes.ArgumentException, $"{objException.Message}{strMethodName}");
            }
            catch (NotSupportedException objException) //If Write method throws not supported exception.
            {
                throw new CustomException(ErrorCodes.NotSupportedException, $"{objException.Message}{strMethodName}");
            }
            catch (Exception objException) //If thre is nay other exception occured.
            {
                throw new CustomException(ErrorCodes.UndefinedException, $"{objException.Message}{strMethodName}", objException);
            }
        }
        
        #endregion
    }
}