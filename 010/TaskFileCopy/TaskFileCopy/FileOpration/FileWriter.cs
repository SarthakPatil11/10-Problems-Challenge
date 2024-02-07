using System;
using System.IO;
using TaskFileCopy.EnumHolder;
using TaskFileCopy.ExceptionHolder;
using TaskFileCopy.Helper;

namespace TaskFileCopy.FileOpration
{
    /// <summary>
    /// File reader class for the reading the file.
    /// </summary>
    internal class FileWriter : IDisposable
    {
        #region Private Data Members

        /// <summary>
        /// Used to store the write file object.
        /// </summary>
        private FileStream m_objWriteFileStream;

        #endregion

        #region Public Constructors

        /// <summary>
        /// Used to initialize the read file object.
        /// </summary>
        /// <param name="strWriteFile"> To take the write file path. </param>
        public FileWriter(string strWriteFile, FileMode WriteMode)
        {
            string strConstructorName = $"{Constants.MSG_OCCUR_IN}{this.GetType().Name}{Constants.MSG_CONSTRUCTOR}";
            try
            {
                m_objWriteFileStream = new FileStream(strWriteFile, WriteMode, FileAccess.Write);
            }
            catch (UnauthorizedAccessException objException) //If file has no write permission.
            {
                throw new CustomException(ErrorCodes.UnauthorizedAccessException, $"{objException.Message}{strConstructorName}");
            }
            catch (IOException objException) //If file has some IO opretion on going.
            {
                throw new CustomException(ErrorCodes.IOException, $"{objException.Message}{strConstructorName}");
            }
            catch (ArgumentException objException) //If Write method throws argument exception.
            {
                throw new CustomException(ErrorCodes.ArgumentException, $"{objException.Message}{strConstructorName}");
            }
            catch (NotSupportedException objException) //If Write method throws not supported exception.
            {
                throw new CustomException(ErrorCodes.NotSupportedException, $"{objException.Message}{strConstructorName}");
            }
            catch (ObjectDisposedException objException) //If Write method throws object disposed exception.
            {
                throw new CustomException(ErrorCodes.ObjectDisposedException, $"{objException.Message}{strConstructorName}");
            }
            catch (Exception objException)
            {
                throw new CustomException(ErrorCodes.UndefinedException, $"{objException.Message}{strConstructorName}", objException);
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Used to write the file using buffer.
        /// </summary>
        /// <param name="btarrBuffer"> Used to take and give the buffer data. </param>
        /// <returns></returns>
        public void WriteFile(byte[] btarrBuffer, int nBytesRead)
        {
            string strMethodName = $"{Constants.MSG_OCCUR_IN}{Utility.GetCurrentMethod()}{Constants.MSG_METHOD}";
            try
            {
                m_objWriteFileStream.Write(btarrBuffer, Constants.OFFSET, nBytesRead);
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
                throw new CustomException(ErrorCodes.NotSupportedException, $"{objException.Message}{strMethodName}");
            }
            catch (ObjectDisposedException objException) //If Write method throws object disposed exception.
            {
                throw new CustomException(ErrorCodes.ObjectDisposedException, $"{objException.Message}{strMethodName}");
            }
            catch (Exception objException)
            {
                throw new CustomException(ErrorCodes.UndefinedException, $"{objException.Message}{strMethodName}", objException);
            }
        }

        /// <summary>
        /// Method used to close the write file.
        /// </summary>
        public void Close()
        {
            m_objWriteFileStream.Close();
        }

        /// <summary>
        /// Method used to despose the write file object.
        /// </summary>
        public void Dispose()
        {
            m_objWriteFileStream.Dispose();
        }

        #endregion
    }
}