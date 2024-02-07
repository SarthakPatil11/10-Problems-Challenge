using System;
using TaskMultiThreading.Execution;

namespace TaskMultiThreading
{
    /// <summary>
    /// Progam class it is a driver class that has driver method.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main Method (Driver Method) for giving the interface to the user for supply chain managment.
        /// </summary>
        static void Main()
        {
            //To run execution flow.
            ExecutionManager.Execute();

            Console.ReadKey();
        }
    }
}