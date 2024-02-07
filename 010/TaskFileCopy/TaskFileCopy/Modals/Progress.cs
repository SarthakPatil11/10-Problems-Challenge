namespace TaskFileCopy.Modals
{
    /// <summary>
    /// To store the progress.
    /// </summary>
    internal class Progress
    {
        #region Private Data Members

        /// <summary>
        /// To store the progress rate.
        /// </summary>
        private int m_nProgressRate;

        /// <summary>
        /// To store the progress status.
        /// </summary>
        private string m_strStatus;

        #endregion

        #region Public Properties

        /// <summary>
        /// To get stored progressrate.
        /// </summary>
        public int ProgressRate
        {
            get { return m_nProgressRate; }
        }

        /// <summary>
        /// To get stored status.
        /// </summary>
        public string Status
        {
            get { return m_strStatus; }
        }

        #endregion

        #region Public Constructor

        /// <summary>
        /// To initialize the progress.
        /// </summary>
        /// <param name="nProgress"> To get the progress. </param>
        /// <param name="strStatus"> To get the status. </param>
        public Progress(int nProgress, string strStatus)
        {
            m_nProgressRate = nProgress;
            m_strStatus = strStatus;
        }

        #endregion
    }
}