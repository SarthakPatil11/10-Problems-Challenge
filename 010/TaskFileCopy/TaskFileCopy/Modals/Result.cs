using TaskFileCopy.EnumHolder;
using TaskFileCopy.Helper;

namespace TaskFileCopy.Modals
{
    /// <summary>
    /// Class used to store the result.
    /// </summary>
    internal class Result
    {
        #region Private Data Members

        /// <summary>
        /// To store the success status.
        /// </summary>
        private bool m_bIsSuccess;

        /// <summary>
        /// To store the error code.
        /// </summary>
        private ErrorCodes m_objErrorCode;

        /// <summary>
        /// To store the error massage.
        /// </summary>
        private string m_strErrorMessage;

        #endregion

        #region Public Properties

        /// <summary>
        /// Property to get success status.
        /// </summary>
        public bool IsSuccess
        {
            get { return m_bIsSuccess; }
        }

        /// <summary>
        /// Proprty to get error code.
        /// </summary>
        public ErrorCodes ErrorCode
        {
            get { return m_objErrorCode; }
        }

        /// <summary>
        /// Property to get error message.
        /// </summary>
        public string ErrorMessage
        {
            get { return m_strErrorMessage; }
        }

        #endregion

        #region Public Constructors

        /// <summary>
        /// Constructor to initialize result.
        /// </summary>
        /// <param name="bIsSuccess"> To take the success status. </param>
        /// <param name="objErrorCode"> To take the error code. </param>
        /// <param name="strErrorMessage"> To take the error message. </param>
        public Result(bool bIsSuccess, ErrorCodes objErrorCode, string strErrorMessage)
        {
            m_bIsSuccess = bIsSuccess;
            m_objErrorCode = objErrorCode;
            m_strErrorMessage = strErrorMessage;
        }

        /// <summary>
        /// Constructor to initialize result.
        /// </summary>
        /// <param name="bIsSuccess"> To take the success status. </param>
        public Result(bool bIsSuccess)
        {
            m_bIsSuccess = bIsSuccess;
            m_objErrorCode = Constants.MIN;
            m_strErrorMessage = string.Empty;
        }

        #endregion
    }
}