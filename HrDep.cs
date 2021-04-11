using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3
{
    class HrDeps : AccBase
    {
        public static int MainHrDeps()
        {
            string myKey = "partner";
            string outText = "№ п/п;\"№ Відділення ТОВ \"\"ЕПС\"\"\";Область;Район в обл.;Індекс;Тип населеного пункту;Населений пункт;Район в місті;Тип вулиці;Адреса;Номер будинку;Дата признчення керівника;модель РРО;Заводський № РРО;2\n";
            var data = AccGetSummuryData();
            var sizeLine = data[0].Count;
            string partner = partnerChoised;

            //pCyan("\n " + partner + "\n");

            int count = 0;
            foreach (var u in data)
            {
                try
                {
                    if (u[sizeLine - 1] == partner)
                    {
                        count++;
                        string outLine = "";
                        outLine = String.Format("{0}", count) + ";"
                            + u[0] + ";"
                            + u[1] + ";"
                            + u[2] + ";"
                            + u[3] + ";"
                            + u[4] + ";"
                            + u[5] + ";"
                            + u[6] + ";"
                            + u[7] + ";"
                            + u[8] + ";"
                            + u[9] + ";"
                            + "" + ";"
                            + "" + ";"
                            + "" + ";"
                            + u[10];
                        outText += outLine + '\n';
                    }
                }
                catch { }
            }
            TextToFile(dataOutPath + "hr_new_deps.csv", outText);
            return 0;
        }

    }
}
