using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace WpfApp3
{
    class OtborDB : AccBase
    {
        public static int MainOtbor()
        {
            List<string[]> arr = new List<string[]>();
            string outText = "term;dep\n";
            foreach (var dep in selectedItems)
            {
                string term = dep + "1";
                outLine = term + ";" + dep;
                arr.Add(outLine.Split(';'));

                infoBig += outLine + " ";
                outText += outLine + "\n";
            }
            TextToFile(Path.Combine(dataInPath, "otbor.csv"), outText);

            AccessAddOtbor(arr);
            AccGetVsyo();
            Vsyo vsyo = new Vsyo();
            vsyo.MainVsyo();
            
            return 0;
        }
            
    }
}
