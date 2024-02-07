using System;
using System.Collections.Generic;
using TaskMultiThreading.EnumHolder;
using TaskMultiThreading.ExceptionHolder;
using TaskMultiThreading.SupplyChain;

namespace TaskMultiThreading.Helper
{
    /// <summary>
    /// Display class used to display the output of program.
    /// </summary>
    internal class Display
    {
        #region Private Methods

        /// <summary>
        /// Method to show the supply report.
        /// </summary>
        /// <param name="objlstSupplyReport"> To get the supply report. </param>
        private static void ShowSupplyReport(List<Report> objlstSupplyReport)
        {
            ShowMessage($"{Constants.MSG_SUPPLY_REPORT}{Environment.NewLine}");

            foreach (Report objReport in objlstSupplyReport)
            {
                string strReport = $"{objReport}{Environment.NewLine}";
                ShowMessage(strReport);
            }

            ShowMessage(Environment.NewLine);
        }

        /// <summary>
        /// Method to show the product stock report.
        /// </summary>
        /// <param name="objqueueWarehouse"> To get product stock. </param>
        private static void ShowProductStock(Queue<Product> objqueueWarehouse)
        {
            ShowMessage($"{Constants.MSG_PRODUCT_STOCK_REPORT}{objqueueWarehouse.Count}{Constants.MSG_CLOSING_ROUND_BRACKET}{Environment.NewLine}");
            foreach (Product objProduct in objqueueWarehouse)
            {
                string strProduct = $"{objProduct}{Environment.NewLine}";
                ShowMessage(strProduct);
            }
            ShowMessage(Environment.NewLine);
        }

        /// <summary>
        /// To show the consumed details.
        /// </summary>
        /// <param name="objProduct"> To take the product details. </param>
        public static void ShowConsumedDetails(Product objProduct)
        {
            string strConsumedDetails = $"{Constants.MSG_PRODUCT_ID}{objProduct.ProductID}" +
                                        $"{Constants.MSG_COMMA}{Constants.MSG_MANUFACTURER}{Constants.MSG_COLON}{objProduct.Manufacturer}" +
                                        $"{Constants.MSG_COMMA}{Constants.MSG_END_USER}{Constants.MSG_COLON}{objProduct.strCurrentThreadName}" +
                                        $"{Constants.MSG_MANUFACTURER_TIME}{objProduct.ManufactureTime}" +
                                        $"{Constants.MSG_CONSUMPTION_TIME}{objProduct.ConsumptionTime}{Environment.NewLine}";

            ShowMessage(strConsumedDetails);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Method for showing the normal messages.
        /// </summary>
        /// <param name="strMessage"> For taking the display message. </param>
        public static void ShowMessage(string strMessage)
        {
            Console.Write($"{strMessage}");
        }

        /// <summary>
        /// Method for showing the error messages.
        /// </summary>
        /// <param name="strError"> For taking the display error message. </param>
        /// <param name="objErrerCode"> For taking the display error code. </param>
        public static void ShowError(string strError, ErrorCodes objErrerCode = ErrorCodes.InvalidInput)
        {
            int nErrorNum = (int)objErrerCode;
            int nErrorNumLen = nErrorNum.ToString().Length;
            string strZeros = new string(Constants.MSG_ERROR_CODE_ZEROS, Constants.NUM_OF_ZEROS - nErrorNumLen);
            string strErrorCode = $"{strZeros}{nErrorNum}";

            Console.WriteLine($"{Constants.MSG_ERROR}{strErrorCode}{Constants.MSG_COLON}{strError}");
        }

        /// <summary>
        /// Method for showing the exception messages.
        /// </summary>
        /// <param name="objException"> For taking the display error message. </param>
        public static void ShowException(CustomException objException)
        {
            int nErrorNum = (int)objException.ErrorCode;
            int nErrorNumLen = nErrorNum.ToString().Length;
            string strZeros = new string(Constants.MSG_ERROR_CODE_ZEROS, Constants.NUM_OF_ZEROS - nErrorNumLen);
            string strErrorCode = $"{strZeros}{nErrorNum}";

            Console.WriteLine($"{Constants.MSG_EXCEPTION}{strErrorCode}{Constants.MSG_COLON}{objException.Message}");
        }

        /// <summary>
        /// Method for showing the header messages.
        /// </summary>
        /// <param name="strHeader"> For taking the display header message. </param>
        public static void ShowHeader(string strHeader, string strSepretor)
        {
            Console.WriteLine($"{strSepretor}{strHeader}{strSepretor}");
        }

        /// <summary>
        /// To show the result.
        /// </summary>
        /// <param name="objlstSupplyReport"> To get the supply report. </param>
        /// <param name="objqueueWarehouse"> To get product stock. </param>
        public static void ShowResult(List<Report> objlstSupplyReport, Queue<Product> objqueueWarehouse)
        {
            ShowMessage(Constants.MSG_DOUBLE_SEPARATOR);
            ShowSupplyReport(objlstSupplyReport);
            ShowProductStock(objqueueWarehouse);
            ShowMessage(Constants.MSG_DOUBLE_SEPARATOR);
        }

        /// <summary>
        /// Method used to show the shutdown massege.
        /// </summary>
        /// <param name="strThreadName"> To get the thread name. </param>
        /// <param name="nProductConsumedCount"> To get the product consumed count. </param>
        /// <param name="nProductCount"> TO take the product count. </param>
        public static void ShowShutdownMassege(string strThreadName, int nProductConsumedCount, int nProductCount)
        {
            string strShutdown = $"{Constants.MSG_END_USER}{Constants.MSG_OPEN_SQUARE_BRACKET}{strThreadName}{Constants.MSG_SHUTDOWN}";

            if (nProductConsumedCount == nProductCount) // If oreder is complete.
            {
                strShutdown += Constants.MSG_ORDER_COMPLETE;
            }
            else // If oreder is not complete.
            {
                strShutdown += Constants.MSG_ORDER_NOT_COMPLETE;
            }

            ShowMessage($"{strShutdown}{Environment.NewLine}");
        }

        #endregion
    }
}