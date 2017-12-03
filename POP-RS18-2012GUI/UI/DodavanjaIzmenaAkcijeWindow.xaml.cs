using POP_RS18_2012.Model;
using POP_RS18_2012GUI.Model;
using POP_RS18_2012GUI.Utils;
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
using System.Windows.Shapes;

namespace POP_RS18_2012GUI.UI
{
    /// <summary>
    /// Interaction logic for DodavanjaIzmenaAkcijeWindow.xaml
    /// </summary>
    public partial class DodavanjaIzmenaAkcijeWindow : Window
    {
        public enum Operacija
        {
            DODAVANJE,
            IZMENA
        };

        private Akcija akcija;
        private Operacija operacija;

        public DodavanjaIzmenaAkcijeWindow(Akcija akcija, Operacija operacija)
        {
            InitializeComponent();

            dpDatumPocetka.SelectedDate = DateTime.Today;
            dpDatumZavrsetka.SelectedDate = DateTime.Today;

            this.akcija = akcija;
            this.operacija = operacija;

            cbNamestajNaPopustu.ItemsSource = Projekat.Instance.Namestaj;

            dpDatumPocetka.DataContext = akcija;
            dpDatumZavrsetka.DataContext = akcija;
            cbNamestajNaPopustu.DataContext = akcija;
            tbPopust.DataContext = akcija;
        }

        private void SacuvajBtn(object sender, RoutedEventArgs e)
        {
            var listaAkcijaNamestaja = Projekat.Instance.Akcija;
            this.DialogResult = true;
            switch (operacija)
            {
                case Operacija.DODAVANJE:
                    akcija.Id = listaAkcijaNamestaja.Count + 1;
                    listaAkcijaNamestaja.Add(akcija);
                    break;
            }
            GenericSerializer.Serialize("akcija.xml", listaAkcijaNamestaja);
            
        }

        private void IzadjiBtn(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
