using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace WpfApp3
{
    class Natasha : AccBase
    {
        public static int MainNatasha()
        {
            outLine = "";
            outText = "";

            string fOutName = "OutNatasha.csv";
            var lines = MkNatasha();

            var names = MkComonHash(1);
            Dictionary<string, string> data = new Dictionary<string, string>();
            foreach (string item in lines)
            {
                try
                {
                    if ((item != "") && (item.Length > 6))
                    {
                        data[item] = "";
                    }
                }
                catch { }


            }


            SortedDictionary<string, int> myDict = new SortedDictionary<string, int>();
            foreach (string item in data.Keys)
            {
                string key = item.Substring(0, 3);
                if (myDict.ContainsKey(key))
                    myDict[key] += 1;
                else
                    myDict[key] = 1;
            }

            int sum = 0;
            foreach (var key in myDict.Keys)
            {
                sum += myDict[key];
                string name = "_";
                if (names.ContainsKey(key)) { name = names[key]; }

                outText += key + ";" + name + ";" + String.Format("{0}", myDict[key]) + "\n";
            }
            outText += "_____\n";
            outText += "sum= " + String.Format("{0}", sum) + "\n";

            //pGreen(outText);
            infoBig = outText;

            TextToFile(dataOutPath + fOutName, outText);

            string oFname = dataPath + "Количество отделений/Отделения-" + DateNowLine() + ".csv";
            /*
            pYellow("\n\t Отчёт?\t\t Да [Enter] ->");
            string choise = Console.ReadLine();
            if ("" == choise)
                TextToFile(oFname, outText);
            else
                pBlue("\tDu-Du :)");
            */
            TextToFile(oFname, outText);
            infoSmall = oFname;

            return 0;
        }

    }
}
