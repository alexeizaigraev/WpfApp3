using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3
{
    class SomePapa : AccBase
    {
        /*
        protected static string MenuColKeyHash(Dictionary<string, Dictionary<string, string>> hh, string myKey)
        {
            Console.Clear();
            Console.WriteLine();

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
            List<string> optionList = new List<string>();

            foreach (string point in options.Keys)
            {
                if (point != "") { optionList.Add(point); }
            }

            int count = -1;
            foreach (string option in optionList)
            {
                count++;
                string fString = String.Format("\t{0} {1}", count, option);
                pGreen(fString);
            }

            pBlue("\n\n\t-> ");

            int choise = Convert.ToInt32(Console.ReadLine());
            string rez = "";
            try { rez = optionList[choise]; }
            catch { Sos("Bed Choise", "MenuColKey"); }
            Console.Clear();

            return rez;
        }

        protected static string MenuColKey(List<List<string>> data, int keyColNum)
        {
            Console.Clear();
            Console.WriteLine();

            Dictionary<string, string> options = new Dictionary<string, string>();

            foreach (var line in data)
            {
                try
                {
                    var key = line[keyColNum];
                    options[key] = "";
                }
                catch { }
            }
            List<string> optionList = new List<string>();

            foreach (string point in options.Keys)
            {
                if (point != "") { optionList.Add(point); }
            }

            int count = -1;
            foreach (string option in optionList)
            {
                count++;
                string fString = String.Format("\t{0} {1}", count, option);
                pGreen(fString);
            }

            pBlue("\n\n\t-> ");

            int choise = Convert.ToInt32(Console.ReadLine());
            string rez = "";
            try { rez = optionList[choise]; }
            catch { Sos("Bed Choise", "MenuColKey"); }
            Console.Clear();

            return rez;
        }
        */

    }
}
