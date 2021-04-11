using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3
{
    partial class Papa
    {
        internal static List<string> selectedItems;
        internal static string partnerChoised;
        internal static string infoSmall = "";
        internal static string infoBig = "";
        internal static bool exitStatus = false;

        protected static string dataPath = DataPath();
        protected static string dataConfigPath = dataPath + "Config\\";

        protected static string dataConfigDirPath = DataPath() + "ConfigDir\\";
        protected static string dataInPath = DataPath() + "InData\\";
        protected static string dataOutPath = DataPath() + "OutData\\";

        protected static string kabinetPath = FileToVec(dataConfigPath + "ConfigKabinetPath.txt")[0];

        protected static string myDataPath = dataConfigPath + "comon_data.csv";

        protected static string outLine = "";
        protected static string outText = "";
        protected static string header = "";

        protected static string[] workVec;

        protected static void Sos(string error, string fact)
        {
            infoSmall += error + " ";
            infoBig += error + " " + fact + " \n";
            exitStatus = true;
        }

        protected static void Alarm(string error, string fact)
        {
            infoSmall += error + " ";
            infoBig += error + " " + fact + " \n";

        }

        protected static void OpenNote(string fileName)
        {
            try { Process.Start("notepad.exe", fileName); }
            catch { Sos("Err Open Notepad", fileName); }
        }

        protected static Dictionary<string, string> FileToDict(int colNum)
        {
            List<string[]> data = FileToArr(myDataPath);
            Dictionary<string, string> d = new Dictionary<string, string>();
            foreach (string[] line in data)
            {
                try { d[line[0]] = line[colNum]; }
                catch { Sos("Err FileToDict", line[0]); }
            }
            return d;
        }

        protected static Dictionary<string, string> VecToHash(string[] header, string[] vec)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            for (int i = 0; i < header.Length; i++)
            {
                var key = header[i];
                var val = "";
                try { val = vec[i]; }
                catch
                {
                    //Alarm("Err VecToHash", String.Format(" column {0}", i)); 
                }
                dict[key] = val;
            }
            return dict;
        }

        List<string> DictToHead(Dictionary<string, string> dict)
        {
            List<string> rez = new List<string>();
            foreach (string unit in dict.Keys)
            {
                try { rez.Add(unit); }
                catch { Sos("Err DictToHead", unit); }
            }
            return rez;
        }

        protected static Dictionary<string, Dictionary<string, string>> ArrToHash(string[] head, List<string[]> list, int keyColNum)
        {
            Dictionary<string, Dictionary<string, string>> hashTab = new Dictionary<string, Dictionary<string, string>>();
            Dictionary<string, string> hash = new Dictionary<string, string>();
            foreach (string[] line in list)
            {
                try
                {
                    hash = VecToHash(head, line);
                    string keyLine = head[keyColNum];
                    string keyArr = hash[keyLine];
                    hashTab[keyArr] = hash;
                }
                catch { Sos("Err ArrToHash", line[0]); }
            }
            return hashTab;
        }

        protected static List<string[]> SubList(List<string[]> list, int start, int finish)
        {
            List<string[]> myList = new List<string[]>();
            for (int i = start; i <= finish; i++)
            {
                try { myList.Add(list[i]); }
                catch { Sos("Err Sublist", String.Format(" row {0}", i)); }
            }
            return myList;
        }

        protected static void MyDelete(string fName)
        {
            try
            {
                File.Delete(fName);
                infoBig += "Dlelete " + fName + " \n";
            }
            catch { Sos("Ошибка удаления", fName); }
        }


        protected static void MoveOneFile(string oldName, string newName)
        {
            FileInfo fileInfo = new FileInfo(newName);
            if (fileInfo.Exists) MyDelete(newName);

            try
            {
                File.Move(oldName, newName);
                infoBig += " Move " + newName + " \n";
            }
            catch { Alarm("Err Move", newName); }
        }

        protected static void CopyOneFile(string oldName, string newName)
        {
            FileInfo fileInfo = new FileInfo(newName);
            if (fileInfo.Exists) MyDelete(newName);

            try
            {
                File.Copy(oldName, newName);
                infoBig += " Copy " + newName + "\n";
            }
            catch { Alarm("Err copy ", newName); }
        }


        protected static void Coper(string dirInCopy, string dirOutCopy)
        {
            DirectoryInfo d = new DirectoryInfo(dirInCopy);
            FileInfo[] infos = d.GetFiles("*.*");
            foreach (FileInfo f in infos)
            {
                string oldName = f.FullName;
                string newName = Path.Combine(dirOutCopy, f.Name);
                CopyOneFile(oldName, newName);
            }
        }

        protected static void Mover(string dirInMove, string dirOutMove)
        {
            DirectoryInfo d = new DirectoryInfo(dirInMove);
            FileInfo[] infos = d.GetFiles("*.*");
            foreach (FileInfo f in infos)
            {
                string oldName = f.FullName;
                string newName = Path.Combine(dirOutMove, f.Name);
                MoveOneFile(oldName, newName);
            }
        }

        protected static void Clon(string dirInClone, string dirOutClone)
        {
            DirectoryInfo d = new DirectoryInfo(dirInClone);
            FileInfo[] infos = d.GetFiles("*.*");
            foreach (FileInfo f in infos)
            {
                string oldName = f.FullName;
                string newName = Path.Combine(dirOutClone, f.Name);
                CopyOneFile(oldName, newName);
            }
        }

        protected static void ClonAccess(string dirInClone, string dirOutClone)
        {
            DirectoryInfo d = new DirectoryInfo(dirInClone);
            FileInfo[] infos = d.GetFiles("*.*");
            foreach (FileInfo f in infos)
            {
                string oldName = f.FullName;
                string newName = Path.Combine(dirOutClone, f.Name);
                CopyOneFile(oldName, newName);
            }
        }
        protected static void ClearFolder(string path)
        {
            DirectoryInfo d = new DirectoryInfo(path);
            FileInfo[] infos = d.GetFiles("*.*");
            foreach (FileInfo f in infos)
            {
                string delName = f.FullName;
                MyDelete(delName);
            }
        }

        protected static string DataPath()
        {
            string path = "";
            try { path = File.ReadAllLines(Path.Combine("Config", "ConfigDataPath.txt"))[0]; }
            catch { Sos("Err read DataPath", Path.Combine("Config", "ConfigDataPath.txt")); }
            return path;
        }

        protected static string[] FileToVec(string fName)
        {
            FileInfo fileInfo = new FileInfo(fName);
            if (!fileInfo.Exists) Sos("No File", fName);
            string[] vec = File.ReadAllLines(fName);
            return vec;
        }

        protected static void TextToFile(string fName, string text)
        {
            try
            {
                File.WriteAllText(fName, text);
                infoSmall += fName + " ";
            }
            catch { Sos("Err TextToFile", fName); }
        }

        protected static void ArrToFile(string fName, List<string[]> arr)
        {
            string text = ArrToText(arr);
            TextToFile(fName, text);

        }

        protected static string ArrToText(List<string[]> arr)
        {
            string text = "";
            foreach (string[] vec in arr)
            {
                text += String.Join(";", vec) + "\n";
            }
            return text;
        }

        protected static string FileToText(string fName)
        {
            string text = "";
            try { text = File.ReadAllText(fName); }
            catch { Sos("Err RFileToText", fName); }
            return text;
        }

        protected static List<string> MkNatasha()
        {
            var arr = FileToArr(Path.Combine(dataInPath, "natasha.csv"));
            List<string> vec = new List<string>();
            string sign = "Відділення № ";
            foreach (var line in arr)
            {
                try
                {
                    foreach (var el in line)
                    {
                        if (el.IndexOf(sign) > -1)
                        {
                            string unit;
                            unit = el.Replace(sign, "").Replace(" ", "");
                            vec.Add(unit);
                        }
                    }
                }
                catch { Sos("Err mkNatasha", "natasha.csv"); }

            }
            return vec;
        }

        protected static Dictionary<string, string> MkComonHash(int keyColNum)
        {
            Dictionary<string, string> rez = new Dictionary<string, string>();
            List<string[]> data = new List<string[]>();
            try { data = FileToArr(myDataPath); }
            catch { Sos("Err read", myDataPath); }

            try
            {
                foreach (string[] splitLine in data)
                {
                    string key = splitLine[0];
                    string unit = splitLine[keyColNum];
                    rez[key] = unit;
                }
            }
            catch { Sos("Err MkComonHash", String.Format("KeyColNum {0}", keyColNum)); }
            return rez;
        }

        protected static string DateNowLine()
        {
            var nau = DateTime.Today;
            return nau.ToString("yyyy-MM-dd").Replace(".", "");
        }



        protected static List<string[]> FileToArr(string fName)
        {
            string[] vec;
            List<string[]> arr = new List<string[]>();
            try
            {
                vec = File.ReadAllLines(fName);
                foreach (string vecLine in vec)
                {
                    string[] vecLineSplit = vecLine.Split(';');
                    arr.Add(vecLineSplit);
                }
            }
            catch { Sos("Err FileToArr", fName); }
            return arr;
        }

        protected static Dictionary<string, Dictionary<string, string>> FileToHashTab(string fName, int keyColNum)
        {
            List<string[]> arr = FileToArr(fName);
            string[] head = arr[0];
            List<string[]> list = SubList(arr, 1, arr.Count - 1);
            Dictionary<string, Dictionary<string, string>> hashTab = new Dictionary<string, Dictionary<string, string>>();

            try { hashTab = ArrToHash(head, list, keyColNum); }
            catch
            { Sos("Err FileToHashTab", fName); }
            return hashTab;
        }

        private static List<string> DictToList(Dictionary<string, string> dict)
        {
            List<string> rez = new List<string>();
            foreach (string unit in dict.Values)
            {
                rez.Add(unit);
            }
            return rez;
        }

        internal static string MkAgents()
        {
            var myKey = "partner";
            var hh = FileToHashTab(dataInPath + "vsyo_zapros.csv", 0);
            Dictionary<string, string> options = new Dictionary<string, string>();

            foreach (string keyBig in hh.Keys)
            {
                try
                {
                    Dictionary<string, string> line = new Dictionary<string, string>();
                    line = hh[keyBig];
                    string option = line[myKey];
                    options[option] = "";
                }
                catch { }
            }

            string outText = "";
            var count = 0;
            foreach (string point in options.Keys)
            {
                //if (point != "") { outText += String.Format(" {0}_{1}\n", count, point); }
                outText += String.Format(" {0}_{1}\n", count, point);
                count++;
            }

            return outText;
        }
    }
}
