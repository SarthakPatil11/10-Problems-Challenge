namespace TaskFileCopy.Helper
{
    /// <summary>
    /// Constant class used to help in defining constants.
    /// </summary>
    internal class Constants
    {
        #region String Constants

        /// <summary>
        /// Constants used to display error message.
        /// </summary>
        public const string MSG_ERROR = "Error E";

        /// <summary>
        /// Constants used to display error message.
        /// </summary>
        public const string MSG_EXCEPTION = "Exception E";

        /// <summary>
        /// Constant used to display status complete.
        /// </summary>
        public const string MSG_STATUS = "Status: ";

        /// <summary>
        /// Constant used to display status complete.
        /// </summary>
        public const string MSG_STATUS_COMPLETE = MSG_STATUS + "Complete.";

        /// <summary>
        /// Constant used to display title completed.
        /// </summary>
        public const string MSG_TITLE_COMPLETE = "Completed";

        /// <summary>
        /// Constant used to display file name.
        /// </summary>
        public const string MSG_FILE_NAME = "File Name: ";

        /// <summary>
        /// Constant used for display file has no permission.
        /// </summary>
        public const string MSG_FILE_HAS_NO_PERMISSION = "File has no premission!!!";

        /// <summary>
        /// Constant used for display directory has no permisson..
        /// </summary>
        public const string MSG_DIRECTORY_HAS_NO_PERMISSION = "Directory has no permission!!!";

        /// <summary>
        /// Constant used for display path not exist.
        /// </summary>
        public const string MSG_PATH_NOT_EXIST = "Path not exist!!!";

        /// <summary>
        /// Constant used to display star.
        /// </summary>
        public const string MSG_STAR = "*";

        /// <summary>
        /// Constant used to show occured in.
        /// </summary>
        public const string MSG_OCCUR_IN = " This exception occured in ";

        /// <summary>
        /// Constant used to show method.
        /// </summary>
        public const string MSG_METHOD = " Method.";

        /// <summary>
        /// Constant used to show constructor.
        /// </summary>
        public const string MSG_CONSTRUCTOR = " Constructor.";

        /// <summary>
        /// Constants used to display output as day.
        /// </summary>
        public const string MSG_DAY = " Day: ";

        /// <summary>
        /// Constants used to display output as hour.
        /// </summary>
        public const string MSG_HOUR = " Hour: ";

        /// <summary>
        /// Constants used to display output as minutes.
        /// </summary>
        public const string MSG_MINUTE = " Minute: ";

        /// <summary>
        /// Constants used to display output as seconds.
        /// </summary>
        public const string MSG_SECOND = " Second: ";

        /// <summary>
        /// Constants used to display output as day.
        /// </summary>
        public const string MSG_DAYS = " Days: ";

        /// <summary>
        /// Constants used to display output as hour.
        /// </summary>
        public const string MSG_HOURS = " Hours: ";

        /// <summary>
        /// Constants used to display output as minutes.
        /// </summary>
        public const string MSG_MINUTES = " Minutes: ";

        /// <summary>
        /// Constants used to display output as seconds.
        /// </summary>
        public const string MSG_SECONDS = " Seconds: ";

        /// <summary>
        /// Constants used to display elapsed time.
        /// </summary>
        public const string MSG_ELAPSED_TIME = ", Elapsed Time: ";

        /// <summary>
        /// Constants used to display remaing time.
        /// </summary>
        public const string MSG_REMANING_TIME = ", Time Remaining: ";

        /// <summary>
        /// Constants used to display select file.
        /// </summary>
        public const string MSG_SELECT_FILE = "Select File to Copy";

        /// <summary>
        /// Constants used to display initial directory.
        /// </summary>
        public const string MSG_INITIAL_DIRECTORY = @"C:\";

        /// <summary>
        /// Constants used to display filter.
        /// </summary>
        public const string MSG_FILTER = "All files (*.*)|*.*";

        /// <summary>
        /// Constants used to exception abort.
        /// </summary>
        public const string MSG_EXCEPTION_ABORT = "abort";

        /// <summary>
        /// Constants used to set format.
        /// </summary>
        public const string UPTO_TWO_DECIMAL_FORMAT = "F2";

        public const string MSG_SLASH = "/";

        public const string MSG_KB = "KB: ";

        public const string MSG_MB = "MB: ";

        public const string MSG_BYTES = "BYTES: ";

        /// <summary>
        /// To show the inner exception.
        /// </summary>
        public const string MSG_INNER_EXCEPTION = "Inner Exception: ";

        #endregion

        #region Character Constants

        /// <summary>
        /// Constants used to declare error code zeros.
        /// </summary>
        public const char MSG_ERROR_CODE_ZEROS = '0';

        #endregion

        #region Integer Constants

        /// <summary>
        /// Constant used for declare percentage.
        /// </summary>
        public const int PERCENTAGE = 100;

        /// <summary>
        /// Constant used for declare empty.
        /// </summary>
        public const int MIN = 0;

        /// <summary>
        /// Constant used for declare offset.
        /// </summary>
        public const int OFFSET = 0;

        /// <summary>
        /// Constant used for setting buffer size.
        /// </summary>
        public const int BUFFER_SIZE_IN_BYTES = 1048576; // 1 * 1024 * 1024

        /// <summary>
        /// Constant used for declare first index.
        /// </summary>
        public const int FIRST_INDEX = 1;

        /// <summary>
        /// Constant used for checking nigative number.
        /// </summary>
        public const int ONE = 1;

        /// <summary>
        /// Constant used for declare number of zeros.
        /// </summary>
        public const int NUM_OF_ZEROS = 5;

        /// <summary>
        /// Constants used to calculate hour in day.
        /// </summary>
        public const int HOUR_IN_DAY = 24;

        /// <summary>
        /// Constants used to calculate minutes in hour.
        /// </summary>
        public const int MIN_IN_HOUR = 60;

        /// <summary>
        /// Constants used to calculate seconds in minutes.
        /// </summary>
        public const int SEC_IN_MIN = 60;

        /// <summary>
        /// Constants used to set initial form width.
        /// </summary>
        public const int ININTIAL_FORM_WIDTH = 657;

        /// <summary>
        /// Constants used to set initial form width.
        /// </summary>
        public const int ININTIAL_FORM_HEIGHT = 184;

        /// <summary>
        /// Constants used to set initial form width.
        /// </summary>
        public const int INCREASED_FORM_HEIGHT = 242;

        public const double ONE_KB = 1024;

        public const double ONE_MB = 1024 * ONE_KB;

        public const double ONE_GB = 1024 * ONE_MB * ONE_KB;

        #endregion
    }
}