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

namespace konyvek
{
    public partial class MainWindow : Window
    {

        List<Konyv> konyvek = new List<Konyv>();
        List<Olvaso> olvasok = new List<Olvaso>();
        List<Kolcsonzes> kolcsonzesek = new List<Kolcsonzes>();
        List<int> könyvIDk = new List<int>();
        public MainWindow()
        {
            InitializeComponent();
            DataGridXAML.DataContext = konyvek;
            DataGridOlvaso.DataContext = olvasok;
            DataGridKolcsonzesek.DataContext = kolcsonzesek;
            foreach (var item in File.ReadAllLines("konyvek.txt"))
            {
                konyvek.Add(new Konyv(item));
            }
            DataGridXAML.ItemsSource = konyvek;

            foreach (var item in File.ReadAllLines("olvasok.txt"))
            {
                olvasok.Add(new Olvaso(item));
            }
            DataGridOlvaso.ItemsSource = olvasok;

            foreach (var item in File.ReadAllLines("kolcsonzesek.txt"))
            {
                kolcsonzesek.Add(new Kolcsonzes(item));
            }
            DataGridKolcsonzesek.ItemsSource = kolcsonzesek;
            foreach (var item in konyvek)
            {
                könyvIDk.Add(item.id);
            }

        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DataGridOlvaso.Visibility = Visibility.Visible;
            DataGridXAML.Visibility = Visibility.Hidden;
            DataGridKolcsonzesek.Visibility = Visibility.Hidden;
            cimke1.Content = "Olvasójegy száma";
            cimke2.Content = "Név";
            cimke3.Content = "Születési dátum";
            cimke4.Content = "Irányítószám";
            cimke5.Content = "Település";
            cimke6.Content = "Utca, házszám";
            ujID.Text = " ";
            ujSzerzo.Text = " ";
            ujCim.Text = " ";
            ujEv.Text = " ";
            ujKiado.Text = " ";
            ujUtcaHsz.Text = " ";
            ujUtcaHsz.Visibility = Visibility.Visible;
            ujElerhetoseg.Visibility = Visibility.Visible;
            ujOlvasoGomb.Visibility = Visibility.Visible;

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        { 
            DataGridXAML.Visibility = Visibility.Visible;
            DataGridOlvaso.Visibility = Visibility.Hidden;
            DataGridKolcsonzesek.Visibility = Visibility.Hidden;
            cimke1.Content = "Azonosító";
            cimke2.Content = "Szerző";
            cimke3.Content = "Cím";
            cimke4.Content = "Kiadás éve";
            cimke5.Content = "Kiadó";
            cimke6.Content = "Elérhetőség";
            ujID.Text = " ";
            ujSzerzo.Text = " ";
            ujCim.Text = " ";
            ujEv.Text = " ";
            ujKiado.Text = " ";
            ujElerhetoseg.IsChecked = false;
            ujElerhetoseg.Visibility = Visibility.Visible;
            ujUtcaHsz.Visibility = Visibility.Hidden;
            ujKonyvGomb.Visibility = Visibility.Visible;
            ujOlvasoGomb.Visibility = Visibility.Visible;
        }
            private void Button_Click_3(object sender, RoutedEventArgs e)
            {
            DataGridKolcsonzesek.Visibility = Visibility.Visible;
            DataGridXAML.Visibility = Visibility.Hidden;
            DataGridOlvaso.Visibility = Visibility.Hidden;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string bevitelElerhetoseg;
            if (ujElerhetoseg.IsChecked==true)
            {
                bevitelElerhetoseg = "true";
            }
            else
            {
                bevitelElerhetoseg = "false";
            }
            int bevitelID = konyvek.ToList().FindIndex(x => x.id ==ujID.Text);

            string ujKonyv=$"\n{ujID.Text};{ujSzerzo.Text};{ujCim.Text};{ujEv.Text};{ujKiado.Text};{bevitelElerhetoseg}";

            if (bevitelID==-1)
            {
                konyvek.Add(new Konyv(ujKonyv));
            }
            else
            {
                konyvek[bevitelID] = new Konyv(ujKonyv);
            }
        }
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            int bevitelID = olvasok.ToList().FindIndex(x => x.olvasoID == ujID.Text);
            string ujolvaso = $"\n{ujID.Text};{ujSzerzo.Text};{ujCim.Text};{ujEv.Text};{ujKiado.Text};{ujUtcaHsz.Text}";
            if (bevitelID == -1)
            {
                olvasok.Add(new Olvaso(ujolvaso));
            }
            else
            {
                olvasok[bevitelID] = new Olvaso(ujolvaso);
            }
        }

        private void torles_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult mbr = MessageBox.Show("Ezzel a kijelölt könyv törölve lesz. ", "Figyelem!", MessageBoxButton.OKCancel, MessageBoxImage.Exclamation);
            if (mbr == MessageBoxResult.OK)
            {
                foreach (var item in Konyv.SelectedItems)
                {
                    konyvek.Remove((Konyv)item);
                }
                id.Clear();
                foreach (var item in konyvek)
                {
                    könyvIDk.Add(item.id);
                }
            }
        }
    }
    }


