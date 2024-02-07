using TaskFileCopy.Helper;

namespace TaskFileCopy.Modals
{
    /// <summary>
    /// Class TimeInfo for storing total time information data.
    /// </summary>
    internal class TimeInfo
    {
        #region Private Member Variables

        /// <summary>
        /// To store days required to transfer file.
        /// </summary>
        private double m_dblDays;

        /// <summary>
        /// To store hours required to transfer file.
        /// </summary>
        private double m_dblHours;

        /// <summary>
        /// To store minutes required to transfer file.
        /// </summary>
        private double m_dblMinutes;

        /// <summary>
        /// To store seconds required to transfer file.
        /// </summary>
        private double m_dblSeconds;

        #endregion

        #region Constroctors

        /// <summary>
        /// To initialize the member variables.
        /// </summary>
        /// <param name="dblDays"> To initialize member variable Days. </param>
        /// <param name="dblHours"> To initialize member variable Hours. </param>
        /// <param name="dblMinutes"> To initialize member variable Minutes. </param>
        /// <param name="dblSeconds"> To initialize member variable Seconds. </param>
        public TimeInfo(double dblDays, double dblHours, double dblMinutes, double dblSeconds)
        {
            m_dblDays = dblDays;
            m_dblHours = dblHours;
            m_dblMinutes = dblMinutes;
            m_dblSeconds = dblSeconds;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// To manipulate the string as per the output.
        /// </summary>
        /// <param name="strSigularTimeSpan"> To take the sigular form of time span. </param>
        /// <param name="strPluralTimeSpan"> To take the plural form of time span. </param>
        /// <param name="dblTimeSpan"> To take the time span. </param>
        /// <returns> Manuipulated string. </returns>
        private string ManipulateString(string strSigularTimeSpan, string strPluralTimeSpan, double dblTimeSpan)
        {
            string strTimeRequired = (dblTimeSpan > Constants.MIN) ?
                                        (dblTimeSpan > Constants.ONE) ?
                                            $"{strPluralTimeSpan}{dblTimeSpan}"
                                        : $"{strSigularTimeSpan}{dblTimeSpan}"
                                     : "";
            return strTimeRequired;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Overrired method ToString to displaying the object.
        /// </summary>
        /// <returns> The output string of total time required to transfer file. </returns>
        public override string ToString()
        {
            //Put if days are greate than 0.
            string strTimeRequired = ManipulateString(Constants.MSG_DAY, Constants.MSG_DAYS, m_dblDays);

            //Put if hours are greate than 0.
            strTimeRequired += ManipulateString(Constants.MSG_HOUR, Constants.MSG_HOURS, m_dblHours);

            //Put if minutes are greate than 0.
            strTimeRequired += ManipulateString(Constants.MSG_MINUTE, Constants.MSG_MINUTES, m_dblMinutes);

            //Put seconds.
            strTimeRequired += ManipulateString(Constants.MSG_SECOND, Constants.MSG_SECONDS, m_dblSeconds);

            return strTimeRequired;
        }

        #endregion
    }
}