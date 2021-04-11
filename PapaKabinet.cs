using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3
{
    class PapaKabinet : Papa
    {
        protected static string KabinetPath()
        {
            string path = File.ReadAllLines(dataConfigPath + "ConfigKabinetPath.txt")[0];
            return path;
        }

        protected static string DateNow()
        {
            var nau = DateTime.Today;
            return nau.ToString("dd.MM.yyyy").Replace(".", "");
        }

        protected static void TextToFileCP1251(string fName, string text)
        {
            try
            {
                Encoding win1251 = Encoding.GetEncoding(1251);
                File.WriteAllText(fName, text, win1251);
                infoBig += fName + " \n";
            }
            catch { Alarm("OutFileError", fName); }
        }

    }
}
