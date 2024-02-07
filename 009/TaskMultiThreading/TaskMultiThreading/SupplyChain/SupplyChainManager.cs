using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TaskMultiThreading.EnumHolder;
using TaskMultiThreading.ExceptionHolder;
using TaskMultiThreading.Helper;

namespace TaskMultiThreading.SupplyChain
{
    /// <summary>
    /// Class for supply chain managment.
    /// </summary>
    internal class SupplyChainManager
    {
        #region Private Data Members

        /// <summary>
        /// To store the products.
        /// </summary>
        private Queue<Product> m_queueWareHouse;

        /// <summary>
        /// To store the end users supply reports.
        /// </summary>
        private List<Report> m_lstSupplyReport;

        /// <summary>
        /// To store if production is over or not.
        /// </summary>
        private bool m_bProductionOver = false;

        /// <summary>
        /// To store the manufacturing threads.
        /// </summary>
        private Thread[] m_objManufacturers;

        /// <summary>
        /// To store the endusers threads.
        /// </summary>
        private Thread[] m_objEndUsers;

        private static int m_nShutDownManufacturers;
        private static int m_nShutDownEndUsers;

        private ManualResetEvent m_objManualResetManufacturers;
        private ManualResetEvent m_objManualResetEndUsers;

        #endregion

        #region Public Properties

        /// <summary>
        /// To get the product stock details.
        /// </summary>
        public Queue<Product> WareHouse
        {
            get { return m_queueWareHouse; }
        }

        /// <summary>
        /// To get the supply report deatils.
        /// </summary>
        public List<Report> SupplyReport
        {
            get { return m_lstSupplyReport; }
        }

        #endregion

        #region Public Constuctors

