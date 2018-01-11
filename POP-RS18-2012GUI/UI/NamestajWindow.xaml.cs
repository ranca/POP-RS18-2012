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
    /// Interaction logic for NamestajWindow.xaml
    /// </summary>
    public partial class NamestajWindow : Window
    {

        public enum Operacija
        {
            DODAVANJE,
            IZMENA
        };
        private Namestaj namestaj;
        private Operacija operacija;
        
        public NamestajWindow(Namestaj namestaj, Operacija operacija)
        {
            InitializeComponent();
            
            this.namestaj = namestaj;
            this.operacija = operacija;

            cbTipNamestaja.ItemsSource = Projekat.Instance.TipNamestaja;

            tbNaziv.DataContext = namestaj;
            tbSifra.DataContext = namestaj;
            tbCena.DataContext = namestaj;
            tbKolicina.DataContext = namestaj;


            cbTipNamestaja.DataContext = namestaj;
        }

        public NamestajWindow()
        {
        }

        private void IzadjiBtn(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SacuvajBtn(object sender, RoutedEventArgs e)
        {
            var listaNamestaja = Projekat.Instance.Namestaj;
            var izabraniTipNamestaja = (TipNamestaja)cbTipNamestaja.SelectedItem;
                      

            switch (operacija)
            {
                case Operacija.DODAVANJE:
                    namestaj.Id = listaNamestaja.Count + 1;
                    Namestaj.Create(namestaj);
                    break;

                case Operacija.IZMENA:
                    foreach (var n in listaNamestaja)
                    {
                        if (n.Id == namestaj.Id)
                        {
                            n.Naziv = namestaj.Naziv;
                            n.TipNamestaja = namestaj.TipNamestaja;
                            n.Cena = namestaj.Cena;
                            n.Sifra = namestaj.Sifra;
                            n.KolicinaUMagacinu = namestaj.KolicinaUMagacinu;
                            n.TipNamestajaId = namestaj.TipNamestajaId;
                            Namestaj.Update(namestaj);
                            break;
                        }
                    }

                    break;

            }
            //GenericSerializer.Serialize("namestaj.xml", listaNamestaja);

            this.Close();
        }



    }
}
