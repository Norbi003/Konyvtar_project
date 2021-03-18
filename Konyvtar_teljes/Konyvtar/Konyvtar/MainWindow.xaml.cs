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
using System.IO;

namespace Konyvtar
{
    public partial class MainWindow : Window
    {
        List<Adatok> A = new List<Adatok>();
        List<Adatok2> A2 = new List<Adatok2>();
        List<Adatok3> A3 = new List<Adatok3>();
        public MainWindow()
        {
            InitializeComponent();
        }

        class Adatok
        {
            public int ID { get; set; }
            public string szerzo { get; set; }
            public string cim { get; set; }
            public string ev { get; set; }
            public string kiado { get; set; }
            public Adatok(string sor)
            {
                string[] resz = sor.Split(';');
                ID = Convert.ToInt32(resz[0]);
                szerzo = resz[1];
                cim = resz[2];
                ev = resz[3];
                kiado = resz[4];
            }
        }

        class Adatok2
        {
            public int olvasoazonosito { get; set; }
            public string nev { get; set; }
            public DateTime szuletesiev { get; set; }
            public int szam { get; set; }
            public string lakhely { get; set; }
            public Adatok2(string sor)
            {
                string[] resz = sor.Split(';');
                olvasoazonosito = Convert.ToInt32(resz[0]);
                nev = resz[1];
                szuletesiev = Convert.ToDateTime(resz[2]);
                szam = Convert.ToInt32(resz[3]);
                lakhely = resz[4];
            }
        }

        class Adatok3
        {
            public int kolcsonazonosito { get; set; }
            public int olvasoazonosito { get; set; }
            public int konyvazonosito { get; set; }
            public DateTime kiadasdatuma { get; set; }
            public DateTime visszahozasdatuma { get; set; }
            public Adatok3(string sor)
            {
                string[] resz = sor.Split(';');
                kolcsonazonosito = Convert.ToInt32(resz[0]);
                olvasoazonosito = Convert.ToInt32(resz[1]);
                konyvazonosito = Convert.ToInt32(resz[2]);
                kiadasdatuma = Convert.ToDateTime(resz[3]);           
            }
        }

        private void Konyvek_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var item in File.ReadAllLines("konyvek.txt"))
            {
                A.Add(new Adatok(item));
            }
            Konyv.ItemsSource = A;
            Konyv.AutoGenerateColumns = false;
        }

        private void Tagok_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var item in File.ReadAllLines("tagok.txt"))
            {
                A2.Add(new Adatok2(item));
            }
            Tag.ItemsSource = A2;
            Tag.AutoGenerateColumns = false;
        }

        private void Kolcson_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var item in File.ReadAllLines("kolcsonzesek.txt"))
            {
                A3.Add(new Adatok3(item));
            }
            Kiadott.ItemsSource = A3;
            Kiadott.AutoGenerateColumns = false;
        }
    }   
}
