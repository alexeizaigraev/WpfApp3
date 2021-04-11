using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3
{
    class Perevod : PeoplePapa
    {
        public static int MainPerevod()
        {
            outLine = "";
            outText = "";
            loginOk = false;

            colFioOne = 0;
            colFioTwo = 2;
            colLoginTwo = 0;
            colDepTwo = 3;
            colDepOne = 1;

            myKassAll = mkKassAllShort();

            string fOutName = "OutPerevod.csv";
            string[] lines = FileToVec(dataInPath + "perevod.csv");
            if (exitStatus) goto LabelExit;

            string unfind = "";

            foreach (string line in lines)
            {
                workVec = line.Split(';');
                List<string> myLogin = LoginSearch(MkDepartment());

                if (!loginOk)
                {
                    unfind += workVec[0] + "\t" + workVec[1] + " -> " + workVec[2] + "\n";
                    continue;
                }
                else
                {
                    foreach (var item in myLogin)
                    {
                        outText += item + "\t" + workVec[1] + " -> " + workVec[2] + "\n";
                    }
                }
            }

            TextToFile(dataOutPath + fOutName, unfind + outText);
            if (exitStatus) goto LabelExit;
            //OpenNote(dataOutPath + fOutName);
            infoBig = outText;
            if (exitStatus) goto LabelExit;

            if (unfind != "") infoSmall = "unfind " + infoSmall;
            else infoSmall = "well " + infoSmall;

            return 0;

        LabelExit:
            return 1;
        }

    }
}
