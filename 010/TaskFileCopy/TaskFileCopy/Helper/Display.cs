using System;
using System.IO;
using System.Windows.Forms;
using TaskFileCopy.EnumHolder;
using TaskFileCopy.ExceptionHolder;

namespace TaskFileCopy.Helper
{
    /// <summary>
    /// Display class used to display the output of program.
    /// </summary>
    internal class Display
    {
        /// <summary>
        /// Method for showing the error messages.
        /// </summary>
        /// <param name="strError"> For taking the display error message. </param>
        /// <param name="objErrerCode"> For taking the display error code. </param>
        public static void ShowErrorDialog(Form objForm, string strError, ErrorCodes objErrerCode = ErrorCodes.InvalidInput)
        {
            //To set the error message.
            int nErrorNum = (int)objErrerCode;
            int nErrorNumLen = nErrorNum.ToString().Length;
            string strZeros = new string(Constants.MSG_ERROR_CODE_ZEROS, Constants.NUM_OF_ZEROS - nErrorNumLen);
            string strErrorCode = $"{strZeros}{nErrorNum}";
            string strErrorTitle = $"{Constants.MSG_ERROR}{strErrorCode}";

            objForm.Invoke(new MethodInvoker(delegate () { objForm.Enabled = false; }));

            MessageBox.Show(strError, strErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);

            objForm.Invoke(new MethodInvoker(delegate () { objForm.Enabled = true; }));
        }

        /// <summary>
        /// Method for showing the exception messages.
        /// </summary>
        /// <param name="objException"> For taking the display error message. </param>
        public static void ShowExceptionDialog(Form objForm, CustomException objException)
        {
            //To set the exception message.
            int nErrorNum = (int)objException.ErrorCode;
            int nErrorNumLen = nErrorNum.ToString().Length;
            string strZeros = new string(Constants.MSG_ERROR_CODE_ZEROS, Constants.NUM_OF_ZEROS - nErrorNumLen);
            string strErrorCode = $"{strZeros}{nErrorNum}";
            string strErrorTitle = $"{Constants.MSG_EXCEPTION}{strErrorCode}";
            string strErrorMsg = objException.Message;

            if (objException.InnerException != null) //To check there is anu inner exception.
            {
                strErrorMsg += $"{Environment.NewLine}{Constants.MSG_INNER_EXCEPTION}{objException.InnerException.Message}";
            }

            objForm.Invoke(new MethodInvoker(delegate () { objForm.Enabled = false; }));

            MessageBox.Show(objException.Message, strErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            objForm.Invoke(new MethodInvoker(delegate () { objForm.Enabled = true; }));

        }

        /// <summary>
        /// Method for showing the completion messages.
        /// </summary>
        /// <param name="objForm"> To get the form object. </param>
        /// <param name="strFilePath"> To get teh file path. </param>
        public static void ShowCompletionDialog(Form objForm, string strFilePath)
        {
            string strFileName = Path.GetFileName(strFilePath);
            string strMessage = $"{Constants.MSG_FILE_NAME}{strFileName}{Environment.NewLine}{Constants.MSG_STATUS_COMPLETE}";

            objForm.Invoke(new MethodInvoker(delegate () { objForm.Enabled = false; }));

            MessageBox.Show(strMessage, Constants.MSG_TITLE_COMPLETE, MessageBoxButtons.OK, MessageBoxIcon.Information);

            objForm.Invoke(new MethodInvoker(delegate () { objForm.Enabled = true; }));

        }
    }
}