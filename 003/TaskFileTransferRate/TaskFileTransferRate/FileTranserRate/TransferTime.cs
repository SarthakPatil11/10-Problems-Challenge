using System;
using TaskFileTransferRate.Helper;

namespace TaskFileTransferRate.FileTranserRate
{
    internal static class TransferTime
    {
        public static string GetTime(float fTotalSec)
        {
            int nDay, nHour, nMinute, nSecond;
            float fDay, fHour, fMinute, fSecond;

            fDay = fTotalSec / Constants.SEC_IN_DAY;
            nDay = Convert.ToInt32(Math.Floor(fDay));
            fDay %= Constants.ONE;

            fHour = fDay * Constants.HOUR_IN_DAY;
            nHour = Convert.ToInt32(Math.Floor(fHour));
            fHour %= Constants.ONE;

            fMinute = fHour * Constants.MIN_IN_HOUR;
            nMinute = Convert.ToInt32(Math.Floor(fMinute));
            fMinute %= Constants.ONE;

            fSecond = fMinute * Constants.SEC_IN_MIN;
            nSecond = Convert.ToInt32(Math.Floor(fSecond));

            return (Constants.DAY + nDay + Constants.HOUR + nHour + Constants.MINUTE + nMinute + Constants.SECOND + nSecond);
        }
        
    }
}
