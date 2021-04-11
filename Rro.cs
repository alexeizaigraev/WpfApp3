using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3
{
    class Rro : PapaKabinet
    {
        public static int MainRro()
        {
            List<string[]> vsyoZapros = FileToArr(dataInPath + "vsyo_zapros_vnesh_otbor.csv");
            if (exitStatus) goto LabelExit;

            string[] head = vsyoZapros[0];
            List<string[]> data = SubList(vsyoZapros, 1, vsyoZapros.Count - 1);

            foreach (string[] dataLine in data)
            {
                Dictionary<string, string> insertData = VecToHash(head, dataLine);
                string shablon = "<?xml version=\"1.0\" encoding=\"windows-1251\" standalone=\"no\"?>" + @"
" + "<DECLAR xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xsi:noNamespaceSchemaLocation=\"J1311402.xsd\">" + @"
    <DECLARHEAD>
        <TIN>40243180</TIN>
        <C_DOC>J13</C_DOC>
        <C_DOC_SUB>114</C_DOC_SUB>
        <C_DOC_VER>2</C_DOC_VER>
        <C_DOC_TYPE>0</C_DOC_TYPE>
        <C_DOC_CNT>12</C_DOC_CNT>
        <C_REG>26</C_REG>
        <C_RAJ>50</C_RAJ>
        <PERIOD_MONTH>9</PERIOD_MONTH>
        <PERIOD_TYPE>1</PERIOD_TYPE>
        <PERIOD_YEAR>2019</PERIOD_YEAR>
        <C_STI_ORIG>2650</C_STI_ORIG>
        <C_DOC_STAN>1</C_DOC_STAN>
        " + "<LINKED_DOCS xsi:nil=\"true\"/>" + @"
        <D_FILL>04092019</D_FILL>
        <SOFTWARE>CABINET 0.4.1</SOFTWARE>
    </DECLARHEAD>
  <DECLARBODY>
<HMN>1</HMN>
<HR>1</HR>
<HKSTI>2650</HKSTI>
<HSTI>ГОЛОВНЕ УПРАВЛІННЯ ДФС У М.КИЄВІ, ДПІ У ГОЛОСІЇВСЬКОМУ РАЙОНІ (ГОЛОСІЇВСЬКИЙ РАЙОН М.КИЄВА)</HSTI>
" + "<HNAME>ТОВАРИСТВО З ОБМЕЖЕНОЮ ВIДПОВIДАЛЬНIСТЮ \"ЕЛЕКТРУМ ПЕЙМЕНТ СІСТЕМ\"</HNAME>" + @"
<HTIN>40243180</HTIN>
" + "<T3RXXXXG1S ROWNUM=\"1\">Відділення № " + insertData["Терминалы.department"] + @"</T3RXXXXG1S>
" + "<T3RXXXXG2 ROWNUM=\"1\">" + insertData["post_index"] + @"</T3RXXXXG2>
" + "<T3RXXXXG3S ROWNUM=\"1\">" + insertData["region"] + @"</T3RXXXXG3S>
" + "<T3RXXXXG4S ROWNUM=\"1\">" + insertData["district_region"] + @"</T3RXXXXG4S>
" + "<T3RXXXXG5S ROWNUM=\"1\">" + insertData["city"] + @"</T3RXXXXG5S>
" + "<T3RXXXXG6S ROWNUM=\"1\">" + insertData["street"] + @"</T3RXXXXG6S>
" + "<T3RXXXXG7S ROWNUM=\"1\">" + insertData["hous"] + @"</T3RXXXXG7S>
" + "<T3RXXXXG8S ROWNUM=\"1\" xsi:nil=\"true\"/>" + @"
" + "<T3RXXXXG9S ROWNUM=\"1\" xsi:nil=\"true\"/>" + @"
" + "<T3RXXXXG10S ROWNUM=\"1\" xsi:nil=\"true\"/>" + @"
" + "<T3RXXXXG11 ROWNUM=\"1\">" + insertData["koatu"] + @"</T3RXXXXG11>
" + "<T3RXXXXG12S ROWNUM=\"1\">" + insertData["tax_id"] + @"</T3RXXXXG12S>
" + "<T3RXXXXG13 ROWNUM=\"1\">2657</T3RXXXXG13>" + @"
" + "<T3RXXXXG13S ROWNUM=\"1\">ГУ ДФС У М.КИЄВІ (СВЯТОШИНСЬКИЙ Р-Н М.КИЄВА)</T3RXXXXG13S>" + @"
<R0401G1>458</R0401G1>
<R0401G1S>" + insertData["model"] + @"</R0401G1S>
<R0402G1S>" + insertData["serial_number"] + @"</R0402G1S>
<R0403G1>1088</R0403G1>
<R0403G1S>" + insertData["soft"] + @"</R0403G1S>
<R0404G1S>" + insertData["producer"] + @"</R0404G1S>
<R0405G1D>" + insertData["date_manufacture"].ToString().Replace(".", "").Substring(0, 8) + @"</R0405G1D>
<R0408G1S>" + insertData["rne_rro"] + @"</R0408G1S>
<R0501G1S>Торгівля. Громадське харчування. Сфера послуг.</R0501G1S>
<R0601G1S>" + insertData["oro_serial"] + @"</R0601G1S>
<R0602G1>40</R0602G1>
<R0603G1S>" + insertData["ticket_serial"] + @"</R0603G1S>
<R0604G1>100</R0604G1>
" + "<R0701G1S>ТОВ \"ПОС\"</R0701G1S>" + @"
<R0702G1S>39205324</R0702G1S>
<R0703G1S>97</R0703G1S>
<R0703G2D>01092016</R0703G2D>
<R0703G3D>31122024</R0703G3D>
<M04>1</M04>
<R0901G1S>a.kulchitskiy@elpaysys.com</R0901G1S>
<M05>1</M05>
<HKBOS>2903722436</HKBOS>
<HBOS>ПОЖАРСЬКИЙ ВЯЧЕСЛАВ ЮХИМОВИЧ</HBOS>
<HFILL>" + DateNow() + @"</HFILL>
</DECLARBODY>
</DECLAR>
";
                string ofname = kabinetPath + "rro_" + insertData["Терминалы.department"] + "_" + insertData["serial_number"] + ".xml";
                TextToFileCP1251(ofname, shablon);
            }


            return 0;

        LabelExit:
            return 1;
        }

    }
}
