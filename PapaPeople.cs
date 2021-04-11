using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3
{
    class PeoplePapa : Papa
    {
        protected static int colFioOne;
        protected static int colFioTwo;
        protected static int colDepOne;
        protected static int colDepTwo;
        protected static int colLoginTwo;

        protected static bool loginOk;
        protected static List<string[]> myKassAll;
        protected static string[] MkSplitname() { return workVec[colFioOne].Replace("  ", " ").Split(' '); }
        protected static string MkSurname() { return MkSplitname()[0]; }
        protected static string MkFirstName() { return MkSplitname()[1]; }

        protected static string MkLastName()
        {
            string name;
            string[] splitName = MkSplitname();
            if (splitName.Length < 3) { name = splitName[1]; }
            else { name = splitName[2]; }
            return name;
        }

        protected static string MkInitialOneDot() { return MkFirstName().Substring(0, 1) + "."; }
        protected static string MkInitialTwoDot() { return MkLastName().Substring(0, 1) + "."; }

        protected static string MkDepartment()
        {
            string dep = workVec[colDepOne];
            if (dep.IndexOf('№') > -1) { dep = dep.Replace("  ", " ").Split('№')[1].Replace(" ", ""); }
            return dep;
        }

        protected static List<string> LoginSearchDeep(string parDep, string nama)
        {
            loginOk = false;
            parDep = parDep.Substring(0, 3);
            List<string> logins = new List<string>();
            int count = 0;
            foreach (string[] kassAllLine in myKassAll)
            {
                string signDepKass = "";
                try { signDepKass = kassAllLine[colDepTwo].Substring(1, 4); }
                catch { continue; }

                if ((signDepKass.IndexOf(parDep) > -1) && (kassAllLine[colFioTwo].IndexOf(nama) > -1))
                {
                    logins.Add(kassAllLine[colLoginTwo]);
                    count += 1;
                    if (count > 1) break;
                }

            }

            if (count == 1)
            {
                loginOk = true;
                return logins;
            }

            return null;
        }


        protected static List<string> LoginSearch(string parDep)
        {
            loginOk = false;
            string nama = MkFioWhite(workVec[colFioOne]);
            List<string> logins = new List<string>();
            foreach (string[] kassAllLine in myKassAll)
            {
                if ((kassAllLine[colDepTwo].IndexOf(parDep) > -1) && (kassAllLine[colFioTwo].IndexOf(nama) > -1))
                {
                    loginOk = true;
                    logins.Add(kassAllLine[colLoginTwo]);
                }

            }
            if (loginOk)
                return logins;

            return LoginSearchDeep(parDep, nama);
        }


        protected static List<string[]> mkKassAllShort()
        {
            List<string[]> kassAll = FileToArr(dataInPath + "kass_all.csv");
            List<string[]> kassAllShort = new List<string[]>();
            foreach (string[] line in kassAll)
            {
                if ((line[1].IndexOf("true") > -1) && (line.Length > 4))
                {
                    try
                    {
                        line[colFioTwo] = MkFioWhite(line[colFioTwo]);
                        kassAllShort.Add(line);
                    }
                    catch { }


                }
            }
            return kassAllShort;
        }


        protected static string MkFioWhite(string fff)
        {
            string[] fs = fff.Split(' ');
            string surn = fs[0];
            string ps = "";
            for (int i = 1; i < fs.Length; i++)
            {
                ps += fs[i];
            }

            string white = surn;
            string other = ps;
            foreach (char cha in other)
            {
                if (char.IsLetter(cha) && char.IsUpper(cha))
                {
                    char[] c = { cha };
                    string ss = new string(c);
                    white += ss;
                }
            }
            return white;

        }

    }
}
