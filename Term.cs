using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace WpfApp3
{
    class Term : AccBase
    {
        private static int ColDataShablon1 = 5;
        private static int ColDataShablon2 = 6;
        private static int ColDataSoft = 7;
        private static int ColDataLimit = 8;

        private static string agCod = "";
        public static int MainTerm()
        {
            var data = AccGetTermData();
            outLine = "";
            outText = "";
            string outFileName = "OutTerminals.csv";

            foreach (var u in data)
            {
                string terminal = u[0];
                string idd;
                if (u[1] != "") { idd = u[1]; }
                else { idd = terminal; }

                string sity = u[2];
                string region = u[3];
                if (region == "")
                    region = sity;
                string streetType = u[4];
                string street = u[5];
                string house = u[6];

                string serial = "";
                if (u[7] != "" && u[7].IndexOf('0') > -1)
                {
                    string serial0 = u[7].Substring(2, u[7].Length - 2);
                    int startZero = -1;
                    foreach (char c in serial0)
                    {
                        if ('0' == c) { startZero += 1; }
                        else { break; }
                    }

                    serial = serial0.Substring(startZero + 1, serial0.Length - startZero - 1);

                }
                else serial = u[8];
                if (serial == "") serial = "333";

                agCod = terminal.Substring(0, 3);

                outLine = terminal + ";" +
                        idd + ";" +
                        DefAgent()["shablon1"] + ";" +
                        sity + ", " + region + ";" +
                        streetType + " " + street + ", " + house + ";" +
                        DefAgent()["shablon2"] + ";" +
                        DefAgent()["soft"] + ";" +
                        DefAgent()["limit"] + ";" +
                        serial;

                outText += outLine + "\n";
                //pBlue(outLine);

            }
            TextToFile(dataOutPath + outFileName, outText);
            infoBig = outText;
            infoSmall = outFileName;
            return 0;
        }

        private static Dictionary<string, string> DefAgent()
        {
            Dictionary<string, string> h = new Dictionary<string, string>()
            {
                { "shablon1", "" },
                { "shablon2", ""},
                { "soft", "" },
                { "limit", "" },
            };

            List<string[]> a = FileToArr(myDataPath);
            foreach (string[] vec in a)
            {
                if (vec[0].IndexOf(agCod) > -1)
                {
                    h["shablon1"] = vec[ColDataShablon1];
                    h["shablon2"] = vec[ColDataShablon2];
                    h["soft"] = vec[ColDataSoft];
                    h["limit"] = vec[ColDataLimit];
                    break;
                }
            }
            if ("shablon1" == h["shablon1"])
                Sos("Незнакомый агент", agCod);

            return h;
        }
    }
}