        /// <summary>
        /// Constructor to initialize the supply chain manager.
        /// </summary>
        public SupplyChainManager()
        {
            m_queueWareHouse = new Queue<Product>();
            m_lstSupplyReport = new List<Report>();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// To add the product in the warehouse.
        /// </summary>
        /// <param name="nProductCount"> To get the poduct count. </param>
        /// <exception cref="CustomException"> If there is any exception occured. </exception>
        private void AddProducts(int nProductCount)
        {
            string strMethodName = $"{Constants.MSG_OCCUR_IN}{GetType().Name}{Constants.MSG_METHOD}";

            //To add the number product in the warehouse.
            for (int i = Constants.MIN; i < nProductCount; i++)
            {
                //TO get name and the product ID.
                string strManufacturerName = Thread.CurrentThread.Name;
                string strProductID = Guid.NewGuid().ToString();

                string strManufatureTime = DateTime.Now.ToString(Constants.MSG_DATETIME_FORMAT);

                try
                {
                    lock (m_queueWareHouse)
                    {
                        // Add the product in the warehouse (enqueue).
                        Product objProduct = new Product(strManufacturerName, strProductID, strManufatureTime);
                        m_queueWareHouse.Enqueue(objProduct);

                        // to wake the waiting threads.
                        Monitor.PulseAll(m_queueWareHouse);
                    }

                    Interlocked.Increment(ref m_nShutDownManufacturers);
                    if (m_nShutDownManufacturers == m_objManufacturers.Length)
                    {
                        m_objManualResetManufacturers.Set();
                    }
                }
                catch (SynchronizationLockException objException) //If threre is any syncronization lock exception occure.
                {
                    throw new CustomException(ErrorCodes.SynchronizationLockException, $"{objException.Message}{strMethodName}");
                }
                catch (ArgumentNullException objException) //If threre is any argument null exception occure.
                {
                    throw new CustomException(ErrorCodes.ArgumentNullException, $"{objException.Message}{strMethodName}");
                }
                catch (Exception objException) //If threre is any other exception occure.
                {
                    throw new CustomException(ErrorCodes.UndefinedException, $"{objException.Message}{strMethodName}");
                }
            }
        }

        /// <summary>
        /// To dequeue the products from the queue (warehouse).
        /// </summary>
        /// <returns> Product that is consumed. </returns>
        /// <exception cref="CustomException"> If there is any exception occured. </exception>
        private Product DequeueProduct()
        {
            string strMethodName = $"{Constants.MSG_OCCUR_IN}{GetType().Name}{Constants.MSG_METHOD}";
            try
            {
                Product objProduct = null;
                lock (m_queueWareHouse)
                {
                    // TO wait the thread until queue is empty and production is not over.
                    while (m_queueWareHouse.Count == Constants.MIN && m_bProductionOver == false)
                    {
                        Monitor.Wait(m_queueWareHouse);
                    }

                    if (m_queueWareHouse.Count > Constants.MIN) // To check the queue is empty.
                    {
                        //Use product (dequeue).
                        objProduct = m_queueWareHouse.Dequeue();

                        objProduct.strCurrentThreadName = Thread.CurrentThread.Name;
                        objProduct.ConsumptionTime = DateTime.Now.ToString(Constants.MSG_DATETIME_FORMAT);

                        return objProduct;
                    }
                }
            }
            catch (SynchronizationLockException objException) //If threre is any syncronization lock exception occure.
            {
                throw new CustomException(ErrorCodes.SynchronizationLockException, $"{objException.Message}{strMethodName}");
            }
            catch (ThreadInterruptedException objException) //If threre is any thread interrupted exception occure.
            {
                throw new CustomException(ErrorCodes.ThreadInterruptedException, $"{objException.Message}{strMethodName}");
            }
            catch (ArgumentOutOfRangeException objException) //If threre is any argument out of range exception occure.
            {
                throw new CustomException(ErrorCodes.ArgumentOutOfRangeException, $"{objException.Message}{strMethodName}");
            }
            catch (ArgumentNullException objException) //If threre is any argument nul exception occure.
            {
                throw new CustomException(ErrorCodes.ArgumentNullException, $"{objException.Message}{strMethodName}");
            }
            catch (Exception objException) //If threre is any other exception occure.
            {
                throw new CustomException(ErrorCodes.UndefinedException, $"{objException.Message}{strMethodName}");
            }

            return null;
        }

        /// <summary>
        /// To use the product from the warehouse.
        /// </summary>
        /// <param name="nProductCount"> To get the porduct count. </param>
        private void UseProducts(int nProductCount)
        {
            // To get the end user details.
            string strEndUser = Thread.CurrentThread.Name;
            int nOrderCount = nProductCount;
            int nProductConsumedCount = Constants.MIN;

            //To use the products as per order.
            for (int i = Constants.MIN; i < nProductCount; i++)
            {
                Product objProduct = DequeueProduct();
                if (objProduct != null) //To check the product is consumed or not.
                {
                    Display.ShowConsumedDetails(objProduct);
                    nProductConsumedCount++;
                }
            }

            // To add the end user consumprion report.
            Report objReport = new Report(strEndUser, nOrderCount, nProductConsumedCount);
            m_lstSupplyReport.Add(objReport);

            Display.ShowShutdownMassege(Thread.CurrentThread.Name, nProductConsumedCount, nProductCount);

            Interlocked.Increment(ref m_nShutDownEndUsers);
            if(m_nShutDownEndUsers == m_objEndUsers.Length)
            {
                m_objManualResetEndUsers.Set();
            }
        }

        /// <summary>
        /// To call all the maunfacturers to add products in the warehouse
        /// </summary>
        /// <param name="nProductPerManufacturer"> To get the count of products per manufacturer. </param>
        /// <exception cref="CustomException"> If there is any exception occured. </exception>
        private void CallManufacturers(int nProductPerManufacturer)
        {
            string strMethodName = $"{Constants.MSG_OCCUR_IN}{GetType().Name}{Constants.MSG_METHOD}";
            try
            {
                // To initialize the manufacturer threads.
                for (int i = Constants.MIN; i < m_objManufacturers.Count(); i++)
                {
                    int n = i;
                    m_objManufacturers[i] = new Thread(() => AddProducts(nProductPerManufacturer))
                    {
                        Name = $"{Constants.MSG_MANUFACTURER}{Constants.MSG_DASH}{n}"
                    };
                    Display.ShowMessage($"{m_objManufacturers[i].Name}{Environment.NewLine}");
                }

                //To start the threads.
                foreach (Thread objManufacturer in m_objManufacturers)
                {
                    objManufacturer.Start();
                }
            }
            catch (ArgumentNullException objException) //If threre is any argument null exception occure.
            {
                throw new CustomException(ErrorCodes.ArgumentNullException, $"{objException.Message}{strMethodName}");
            }
            catch (Exception objException) //If threre is any other exception occure.
            {
                throw new CustomException(ErrorCodes.UndefinedException, $"{objException.Message}{strMethodName}");
            }
        }

        /// <summary>
        /// To call all the end users to use the product from the warehouse.
        /// </summary>
        /// <param name="nOrderPerEnduser"> To get the order count per user. </param>
        /// <exception cref="CustomException"> If there is any exception occured. </exception>
        private void CallEndUsers(int nOrderPerEnduser)
        {
            string strMethodName = $"{Constants.MSG_OCCUR_IN}{GetType().Name}{Constants.MSG_METHOD}";
            try
            {
                // To initialize the end user threads.
                for (int i = Constants.MIN; i < m_objEndUsers.Count(); i++)
                {
                    int n = i;
                    m_objEndUsers[i] = new Thread(() => UseProducts(nOrderPerEnduser))
                    {
                        Name = $"{Constants.MSG_END_USER}{Constants.MSG_DASH}{n}"
                    };
                    Display.ShowMessage($"{m_objEndUsers[i].Name}{Environment.NewLine}");
                }

                // To start the end uset threads.
                foreach (Thread thread in m_objEndUsers)
                {
                    thread.Start();
                }
            }
            catch (ArgumentNullException objException) //If threre is any argument null exception occure.
            {
                throw new CustomException(ErrorCodes.ArgumentNullException, $"{objException.Message}{strMethodName}");
            }
            catch (Exception objException) //If threre is any other exception occure.
            {
                throw new CustomException(ErrorCodes.UndefinedException, $"{objException.Message}{strMethodName}");
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Method to execute the supply chain managment.
        /// </summary>
        /// <param name="nManufacturersCount"> To take the manufacturers count. </param>
        /// <param name="nUsersCount"> To take the endusers count. </param>
        /// <param name="nProductsPerManufacturer"> To take the product per manufacturer. </param>
        /// <param name="nProductsPerEndUser"> To take the product per end user. </param>
        public void PerformSupplyChain(int nManufacturersCount, int nUsersCount, int nProductsPerManufacturer, int nProductsPerEndUser)
        {
            //To create number of manufactures and end users.
            m_objManufacturers = new Thread[nManufacturersCount];
            m_objEndUsers = new Thread[nUsersCount];

            m_objManualResetManufacturers = new ManualResetEvent(false);
            m_objManualResetEndUsers = new ManualResetEvent(false);

            m_nShutDownManufacturers = Constants.MIN;
            m_nShutDownEndUsers = Constants.MIN;

            //To call Manufacturers and Endusers.
            //CallManufacturers(nProductsPerManufacturer);
            //CallEndUsers(nProductsPerEndUser);

            Task T1 = Task.Run(() =>
            {
                CallManufacturers(nProductsPerManufacturer);
            });

            Task T2 = Task.Run(() =>
            {
                CallEndUsers(nProductsPerEndUser);
            });

            Task.WaitAll(T1, T2);

            ////To hold until all manufacturers manufacture the products.
            //if (m_objManufacturers.Any(objManufacturer => objManufacturer.ThreadState != System.Threading.ThreadState.Stopped))
            //{
            //    m_objManualResetManufacturers.WaitOne();
            //}

            m_objManualResetManufacturers.WaitOne();

            //To set production is over and wake the threads if present.
            lock (m_queueWareHouse)
            {
                m_bProductionOver = true;
                Monitor.PulseAll(m_queueWareHouse);
            }

            //To hold until all endusers use the products.
            //if (m_objEndUsers.Any(objEndUser => objEndUser.ThreadState != System.Threading.ThreadState.Stopped))
            //{
            //    m_objManualResetEndUser.WaitOne();
            //}

            m_objManualResetEndUsers.WaitOne();
        }

        #endregion
    }
}