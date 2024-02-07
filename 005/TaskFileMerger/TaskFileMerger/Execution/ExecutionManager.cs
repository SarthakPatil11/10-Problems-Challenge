using System;
using System.IO;
using TaskFileMerger.EnumHolder;
using TaskFileMerger.FileHandler;
using TaskFileMerger.Helper;

namespace TaskFileMerger.Execution
{
    /// <summary>
    /// Class ExecutionManager for managing the execution of the program.
    /// </summary>
    internal class ExecutionManager
    {
        #region Private Methods
        
        private static bool ExecuteChoice(FileOpretionChoice Opretion, string[] strReadFiles, string strWriteFile)
        {
            switch (Opretion)
            {
                case FileOpretionChoice.Append:
                    FileMerger.Merge(strReadFiles, strWriteFile, FileMode.Append);
                    break;

                case FileOpretionChoice.Create:
                    FileMerger.Merge(strReadFiles, strWriteFile, FileMode.Create, true);
                    break;

                case FileOpretionChoice.Override:
                    FileMerger.Merge(strReadFiles, strWriteFile, FileMode.Truncate);
                    break;

                case FileOpretionChoice.Cancle:
                    return true;
            }
            return false;
        }
        
        #endregion

        #region Public Methods

        /// <summary>
        /// Method Execute for executing the execution flow.
        /// </summary>
        /// <param name="strReadFolder"> To take the read folder path. </param>
        /// <param name="strWriteFolder"> To take the write folder path. </param>
        public static void Execute(string strReadFolder, string strWriteFolder)
        {
            if (Directory.Exists(strReadFolder) && Directory.Exists(strWriteFolder))
            {
                string[] strReadFiles = Directory.GetFiles(strReadFolder);
                string[] strWriteFiles = Directory.GetFiles(strWriteFolder);

                string strWriteFile = "E:\\C#-sathak\\OP folder\\DataMerged.txt";                            //Temp
                
                Console.WriteLine(strWriteFiles.Length);

                if (strWriteFiles.Length > 0 && File.Exists($"{strReadFolder}{Constants.MSG_OUTPUT_FILE_NAME}"))
                {
                    //To get the choice.
                    FileOpretionChoice Opretion = InputHelper.ReadEnum(Constants.MSG_MAIN_CHOICE);
                    Display.ShowMessage(Constants.MSG_SEPARATOR);

                    if(ExecuteChoice(Opretion, strReadFiles, strWriteFile))
                    {
                        return;
                    }
                }
                else
                {
                    FileMerger.Merge(strReadFiles, strWriteFile, FileMode.Create);
                }
            }

            Console.ReadKey();
        }

        #endregion
    }
}
