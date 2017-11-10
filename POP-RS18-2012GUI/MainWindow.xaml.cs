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
                lbNamestaj.Items.Add(namestaj);
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
            namestajProzor.Show();

        }

        private void Izadji(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Izmeni(object sender, RoutedEventArgs e)
        {

        }
    }
}
