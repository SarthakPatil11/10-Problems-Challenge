﻿using System.Diagnostics;

namespace TaskTextFilter.Helper
{
    /// <summary>
    /// Class used to utility methods.
    /// </summary>
    internal class Utility
    {
        /// <summary>
        /// Method used to to take the current executong method name.
        /// </summary>
        /// <returns> Name of method. </returns>
        public static string GetCurrentMethod()
        {
            //To take the call stack.
            StackTrace objCallStack = new StackTrace();

            //To take the stack frame that is executing.
            StackFrame objStackFrame = objCallStack.GetFrame(Constants.SECOND_FRAME);

            return objStackFrame.GetMethod().Name;
        }
    }
}