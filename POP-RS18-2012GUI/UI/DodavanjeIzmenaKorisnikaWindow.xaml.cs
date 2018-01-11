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
    /// Interaction logic for DodavanjeIzmenaKorisnika.xaml
    /// </summary>
    public partial class DodavanjeIzmenaKorisnikaWindow : Window
    {
        public enum Operacija
        {
            DODAVANJE,
            IZMENA
        };

        private Korisnik korisnik;
        private Operacija operacija;

        public DodavanjeIzmenaKorisnikaWindow(Korisnik korisnik, Operacija operacija)
        {
            InitializeComponent();

            this.korisnik = korisnik;
            this.operacija = operacija;

            cbTipKorisnika.ItemsSource = Enum.GetValues(typeof(TipKorisnika)).Cast<TipKorisnika>();
            cbTipKorisnika.DataContext = korisnik;
            
            tbIme.DataContext = korisnik;
            tbPrezime.DataContext = korisnik;
            tbKorisnickoIme.DataContext = korisnik;
            tbLozinka.DataContext = korisnik;
        }

        public DodavanjeIzmenaKorisnikaWindow()
        {
        }

        private void SacuvajBtn(object sender, RoutedEventArgs e)
        {
            var listaKorisnika = Projekat.Instance.Korisnik;
           

            switch (operacija)
            {
                case Operacija.DODAVANJE:
                    korisnik.Id = listaKorisnika.Count + 1;
                    cbTipKorisnika.DataContext.ToString();
                    Korisnik.Create(korisnik);
                    break;

                case Operacija.IZMENA:
                    foreach (var k in listaKorisnika)
                    {
                        if (k.Id == korisnik.Id)
                        {
                            k.Ime = korisnik.Ime;
                            k.Prezime = korisnik.Prezime;
                            k.KorisnickoIme = korisnik.KorisnickoIme;
                            k.Lozinka = korisnik.Lozinka;
                            k.TipKorisnika = korisnik.TipKorisnika;
                            break;
                        }
                    }
                    Korisnik.Update(korisnik);
                    break;

            }
            //GenericSerializer.Serialize("korisnik.xml", listaKorisnika);

            this.Close();
        }

        private void IzadjiBtn(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
    
    
