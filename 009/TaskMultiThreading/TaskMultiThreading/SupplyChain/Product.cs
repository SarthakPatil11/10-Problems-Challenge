using TaskMultiThreading.Helper;

namespace TaskMultiThreading.SupplyChain
{
    /// <summary>
    /// Class to store the product details.
    /// </summary>
    internal class Product
    {
        #region Private Data Members

        /// <summary>
        /// To store the manufacturer name.
        /// </summary>
        private string m_strManufacturer;

        /// <summary>
        /// To store the product ID.
        /// </summary>
        private string m_strProductID;

        /// <summary>
        /// To store the manufacture time.
        /// </summary>
        private string m_strManufactureTime;

        /// <summary>
        /// To store the current thread name.
        /// </summary>
        private string m_strCurrentThreadName;

        /// <summary>
        /// To store the consumption time.
        /// </summary>
        private string m_strConsumptionTime;

        #endregion

        #region Public Properties

        /// <summary>
        /// Property to get the manufacturer name.
        /// </summary>
        public string Manufacturer
        {
            get { return m_strManufacturer; }
        }

        /// <summary>
        /// Proprty to get the product ID.
        /// </summary>
        public string ProductID
        {
            get { return m_strProductID; }
        }

        /// <summary>
        /// Property to get the manufacturer time.
        /// </summary>
        public string ManufactureTime
        {
            get { return m_strManufactureTime; }
        }

        /// <summary>
        /// Property to get and set the current thread name.
        /// </summary>
        public string strCurrentThreadName
        {
            get { return m_strCurrentThreadName; }
            set { m_strCurrentThreadName = value; }
        }

        /// <summary>
        /// Property to get and set the consumption time.
        /// </summary>
        public string ConsumptionTime
        {
            get { return m_strConsumptionTime; }
            set { m_strConsumptionTime = value; }
        }

        #endregion

        #region Public Constructors

        /// <summary>
        /// Constuctor to initialize the product details.
        /// </summary>
        /// <param name="strManufacturer"> To get the manufacturer name. </param>
        /// <param name="strProductID"> To get the product ID. </param>
        /// <param name="strManufactureTime"> To get the manufacturer time. </param>
        public Product(string strManufacturer, string strProductID, string strManufactureTime)
        {
            m_strManufacturer = strManufacturer;
            m_strProductID = strProductID;
            m_strManufactureTime = strManufactureTime;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// To show the product's data in a string format.
        /// </summary>
        /// <returns> Supply Reprot details. </returns>
        public override string ToString()
        {
            string strReport = $"{Constants.MSG_MANUFACTURER}{Constants.MSG_COLON}{m_strManufacturer}{Constants.MSG_COMMA}" +
                               $"{Constants.MSG_PRODUCT_ID}{m_strProductID}" +
                               $"{Constants.MSG_MANUFACTURER_TIME}{m_strManufactureTime}";

            return strReport;
        }

        #endregion
    }
}