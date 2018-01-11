using POP_RS18_2012GUI.Model;
using POP_RS18_2012GUI.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for KorisniciWindow.xaml
    /// </summary>
    public partial class KorisniciWindow : Window
    {

        ICollectionView ICView;

        public Korisnik IzabranKorisnik{ get; set; }
        public KorisniciWindow()
        {
            InitializeComponent();

            ICView = CollectionViewSource.GetDefaultView(Projekat.Instance.Korisnik);

            dgKorisnici.IsSynchronizedWithCurrentItem = true;
            dgKorisnici.DataContext = this;
            dgKorisnici.ItemsSource = ICView;

            IzabranKorisnik = dgKorisnici.SelectedItem as Korisnik;

            
        }

        private void DodajButton_Click(object sender, RoutedEventArgs e)
        {
            var noviKorisnik = new Korisnik();
            var dodavanjeIzmenaKorisnikaWindow = new DodavanjeIzmenaKorisnikaWindow(noviKorisnik, DodavanjeIzmenaKorisnikaWindow.Operacija.DODAVANJE);
            dodavanjeIzmenaKorisnikaWindow.ShowDialog();
        }

        private void IzmeniButton_Click(object sender, RoutedEventArgs e)
        {
            Korisnik kopija = (Korisnik)IzabranKorisnik.Clone();
            var korisniciWindow = new DodavanjeIzmenaKorisnikaWindow(IzabranKorisnik, DodavanjeIzmenaKorisnikaWindow.Operacija.IZMENA);
            if(korisniciWindow.ShowDialog() != true)
            {
                int index = Projekat.Instance.Korisnik.IndexOf(IzabranKorisnik);
                Projekat.Instance.Korisnik[index] = kopija;
            }
        }

        private void ObrisiButton_Click(object sender, RoutedEventArgs e)
        {
            var listaKorisnika = Projekat.Instance.Korisnik;
            if (MessageBox.Show($"Da li zelite da izbrisete: {IzabranKorisnik.Ime}", "Brisanje", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (var k in listaKorisnika)
                {
                    if (k.Id == IzabranKorisnik.Id)
                    {
                        Korisnik.Delete(IzabranKorisnik);
                        ICView.Refresh();
                        break;
                    }
                }
               // GenericSerializer.Serialize("korisnik.xml", listaKorisnika);
            }

        }

        private void IzadjiButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
