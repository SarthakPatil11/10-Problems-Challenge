using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFileMerger.Helper;

namespace TaskFileMerger.FileHandler
{
    internal class FileMerger
    {
        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strReadFiles"> To take the all read files. </param>
        /// <param name="strWriteFile"> To take the all write files. </param>
        /// <param name="WriteMode"> To take write mode. </param>
        /// <param name="bDeleteOld"> To take if old existed file have to delete. </param>
        //public static void Merge(string[] strReadFiles, string strWriteFile, FileMode WriteMode, bool bDeleteOld = false)
        //{
        //    if (bDeleteOld)
        //    {
        //        File.Delete(strWriteFile);
        //    }


        //    using (FileStream objWriteFileStream = new FileStream(strWriteFile, WriteMode, FileAccess.Write))
        //    {
        //        foreach (string strReadFile in strReadFiles)
        //        {
        //            using (FileStream objReadFileStream = new FileStream(strReadFile, FileMode.Open, FileAccess.Read))
        //            {
        //                byte[] btarrBuffer = new byte[Constants.BUFFER_SIZE];
        //                int nStart = Constants.INT_ZERO, nBytesRead;
        //                while ((nBytesRead = objReadFileStream.Read(btarrBuffer, nStart, Constants.BUFFER_SIZE)) > Constants.INT_ZERO)
        //                {
        //                    objWriteFileStream.Write(btarrBuffer, nStart, nBytesRead);
        //                }
        //            }
        //            Console.WriteLine($"{strReadFile}{Constants.MSG_STATUS_COMPLETE}");
        //        }
        //    }
        //}

        public static void Merge(string[] strReadFiles, string strWriteFile, FileMode WriteMode, bool bDeleteOld = false)
        {
            Display.ShowHeader("MERGING STARTED", Constants.MSG_DOUBLE_SEPARATOR);
            if (bDeleteOld)
            {
                File.Delete(strWriteFile);
            }

            FileWriter objWriteFileStream = new FileWriter(strWriteFile, WriteMode);
            foreach (string strReadFile in strReadFiles)
            {
                FileReader objReadFileStream = new FileReader(strReadFile);
                byte[] btarrBuffer = new byte[Constants.BUFFER_SIZE];
                int nBytesRead;
                while ((nBytesRead = objReadFileStream.ReadFile(btarrBuffer)) > Constants.INT_ZERO)
                {
                    objWriteFileStream.WriteFile(btarrBuffer, nBytesRead);
                }
                Display.ShowMessage($"{strReadFile}{Constants.MSG_STATUS_COMPLETE}");
            }
            Display.ShowHeader("MERGING COMPLETED", Constants.MSG_DOUBLE_SEPARATOR);
        }

        #endregion
    }
}
