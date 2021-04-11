using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3
{
    class Rasklad : Papa
    {
        public static int MainRasklad()
        {
            string raskladInPath = Path.Combine(dataPath, "rasklad");
            if (exitStatus) goto LabelExit;
            string gDrivePath = FileToVec(Path.Combine(dataConfigPath, "ConfigGdrivePath.txt"))[0];
            if (exitStatus) goto LabelExit;
            string[] files = Directory.GetFiles(raskladInPath);
            foreach (string path in files)
            {
                string[] ps = path.Split('\\');
                string shortFileName = ps[ps.Length - 1];
                string folder = shortFileName.Substring(0, 7);
                string agSign = folder.Substring(0, 3);
                string oldFname = path;

                string lastFolder = Path.Combine(gDrivePath, MkLastFolder(agSign));
                if (exitStatus) goto LabelExit;
                string lastFolderWithFolder = Path.Combine(lastFolder, folder);

                bool LastFolderOk = myFolder(lastFolderWithFolder);
                if (exitStatus) goto LabelExit;

                string fullNewName = Path.Combine(lastFolderWithFolder, shortFileName);
                FileInfo fileInf = new FileInfo(fullNewName);
                if (fileInf.Exists)
                    MyDelete(fullNewName);
                if (exitStatus) goto LabelExit;

                MoveOneFile(oldFname, fullNewName);
                if (exitStatus) goto LabelExit;
            }
            return 0;

        LabelExit:
            return 1;
        }

        protected static string MkLastFolder(string agSign)
        {
            string rez = "NoData";
            string[] data = File.ReadAllLines(myDataPath);
            foreach (string dataLine in data)
            {
                string[] splitLine = dataLine.Split(';');
                string sign = splitLine[0];
                string folder = splitLine[3];
                if (agSign == sign)
                {
                    rez = folder;
                    break;
                }
            }
            if (rez == "nodata") { Sos("Not in comon_data", agSign); }
            return rez;
        }

        private static bool myFolder(string path)
        {
            bool folderOk = false;
            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(path);
                if (!dirInfo.Exists)
                    dirInfo.Create();

                folderOk = true;
            }
            catch { Sos("Не могу создать папку", path); }

            return folderOk;
        }


    }
}
