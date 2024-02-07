using System;
using System.Diagnostics;
using System.IO;
using TaskFileCopy.EnumHolder;
using TaskFileCopy.ExceptionHolder;
using TaskFileCopy.Helper;
using TaskFileCopy.Modals;

namespace TaskFileCopy.FileOpration
{
    /// <summary>
    /// Class File Merger for coping the file.
    /// </summary>
    internal class FileCopy
    {
        #region Private Data Members

        /// <summary>
        /// To store the instance of file copy form.
        /// </summary>
        private FileCopyForm m_objFileCopyForm;

        /// <summary>
        /// TO store the stopwatch.
        /// </summary>
        private Stopwatch m_objStopwatch;

        /// <summary>
        /// To store the total bytes.
        /// </summary>
        private double m_dblTotalBytes;

        /// <summary>
        /// To store the copied bytes.
        /// </summary>
        private double m_dblBytesCopied;

        /// <summary>
        /// To store the buffer.
        /// </summary>
        private byte[] m_btarrBuffer;

        #endregion

        #region Public Constructor

        /// <summary>
        /// Used to initialize the FileCopy and to store the instance of FileCopyForm.
        /// </summary>
        /// <param name="objFileCopyForm"> To take the file copy form. </param>
        public FileCopy(FileCopyForm objFileCopyForm)
        {
            m_objFileCopyForm = objFileCopyForm;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Method CalculateTime used to get the total time requred to transfer.
        /// </summary>
        /// <param name="decRemainingSec"> Used to take total seconds required tranfer the file. </param>
        /// <returns> TimeInfo object that contains the total time information. </returns>
        public TimeInfo CalculateTime(double decRemainingSec)
        {
            double decDay, decHour, decMinute, decSecond;

            //To get the seconds required to tranfer.
            decSecond = Math.Ceiling(decRemainingSec % Constants.SEC_IN_MIN);
            decRemainingSec /= Constants.SEC_IN_MIN;

            //To get the minutes required to tranfer.
            decMinute = Math.Floor(decRemainingSec % Constants.MIN_IN_HOUR);
            decRemainingSec /= Constants.MIN_IN_HOUR;

            //To get the hours required to tranfer.
            decHour = Math.Floor(decRemainingSec % Constants.HOUR_IN_DAY);
            decRemainingSec /= Constants.HOUR_IN_DAY;

            //To get the days required to tranfer.
            decDay = Math.Floor(decRemainingSec);

            //To create the TimeInfo object to contain total time information.
            TimeInfo objTimeInfo = new TimeInfo(decDay, decHour, decMinute, decSecond);

            return objTimeInfo;
        }

        /// <summary>
        /// TO get the Size message.
        /// </summary>
        /// <returns> Size message. </returns>
        private string GetSizeMessage()
        {
            string strSizeMsg = $"{Constants.MSG_BYTES}{m_dblBytesCopied}{Constants.MSG_SLASH}{m_dblTotalBytes}";

            if(m_dblTotalBytes > Constants.ONE_KB && m_dblTotalBytes < Constants.ONE_MB) //To check if file size is greater than one KB and less than one MB.
            {
                double dblKBCopid = Math.Round(m_dblBytesCopied / Constants.ONE_KB);
                double dblTotalKB = Math.Round(m_dblTotalBytes / Constants.ONE_KB);

                strSizeMsg = $"{Constants.MSG_KB}{dblKBCopid}{Constants.MSG_SLASH}{dblTotalKB}";
            }
            else if(m_dblTotalBytes > Constants.ONE_MB && m_dblTotalBytes < Constants.ONE_GB) //To check if file size is greater than one MB and less than one GB.
            {
                double dblMBCopid = Math.Round(m_dblBytesCopied / Constants.ONE_MB);
                double dblTotalMB = Math.Round(m_dblTotalBytes / Constants.ONE_MB);

                strSizeMsg = $"{Constants.MSG_MB}{dblMBCopid}{Constants.MSG_SLASH}{dblTotalMB}";
            }

            return strSizeMsg;
        }

        /// <summary>
        /// To get the remaining time accoring to speed.
        /// </summary>
        /// <param name="dblSpeed"> To get the speed of the transmission. </param>
        /// <returns> Time remaining. </returns>
        private double RemainingTime(double dblSpeed)
        {
            if (dblSpeed > Constants.MIN) //To check the speed is not 0.
            {
                return (m_dblTotalBytes - m_dblBytesCopied) / dblSpeed;
            }
            else //If the speed is zero.
            {
                return double.MaxValue;
            }
        }

        /// <summary>
        /// To get the progress and status.
        /// </summary>
        /// <returns> Pregress and return. </returns>
        private Progress GetPorgressAndStatus()
        {
            //To calculate elapsed time, speed of transmission and time remaining.
            double dblElapsed = m_objStopwatch.Elapsed.TotalSeconds;
            double dblSpeed = m_dblBytesCopied / dblElapsed;
            double dblTimeRemaining = RemainingTime(dblSpeed);

            //To get in time information format.
            TimeInfo objTimeremaining = CalculateTime(dblTimeRemaining);
            string strStatus = $"{GetSizeMessage()}" +
                               $"{Constants.MSG_ELAPSED_TIME}{dblElapsed.ToString(Constants.UPTO_TWO_DECIMAL_FORMAT)}" +
                               $"{Constants.MSG_ELAPSED_TIME}{objTimeremaining}";

            //To calculate the progress.
            int nProgress = Convert.ToInt32((m_dblBytesCopied / m_dblTotalBytes) * Constants.PERCENTAGE);

            Progress objProgress = new Progress(nProgress, strStatus);
            return objProgress;
        }

        private void ExecuteCopyProcess(string strReadFile, string strWriteFile, Action<int, string> OnProgress)
        {
            string strMethodName = $"{Constants.MSG_OCCUR_IN}{Utility.GetCurrentMethod()}{Constants.MSG_METHOD}";
            try
            {
                int nProgress = Constants.MIN;
                int nBytesRead;

                //To copy the last modifide date-time.
                DateTime objLastModifiedDateTime = File.GetLastWriteTime(strReadFile);
                DateTime objLastModifiedDateTimeUTC = File.GetLastWriteTimeUtc(strReadFile);

                //Write file object
                using (FileWriter objWriteFileStream = new FileWriter(strWriteFile, FileMode.Create))
                {
                    //Read file object.
                    using (FileReader objReadFileStream = new FileReader(strReadFile))
                    {
                        //Read the data and write the data using buffer.
                        while ((nBytesRead = objReadFileStream.ReadFile(m_btarrBuffer)) > Constants.MIN)
                        {
                            //To write bytes.
                            objWriteFileStream.WriteFile(m_btarrBuffer, nBytesRead);
                            m_dblBytesCopied += nBytesRead;

                            //To get progress and status.
                            Progress objProgressStatus = GetPorgressAndStatus();
                            nProgress = objProgressStatus.ProgressRate;
                            string strStatus = objProgressStatus.Status;

                            if (m_objFileCopyForm.ResetEvent.WaitOne(0))
                            //if (m_objFileCopyForm.Stop)
                            {
                                return;
                            }
                            else
                            {
                                //To show the progress and status.
                                OnProgress(nProgress, strStatus);
                            }
                        }
                    }
                }

                //To copy the last modifide date-time.
                File.SetLastWriteTime(strWriteFile, objLastModifiedDateTime);
                File.SetLastWriteTimeUtc(strWriteFile, objLastModifiedDateTimeUTC);

                //To show the progress and status as complete ans stop the stopwatch..
                OnProgress(nProgress, Constants.MSG_STATUS_COMPLETE);

                Display.ShowCompletionDialog(m_objFileCopyForm, strReadFile);
            }
            catch (ArgumentNullException objException) //If it throws the argument null exception.
            {
                throw new CustomException(ErrorCodes.ArgumentNullException, $"{objException.Message}{strMethodName}");
            }
            catch (ArgumentException objException) //If it throws argument exception.
            {
                throw new CustomException(ErrorCodes.ArgumentException, $"{objException.Message}{strMethodName}");
            }
            catch (Exception objException) //If it thros any other exception.
            {
                throw new CustomException(ErrorCodes.UndefinedException, $"{objException.Message}{strMethodName}", objException);
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Method used to merge the files.
        /// </summary>
        /// <param name="strReadFile"> To take the all read files. </param>
        /// <param name="strWriteFile"> To take the all write files. </param>
        /// <param name="OnProgress"> To take the call back. </param>
        public void Copy(string strReadFile, string strWriteFile, Action<int, string> OnProgress)
        {
            try
            {
                //Buffer to read data.
                m_btarrBuffer = new byte[Constants.BUFFER_SIZE_IN_BYTES];

                //Total bytes for get updates.
                m_dblTotalBytes = Convert.ToDouble(new FileInfo(strReadFile).Length);
                m_dblBytesCopied = Constants.MIN;
                
                //Stopwatch to get the time of execution.
                m_objStopwatch = new Stopwatch();
                m_objStopwatch.Start();

                ExecuteCopyProcess(strReadFile, strWriteFile, OnProgress);

                m_objStopwatch.Stop();

            }
            catch (CustomException objException) //To handle the cuntom exception.
            {
                Display.ShowExceptionDialog(m_objFileCopyForm, objException);
            }
        }

        #endregion
    }
}