using TaskMultiThreading.Helper;

namespace TaskMultiThreading.SupplyChain
{
    /// <summary>
    /// Class to store the consumption report.
    /// </summary>
    internal class Report
    {
        #region Private Data Members

        /// <summary>
        /// To store the end user name.
        /// </summary>
        private string m_strEndUser;

        /// <summary>
        /// To store the order count.
        /// </summary>
        private int m_nOrderCount;

        /// <summary>
        /// To store the consumned product count.
        /// </summary>
        private int m_nConsumedProductCount;

        #endregion

        #region Public Constructors

        /// <summary>
        /// Constuctor to initialize the end user report details.
        /// </summary>
        /// <param name="strEndUser"> To get the end user name. </param>
        /// <param name="nOrderCount"> To get the order count. </param>
        /// <param name="nConsumedProductCount"> To get the consumed product count. </param>
        public Report(string strEndUser, int nOrderCount, int nConsumedProductCount)
        {
            m_strEndUser = strEndUser;
            m_nOrderCount = nOrderCount;
            m_nConsumedProductCount = nConsumedProductCount;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// To show the report's data in a string format.
        /// </summary>
        /// <returns> Reprot details. </returns>
        public override string ToString()
        {
            string strReport = $"{Constants.MSG_END_USER}{Constants.MSG_COLON}{m_strEndUser}" +
                               $"{Constants.MSG_ORDER_COUNT}{m_nOrderCount}" +
                               $"{Constants.MSG_CONSUMED_PRODUCT_COUNT}{m_nConsumedProductCount}";

            return strReport;
        }

        #endregion
    }
}