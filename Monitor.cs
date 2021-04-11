using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3
{
    class Monitor : Papa
    {
        public static int MainMonitor()
        {
            string[] monitorDirs = File.ReadAllLines(dataConfigDirPath + "PathMonitor.txt");
            if (exitStatus) goto LabelExit;

            string monitorOut = File.ReadAllLines(dataConfigDirPath + "PathMonitorOut.txt")[0];
            if (exitStatus) goto LabelExit;

            foreach (string dir in monitorDirs)
            {

                Console.ForegroundColor = Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(dir);
                Mover(dir, monitorOut);
            }
            return 0;

        LabelExit:
            return 1;
        }

    }
}
