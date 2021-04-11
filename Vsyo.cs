using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace WpfApp3
{
    class Vsyo : AccBase
    {
        public int MainVsyo()
        {
            var otbor = FileToArr(Path.Combine(dataInPath, "otbor.csv"));
            int countLines = -1;
            List<string> otborObjects = new List<string>();
            foreach (var otborLine in otbor)
            {
                countLines++;
                if (countLines > 0) { otborObjects.Add(otborLine[0]); }
            }


            var vsyo = FileToArr(Path.Combine(dataInPath, "vsyo_zapros.csv"));
            string head = String.Join(";", vsyo[0]) + "\n";
            string outText = head;

            foreach (var vsyoLine in vsyo)
            {
                //pYellow(vsyoLine[1]);
                if (otborObjects.IndexOf(vsyoLine[1]) > -1)
                {
                    outText += String.Join(";", vsyoLine) + "\n";
                    //pGreen(vsyoLine[0]);
                }
            }

            TextToFile(Path.Combine(dataInPath, "vsyo_zapros_vnesh_otbor.csv"), outText);

            return 0;
        }

    }
}
