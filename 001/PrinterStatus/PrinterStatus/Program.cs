using System;
using PrinterStatus.Helper;
using PrinterStatus.Printer;

namespace PrinterStatus
{
    /// <summary>
    /// Program class for display printer status as per paper count .
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main method (Driver Method) for taiking input as paper count from user and display the printer status.
        /// </summary>
        static void Main()
        {
            //Taking paper count as input.
            int nPaperCount = InputHelper.ReadInt(Constant.INPUT_LINE);

            //Display printer status as per paper count.
            Console.Write(Constant.STATUS);
            Console.WriteLine(StatusPrinter.GetStatus(nPaperCount));

            Console.ReadKey();
        }
    }
}