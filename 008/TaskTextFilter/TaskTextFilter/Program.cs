using System;
using TaskTextFilter.Execution;

namespace TaskTextFilter
{
    /// <summary>
    /// Progam class it is a driver class that has driver method.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main Method (Driver Method) for executing the processing steps of program.
        /// </summary>
        /// <param name="strarrArgs"> To take the parameter and source file paths from the user. </param>
        static void Main(string[] strarrArgs)
        {
            ExecutionManager.Execute(strarrArgs);

            Console.ReadKey();
        }
    }
}