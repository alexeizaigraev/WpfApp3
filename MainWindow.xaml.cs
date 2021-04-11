using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            List<string> deps = AccBase.AccGetListDeps();
            listBox1.ItemsSource = deps;

            List<string> partners = AccBase.AccSelectDistictPartners();
            listBoxPartners.ItemsSource = partners;

            List<string> someList = new List<string> { "site", "term", "natasha" };
            listBoxSome.ItemsSource = someList;

            List<string> peopleList = new List<string> { "priem", "otpusk", "perevod", "postall" };
            listBoxPeople.ItemsSource = peopleList;

            List<string> monitorList = new List<string> { "accback", "monitor", "rasklad" };
            listBoxMonitor.ItemsSource = monitorList;

            List<string> kabinetList = new List<string> { "knigi", "rro", "pereezd", "otmena" };
            listBoxKabinet.ItemsSource = kabinetList;
        }

        private void ClearMe()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            Papa.infoSmall = "";
            Papa.infoBig = "";
        }

        private void ButtonOtborListDep_Click(object sender, RoutedEventArgs e)
        {
            ClearMe();
            Papa.selectedItems = new List<string>();
            var deps = listBox1.SelectedItems;
            foreach(var item in deps)
            {
                var dep = item.ToString();
                Papa.selectedItems.Add(dep);
                textBox1.Text += dep + " ";
            }
            AccBase.ClearOtbor();
            //AccBase.AccessAddOtbor(Papa.selectedItems);
            OtborDB.MainOtbor();
            //Papa.selectedItems = new List<string>();
            textBox1.Text = Papa.infoSmall;
            textBox2.Text = Papa.infoBig;
            listBox1.SelectedItems.Clear();
        }

        private void ButtonPartner_Click(object sender, RoutedEventArgs e)
        {
            ClearMe();
            Papa.partnerChoised = listBoxPartners.SelectedItem.ToString();
            textBox1.Text = Papa.partnerChoised;
            HrDeps.MainHrDeps();
            textBox1.Text = Papa.infoSmall;
            textBox2.Text = Papa.infoBig;
        }

        private void ButtonSome_Click(object sender, RoutedEventArgs e)
        {
            ClearMe();
            string choise = listBoxSome.SelectedItem.ToString();
            switch (choise)
            {
                case "site":
                    try
                    {
                        int x = SiteNew.MainSite();
                        textBox1.Text = Papa.infoSmall;
                        textBox2.Text = Papa.infoBig;
                    }
                    catch { textBox2.Text = "Error"; }
                    break;

                case "term":
                    try
                    {
                        int x = Term.MainTerm();
                        textBox1.Text = Papa.infoSmall;
                        textBox2.Text = Papa.infoBig;
                    }
                    catch { textBox2.Text = "Error"; }
                    break;

                case "natasha":
                    try
                    {
                        int x = Natasha.MainNatasha();
                        textBox1.Text = Papa.infoSmall;
                        textBox2.Text = Papa.infoBig;
                    }
                    catch { textBox2.Text = "Error"; }
                    break;
            }
        }

        private void ButtonPeople_Click(object sender, RoutedEventArgs e)
        {
            ClearMe();
            string choise = listBoxPeople.SelectedItem.ToString();
            switch (choise)
            {
                case "priem":
                    try
                    {
                        int x = Priem.MainPriem();
                        textBox1.Text = Papa.infoSmall;
                        textBox2.Text = Papa.infoBig;
                    }
                    catch { textBox2.Text = "Error"; }
                    break;

                case "otpusk":
                    try
                    {
                        int x = Otpusk.MainOtpusk();
                        textBox1.Text = Papa.infoSmall;
                        textBox2.Text = Papa.infoBig;
                    }
                    catch { textBox2.Text = "Error"; }
                    break;

                case "perevod":
                    try
                    {
                        int x = Perevod.MainPerevod();
                        textBox1.Text = Papa.infoSmall;
                        textBox2.Text = Papa.infoBig;
                    }
                    catch { textBox2.Text = "Error"; }
                    break;

                case "postall":
                    try
                    {
                        int x = PostAll.MainPostAll();
                        textBox1.Text = Papa.infoSmall;
                        textBox2.Text = Papa.infoBig;
                    }
                    catch { textBox2.Text = "Error"; }
                    break;
            }

        }

        private void ButtonMonitor_Click(object sender, RoutedEventArgs e)
        {
            ClearMe();
            string choise = listBoxMonitor.SelectedItem.ToString();
            switch (choise)
            {
                case "accback":
                    try
                    {
                        int x = AccBack.MainAccBack();
                        textBox1.Text = Papa.infoSmall;
                        textBox2.Text = Papa.infoBig;
                    }
                    catch { textBox2.Text = "Error"; }
                    break;

                case "monitor":
                    try
                    {
                        int x = Monitor.MainMonitor();
                        textBox1.Text = Papa.infoSmall;
                        textBox2.Text = Papa.infoBig;
                    }
                    catch { textBox2.Text = "Error"; }
                    break;

                case "rasklad":
                    try
                    {
                        int x = Rasklad.MainRasklad();
                        textBox1.Text = Papa.infoSmall;
                        textBox2.Text = Papa.infoBig;
                    }
                    catch { textBox2.Text = "Error"; }
                    break;
            }
        }

        private void ButtonKabinet_Click(object sender, RoutedEventArgs e)
        {
            ClearMe();
            string choise = listBoxKabinet.SelectedItem.ToString();
            switch (choise)
            {
                case "knigi":
                    try
                    {
                        int x = Knigi.MainKnigi();
                        textBox1.Text = Papa.infoSmall;
                        textBox2.Text = Papa.infoBig;
                    }
                    catch { textBox2.Text = "Error"; }
                    break;

                case "rro":
                    try
                    {
                        int x = Rro.MainRro();
                        textBox1.Text = Papa.infoSmall;
                        textBox2.Text = Papa.infoBig;
                    }
                    catch { textBox2.Text = "Error"; }
                    break;

                case "pereezd":
                    try
                    {
                        int x = Pereezd.MainPereezd();
                        textBox1.Text = Papa.infoSmall;
                        textBox2.Text = Papa.infoBig;
                    }
                    catch { textBox2.Text = "Error"; }
                    break;

                case "otmena":
                    try
                    {
                        int x = Otmena.MainOtmena();
                        textBox1.Text = Papa.infoSmall;
                        textBox2.Text = Papa.infoBig;
                    }
                    catch { textBox2.Text = "Error"; }
                    break;
            }
        }
    }
}
