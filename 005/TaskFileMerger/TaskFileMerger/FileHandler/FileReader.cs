using System.IO;
using System.Runtime.InteropServices;
using TaskFileMerger.Helper;

namespace TaskFileMerger.FileHandler
{
    internal class FileReader
    {
        private FileStream m_objReadFileStream;

        public FileReader(string strReadFile)
        {
            m_objReadFileStream = new FileStream(strReadFile, FileMode.Open, FileAccess.Read);
        }

        public int ReadFile([In][Out] byte[] btarrBuffer)
        {
            int nReadBytes = m_objReadFileStream.Read(btarrBuffer, Constants.INT_ZERO, Constants.BUFFER_SIZE);
            return nReadBytes;
        }
    }
}
