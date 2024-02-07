using TaskFileMerger.Execution;

namespace TaskFileMerger
{
    /// <summary>
    /// Progam class it is a driver class that has driver method.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main Method (Driver Method) for giving the interface to the user for calculating Area and Perimeter of different shapes.
        /// </summary>
        /// <param name="args"> To take the folder paths from the user. </param>
        static void Main(string[] args)
        {
            //To run execution flow.
            ExecutionManager.Execute(args[0], args[1]);
        }
    }
}