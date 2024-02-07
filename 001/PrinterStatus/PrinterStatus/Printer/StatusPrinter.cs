using PrinterStatus.Helper;

namespace PrinterStatus.Printer
{
    /// <summary>
    /// StatusPrinter class for geting the printer status.
    /// </summary>
    internal class StatusPrinter
    {
        /// <summary>
        /// GetStatus method fro returning the status of the printer.
        /// </summary>
        /// <param name="nPaperCount"></param>
        /// <returns>
        /// Status of the printer.
        /// </returns>
        public static string GetStatus(int nPaperCount)
        {
            if (nPaperCount < Constant.NO_PAPER) //If paper count is 0 or less then status No paper should be displayed.
            {
                return (Constant.STATUS_NO_PAPER);
            }
            else if (nPaperCount < Constant.LOW_PAPER) //If paper count is less than 10 then status Low paper should be displayed.
            {
                return (Constant.STATUS_LOW_PAPER);
            }
            else //If paper count is greater thaan 10 then status Ready should be displayed.
            {
                return (Constant.STATUS_READY);
            }
        }
    }
}
