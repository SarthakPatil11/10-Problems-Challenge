using System.IO;
using TaskFileMerger.Helper;

namespace TaskFileMerger.FileHandler
{
    internal class FileWriter
    {
        private FileStream m_objWriteFileStream;

        public FileWriter(string strWriteFile, FileMode WriteMode)
        {
            m_objWriteFileStream = new FileStream(strWriteFile, WriteMode, FileAccess.Write);
        }

        public void WriteFile(byte[] btarrBuffer, int nBytesRead)
        {
            m_objWriteFileStream.Write(btarrBuffer, Constants.INT_ZERO, nBytesRead);
        }
    }
}
