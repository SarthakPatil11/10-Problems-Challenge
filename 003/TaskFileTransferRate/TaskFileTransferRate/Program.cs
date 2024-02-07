using System;
using TaskFileTransferRate.FileTranserRate;
using TaskFileTransferRate.Helper;

namespace TaskFileTransferRate
{
    internal class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.Clear();
                //To take the choice of shape form the user.
                int nSize = 0, nChoice;
                float fTotalSec = 0;
                nChoice = InputHelper.ReadInt(Constants.MAIN_CHOICE);

                if (nChoice != 5)
                {
                    nSize = InputHelper.ReadInt(Constants.FILE_SIZE);
                }

                switch (nChoice)
                {
                    case 1:
                        fTotalSec = FileSizes.GetTimeForB(nSize);
                        break;
                    case 2:
                        fTotalSec = FileSizes.GetTimeForKB(nSize);
                        break;
                    case 3:
                        fTotalSec = FileSizes.GetTimeForMB(nSize);
                        break;
                    case 4:
                        fTotalSec = FileSizes.GetTimeForGB(nSize);
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine(Constants.WRONG_CHOICE);
                        break;
                }

                if(nChoice < 4 && nChoice > 0)
                {
                    Console.WriteLine(TransferTime.GetTime(fTotalSec));
                }

                Console.WriteLine(Constants.CONTINUE);
                Console.ReadKey();
            }
        }
    }
}