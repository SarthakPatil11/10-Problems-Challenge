using TaskFileTransferRate.Helper;

namespace TaskFileTransferRate.FileTranserRate
{
    internal class FileSizes
    {
        public static float GetTimeForGB(int nFileSizeGB)
        {
            long nFileSizeB = nFileSizeGB * Constants.B_IN_KB * Constants.KB_IN_MB * Constants.MB_IN_GB;
            return nFileSizeB / Constants.BPS;
        }

        public static float GetTimeForMB(int nFileSizeMB)
        {
            long nFileSizeB = nFileSizeMB * Constants.B_IN_KB * Constants.KB_IN_MB;
            return nFileSizeB / Constants.BPS;
        }

        public static float GetTimeForKB(int nFileSizeKB)
        {
            long nFileSizeB = nFileSizeKB * Constants.B_IN_KB;
            return nFileSizeB / Constants.BPS;
        }

        public static float GetTimeForB(int nFileSizeB)
        {
            return nFileSizeB / Constants.BPS;
        }
    }
}
