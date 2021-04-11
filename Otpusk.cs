using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3
{
    class Otpusk : PeoplePapa
    {
        public static int MainOtpusk()
        {
            outLine = "";
            outText = "";
            loginOk = false;

            colFioOne = 0;
            colFioTwo = 2;
            colLoginTwo = 0;
            colDepTwo = 3;
            colDepOne = 3;

            myKassAll = mkKassAllShort();
            string unfind = "";

            string fOutName = "OutOtpuskUvol.csv";
            string[] lines = FileToVec(dataInPath + "otpusk_uvol.csv");
            if (exitStatus) goto LabelExit;
            foreach (string line in lines)
            {
                workVec = line.Split(';');
                List<string> myLogin = LoginSearch(MkDepartment());

                if (!loginOk)
                {
                    unfind += workVec[0] + "\t" + workVec[3] + "\t" + ";" + Dates() + "\n";
                    continue;
                }
                else
                {
                    foreach (var item in myLogin)
                    {
                        outText += item + ";" + Dates() + "\n";
                    }
                }
            }


            TextToFile(dataOutPath + fOutName, unfind + outText);
            if (exitStatus) goto LabelExit;
            infoBig = unfind + outText;

            if (unfind != "") infoSmall = "unfind " + infoSmall;
            else infoSmall = "well " + infoSmall;

            return 0;

        LabelExit:
            return 1;
        }

        private static List<string> MkGoodArr(string[] arr)
        {
            List<string> outList = new List<string>();
            foreach (string el in arr)
            {
                if (el.IndexOf('№') > -1)
                    outList.Add(el);
            }
            return outList;
        }



        static string Dates()
        {
            string datesOut;
            string status;
            if (workVec[2] == "")
            {
                status = "uvolnenie";
            }
            else
            {
                status = "otpusk";
            }

            int colStart = 1;
            int colFinish = 2;

            if (workVec[colStart].Length != 10
                || (workVec[colStart].IndexOf('.') == workVec[colStart].LastIndexOf('.')))
            {
                Sos("Ошибка в первой дате", workVec[colStart]);
            }

            if (status == "otpusk")
            {
                if (workVec[colFinish].Length != 10
                || (workVec[colFinish].IndexOf('.') == workVec[colFinish].LastIndexOf('.')))
                {
                    Sos("Ошибка во второй дате", workVec[colFinish]);
                }

                string[] dateStartOtpusk0 = workVec[colStart].Split('.');
                string dd = dateStartOtpusk0[0];
                string mm = dateStartOtpusk0[1];
                string yy = dateStartOtpusk0[2];

                string dateStartOtpusk = yy + "-"
                    + mm + "-" + dd + " "
                    + "00:00:01";

                string[] dateFinishOtpusk0 = workVec[colFinish].Split('.');
                string dd2 = dateFinishOtpusk0[0];
                string mm2 = dateFinishOtpusk0[1];
                string yy2 = dateFinishOtpusk0[2];
                string dateFinishOtpusk = yy2 + "-"
                    + mm2 + "-" + dd2 + " "
                    + "23:59:59";

                string dateActiveStart = "2020-02-02 00:00:01";
                string dateActiveFinish = "2050-02-02 00:00:01";

                datesOut = dateStartOtpusk + ";"
                    + dateFinishOtpusk + ";"
                    + "" + ";"
                    + dateActiveStart + ";"
                    + dateActiveFinish;
                return datesOut;
            }

            if (status == "uvolnenie")
            {
                if (workVec[colStart].Length != 10
                || (workVec[colStart].IndexOf('.') == workVec[colStart].LastIndexOf('.')))
                {
                    Sos("Ошибка в первой дате", workVec[colStart]);
                }

                string dateStartOtpusk = "";
                string dateFinishOtpusk = "";

                string[] dateUvol0 = workVec[colStart].Split('.');
                string dd = dateUvol0[0];
                string mm = dateUvol0[1];
                string yy = dateUvol0[2];

                string dateUvol = yy + "-" + mm + "-" + dd
                    + " " + "23:59:59";
                string dateActiveStart = "2020-02-02 00:00:01";
                string dateActiveFinish = dateUvol;

                datesOut = dateStartOtpusk + ";"
                    + dateFinishOtpusk + ";"
                    + dateUvol + ";"
                    + dateActiveStart + ";"
                    + dateActiveFinish;
                return datesOut;
            }
            return "BED_DATES";
        }

    }
}
