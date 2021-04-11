using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace WpfApp3
{
    class SiteNew : AccBase
    {
        private static List<string> natasha = MkNatasha();

        public static int MainSite()
        {
            var data = AccGetSiteData();
            string outFileName = dataOutPath + "OutSite.csv";
            string outFileNamePhp = dataOutPath + "page-departments.php";

            Dictionary<string, string> regimes = FileToDict(4);

            var access = data;

            string header = "Найменування відокремленного підрозділу та ПНФП;Адреса;Дата та номер рішення про створення;ЄДРПОУ;Режим роботи;Платежі приймаються в Платіжній системі;Платежі виплачуються  в Платіжній системі\n";
            string outTextClear = header;
            string outTextPhp = "";

            foreach (var accessLine in access)
            {
                try
                {
                    //if (accessLine[0] == "2") continue;

                    string dep = "";
                    if (accessLine[0].IndexOf("№") > -1) { dep = accessLine[0].Split('№')[1]; }
                    else { dep = accessLine[0]; }

                    string regime = "ТИМЧАСОВО НЕ ПРАЦЮЄ";
                    if ((dep.Length > 2) && (natasha.IndexOf(dep) > -1))
                    {
                        try
                        {
                            string agSign = dep.Substring(0, 3);
                            regime = regimes[agSign];
                        }
                        catch { }
                    }


                    if ("1" == accessLine[0])
                        regime = "ПН-ПТ 09:00-18:00";

                    if (accessLine[1] != "")
                    {
                        outTextPhp += "<tr><td>ВІДДІЛЕННЯ №" + accessLine[0] + @"</td><td>" + accessLine[2] + @"</td><td>" + accessLine[3] + @"</td><td>" + accessLine[1] + @"</td><td>" + regime + @"</td><td>ВПС ЕЛЕКТРУМ, ВПС FLASHPAY</td><td>ВПС ЕЛЕКТРУМ</td></tr>" + "\n";
                        outTextClear += "ВІДДІЛЕННЯ №" + accessLine[0] + ";" + accessLine[2] + ";" + accessLine[3] + ";" + accessLine[1] + ";" + regime + ";ВПС ЕЛЕКТРУМ, ВПС FLASHPAY;ВПС ЕЛЕКТРУМ\n";
                    }
                    else
                    {
                        outTextPhp += "<tr><td>ПНФП ВІДДІЛЕННЯ №" + accessLine[0] + @"</td><td>" + accessLine[2] + @"</td><td>" + accessLine[3] + @"</td><td>" + accessLine[1] + @"</td><td>" + regime + @"</td><td>ВПС ЕЛЕКТРУМ, ВПС FLASHPAY</td><td>ВПС ЕЛЕКТРУМ</td></tr>" + "\n";
                        outTextClear += "ПНФП ВІДДІЛЕННЯ №" + accessLine[0] + ";" + accessLine[2] + ";" + accessLine[3] + ";" + accessLine[1] + ";" + regime + ";ВПС ЕЛЕКТРУМ, ВПС FLASHPAY;ВПС ЕЛЕКТРУМ\n";
                    }
                }
                catch { }
            }

            var siteOld = FileToText(dataOutPath + "OutSite.csv");
            if (siteOld == outTextClear)
                infoSmall = "@ no change " + infoSmall;
                //pGreen("\n\n\tno change\n");


            string textPhp = outTextPhp;
            string text1 = FileToText("Config/SiteText1.txt");
            string text2 = FileToText("Config/SiteText2.txt");
            string fullTextPhp = text1 + textPhp + text2;
            TextToFile(outFileNamePhp, fullTextPhp);

            TextToFile(outFileName, outTextClear);

            return 0;
        }

    }
}