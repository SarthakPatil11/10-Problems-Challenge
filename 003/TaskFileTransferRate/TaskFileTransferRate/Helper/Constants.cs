namespace TaskFileTransferRate.Helper
{
    /// <summary>
    /// Constant class used to help in defining constants.
    /// </summary>
    internal class Constants
    {
        //Constants used to display switch case.
        public const string MAIN_CHOICE = "Select file size from following:\n1. Bytes.\n2. Kilobytes.\n3. Megabytes.\n4. Gigabytes.\n5.Exit.";
        public const string WRONG_CHOICE = "Wrong choice!!";
        public const string FILE_SIZE = "Enter file size: ";
        public const string CONTINUE = "Enter to continue...";
        //Constant used to display separator in the output.
        public const string SEPARATOR = "------------------------------------------------------";
        //Constants used to display output.
        public const string DAY = "Day: ";
        public const string HOUR = ", Hour: ";
        public const string MINUTE = ", Minute: ";
        public const string SECOND = ", Seconds: ";
        //Constants used to calculate time.
        public const int SEC_IN_DAY = 86400;
        public const int HOUR_IN_DAY = 24;
        public const int MIN_IN_HOUR = 60;
        public const int SEC_IN_MIN = 60;
        //Constants used to file size.
        public const int B_IN_KB = 1024;
        public const int KB_IN_MB = 1024;
        public const int MB_IN_GB = 1024;
        //Constants used to define rate
        public const int BPS = 960;
        public const int ONE = 1;
    }
}