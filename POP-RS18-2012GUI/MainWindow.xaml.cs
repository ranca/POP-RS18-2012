using POP_RS18_2012.Model;
using POP_RS18_2012GUI.Model;
using POP_RS18_2012GUI.UI;
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

namespace POP_RS18_2012GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {          
                InitializeComponent();

            OsveziPrikaz();
        }

        private void OsveziPrikaz()
        {
            lbNamestaj.Items.Clear();

            foreach (var namestaj in Projekat.Instance.Namestaj)
            {
                if(namestaj.Obrisan == false)
                {
                    lbNamestaj.Items.Add(namestaj);
                }

            }
        }

        private void lbNamestaj_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            var namestajProzor = new NamestajWindow();
            namestajProzor.Show();
        }

        private void DodajNamestaj(object sender, RoutedEventArgs e)
        {
            var noviNamestaj = new Namestaj()
            {
                Naziv = ""
              
            };

            var namestajProzor = new NamestajWindow(noviNamestaj, NamestajWindow.Operacija.DODAVANJE);
            namestajProzor.ShowDialog();

            OsveziPrikaz();

        }

        private void Izadji(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Izmeni(object sender, RoutedEventArgs e)
        {
            var izabraniNamestaj = (Namestaj)lbNamestaj.SelectedItem;
            var NamestajProzor = new NamestajWindow(izabraniNamestaj, NamestajWindow.Operacija.IZMENA);
            NamestajProzor.ShowDialog();

            OsveziPrikaz();

        }

        private void ObrisiDugme(object sender, RoutedEventArgs e)
        {
            var izabraniNamestaj = (Namestaj)lbNamestaj.SelectedItem;
            var listaNamestaja = Projekat.Instance.Namestaj;

            if (MessageBox.Show($"Da li zelite da obrisete: {izabraniNamestaj.Naziv }", "Brisanje", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach(var n in listaNamestaja)
                {
                    if(n.Id == izabraniNamestaj.Id)
                    {
                        n.Obrisan = true;
                    }
                }

                Projekat.Instance.Namestaj = listaNamestaja;

                OsveziPrikaz();

            }

        }
    }
}
