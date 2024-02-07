using System;
using System.Threading;
using TaskMultiThreading.ExceptionHolder;
using TaskMultiThreading.Helper;
using TaskMultiThreading.SupplyChain;

namespace TaskMultiThreading.Execution
{
    /// <summary>
    /// Class ExecutionManager for managing the execution of the program.
    /// </summary>
    internal class ExecutionManager
    {
        #region Public Methods

        /// <summary>
        /// Method Execute for executing the execution flow.
        /// </summary>
        public static void Execute()
        {
            try
            {
                while(true)
                {
                    //To take the inputs.
                    //int nManufacturersCount = InputHelper.ReadInt(Constants.MSG_ENTER_MANUFACTURER);
                    //int nUsersCount = InputHelper.ReadInt(Constants.MSG_ENTER_ENDUSERS);
                    //int ProductsPerManufacturer = InputHelper.ReadInt(Constants.MSG_PRODUCT_PER_MANUFACTURER);
                    //int ProductsPerEndUser = InputHelper.ReadInt(Constants.MSG_PRODUCT_PER_ENDUSERS);
                    Random r = new Random();

                    int nManufacturersCount = r.Next(10, 100);
                    int nUsersCount = r.Next(10, 100);
                    int ProductsPerManufacturer = r.Next(10, 100);
                    int ProductsPerEndUser = r.Next(10, 100);

                    // To perform the supply chain management.
                    SupplyChainManager objSupplyChainManager = new SupplyChainManager();
                    objSupplyChainManager.PerformSupplyChain(nManufacturersCount, nUsersCount, ProductsPerManufacturer, ProductsPerEndUser);

                    //To displya the supply and product stock report.
                    Display.ShowResult(objSupplyChainManager.SupplyReport, objSupplyChainManager.WareHouse);

                    Console.WriteLine($"MF- {nManufacturersCount}, UC- {nUsersCount}, PerMF- {ProductsPerManufacturer}, PerUC- {ProductsPerEndUser}");
                    Console.ReadKey();
                }
            }
            catch (CustomException objException) //To handle the cuntom exception.
            {
                Display.ShowException(objException);
            }

            Console.ReadKey();
        }

        #endregion
    }
}