namespace TaskMultiThreading.Helper
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
        /// Constant usaed to display double dashed line in the output.
        /// </summary>
        public const string MSG_DOUBLE_SEPARATOR = "\n==============================================================\n";

        /// <summary>
        /// onstants used to display enter valid input.
        /// </summary>
        public const string MSG_VALID_INPUT = "Enter valid input!!!";

        /// <summary>
        /// Constant used to show occured in.
        /// </summary>
        public const string MSG_OCCUR_IN = " This exception occured in ";

        /// <summary>
        /// Constant used to show constructor.
        /// </summary>
        public const string MSG_METHOD = " Method.";

        /// <summary>
        /// Constant used to generate the product key.
        /// </summary>
        public const string PRODUCT_ID_CHARS = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz0123456789";

        /// <summary>
        /// Constant used for colon.
        /// </summary>
        public const string MSG_COLON = ": ";

        /// <summary>
        /// Constant used for dash.
        /// </summary>
        public const string MSG_COMMA = ", ";

        /// <summary>
        /// Constant used for declare opning square bracket.
        /// </summary>
        public const string MSG_OPEN_SQUARE_BRACKET = " [";

        /// <summary>
        /// Constant used for declare closing square bracket.
        /// </summary>
        public const string MSG_CLOSE_SQUARE_BRACKET = "] ";

        /// <summary>
        /// Constant used for show end user massege.
        /// </summary>
        public const string MSG_END_USER = "EndUser";

        /// <summary>
        /// Constant used for show manufacturer massege.
        /// </summary>
        public const string MSG_MANUFACTURER = "Manufactureer";

        /// <summary>
        /// Constant used for show product ID massege.
        /// </summary>
        public const string MSG_PRODUCT_ID = "ProductID" + MSG_COLON;

        /// <summary>
        /// Constant used for show manufacturing time massege.
        /// </summary>
        public const string MSG_MANUFACTURER_TIME = MSG_COMMA + "ManufacturingTime" + MSG_COLON;

        /// <summary>
        /// Constant used for show shutdown massege.
        /// </summary>
        public const string MSG_SHUTDOWN = MSG_CLOSE_SQUARE_BRACKET + "Shutdown. ";

        /// <summary>
        /// Constant used for show order complete massege.
        /// </summary>
        public const string MSG_ORDER_COMPLETE = " Order Complete...";

        /// <summary>
        /// Constant used for show order not complete massege.
        /// </summary>
        public const string MSG_ORDER_NOT_COMPLETE = " Order Not Complete...";

        /// <summary>
        /// Constant used for show product stock report massege.
        /// </summary>
        public const string MSG_PRODUCT_STOCK_REPORT = "-- Product Stock Report -- (Stock:";

        /// <summary>
        /// Constant used for show supply report massege.
        /// </summary>
        public const string MSG_SUPPLY_REPORT = "-- Supply Report --";

        /// <summary>
        /// Constant used for show enter manufacture count massege.
        /// </summary>
        public const string MSG_ENTER_MANUFACTURER = "Enter number of manufacturers" + MSG_COLON;

        /// <summary>
        /// Constant used for show enter end user count massege.
        /// </summary>
        public const string MSG_ENTER_ENDUSERS = "Enter number of end-users" + MSG_COLON;

        /// <summary>
        /// Constant used for show enter product per manufacture massege.
        /// </summary>
        public const string MSG_PRODUCT_PER_MANUFACTURER = "Enter number of product per manufacturers" + MSG_COLON;
        /// <summary>
        /// Constant used for show enter product per end massege.
        /// </summary>
        public const string MSG_PRODUCT_PER_ENDUSERS = "Enter number of product per end-user" + MSG_COLON;

        /// <summary>
        /// Constant used for show enter order count massege.
        /// </summary>
        public const string MSG_ORDER_COUNT = MSG_COMMA + "OrderCount" + MSG_COLON;

        /// <summary>
        /// Constant used for show enter product consumed count massege.
        /// </summary>
        public const string MSG_CONSUMED_PRODUCT_COUNT = MSG_COMMA + "ConsumedProductCount" + MSG_COLON;

        /// <summary>
        /// Constant used for show enter product consumption time massege.
        /// </summary>
        public const string MSG_CONSUMPTION_TIME = MSG_COMMA + "ConsumptionTime" + MSG_COLON;

        /// <summary>
        /// Constants used for declareing date time format.
        /// </summary>
        public const string MSG_DATETIME_FORMAT = "MM-dd-yyyTHH:mm:ss.fff";

        #endregion

        #region Character Constants

        /// <summary>
        /// Constants used to declare error code zeros.
        /// </summary>
        public const char MSG_ERROR_CODE_ZEROS = '0';

        /// <summary>
        /// Constant used to add dash.
        /// </summary>
        public const char MSG_DASH = '-';

        /// <summary>
        /// Constant used for declare closing round bracket.
        /// </summary>
        public const char MSG_CLOSING_ROUND_BRACKET = ')';

        #endregion

        #region Integer Constants

        /// <summary>
        /// Constant used for declare zeroth index.
        /// </summary>
        public const int ZEROTH_INDEX = 0;

        /// <summary>
        /// Constant used for declare empty.
        /// </summary>
        public const int MIN = 0;

        /// <summary>
        /// Constant used for declare first index.
        /// </summary>
        public const int FIRST_INDEX = 1;

        /// <summary>
        /// Constant used for declare number of zeros.
        /// </summary>
        public const int NUM_OF_ZEROS = 5;

        /// <summary>
        /// Constant used for declare product ID length
        /// </summary>
        public const int PRODUCT_ID_LEN = 36;

        /// <summary>
        /// Constant used for declare wait time out.
        /// </summary>
        public const int WAIT_TIME_OUT_IN_MILI_SEC = 2000;

        #endregion
    }
}