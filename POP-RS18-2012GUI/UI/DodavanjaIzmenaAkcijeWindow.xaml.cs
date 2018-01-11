using POP_RS18_2012GUI.Model;
using POP_RS18_2012GUI.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private ObservableCollection<Namestaj> ListaIzabranogNamestaja = new ObservableCollection<Namestaj>();
        public Namestaj izabranNamestaj { get; set; }

        public DodavanjaIzmenaAkcijeWindow(Akcija akcija, Operacija operacija)
        {
            InitializeComponent();

            this.akcija = akcija;
            this.operacija = operacija;

            var savNamestaj = CollectionViewSource.GetDefaultView(Projekat.Instance.Namestaj);



            dpDatumPocetka.DataContext = akcija;
            dpDatumZavrsetka.DataContext = akcija;

            dgNamestaj.IsSynchronizedWithCurrentItem = true;
            tbPopust.DataContext = akcija;
            dgNamestaj.ItemsSource = savNamestaj;
            

            ListaIzabranogNamestaja = akcija.NamestajNaPopustu;

            dgIzabranNamestaj.ItemsSource = ListaIzabranogNamestaja;
            dgIzabranNamestaj.IsSynchronizedWithCurrentItem = true;

        }

        private void SacuvajBtn(object sender, RoutedEventArgs e)
        {
            var listaAkcijaNamestaja = Projekat.Instance.Akcija;
            this.DialogResult = true;

            double cenaNamestaja = 0;
            for (int i = 0; i < akcija.NamestajNaPopustu.Count; i++)
            {
                cenaNamestaja += akcija.NamestajNaPopustu[i].Cena;
            }

            switch (operacija)
            {
                case Operacija.DODAVANJE:
                    akcija.Id = listaAkcijaNamestaja.Count + 1;
                    var tbCena = double.Parse(tbPopust.Text);
                    if (tbCena == 0)
                    {
                        MessageBox.Show("Polje za popust mora biti popunjeno!", "Greska", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                    for (int i = 0; i < akcija.NamestajNaPopustu.Count; i++)
                    {
                        akcija.NamestajNaPopustu[i].PopustCena = cenaNamestaja - ((cenaNamestaja * akcija.Popust) / 100);
                        foreach (var namestaj in Projekat.Instance.Namestaj)
                        {
                            if (namestaj.Id == akcija.NamestajNaPopustu[i].Id)
                            {
                                namestaj.PopustCena = namestaj.Cena - ((namestaj.Cena * akcija.Popust) / 100);
                            }
                        }
                    }
                    Akcija.Create(akcija);
                    break;

                case Operacija.IZMENA:
                    foreach (var a in listaAkcijaNamestaja)
                    {
                        if (a.Id == akcija.Id)
                        {
                            a.DatumPocetka = akcija.DatumPocetka;
                            a.DatumZavrsetka = akcija.DatumZavrsetka;
                            a.Popust = akcija.Popust;                           
                            Akcija.Update(akcija, false);

                            foreach (Namestaj namestaj in akcija.NamestajNaPopustu) {
                                namestaj.AkcijaId = akcija.Id;
                                Namestaj.Update(namestaj);
                            }
                            break;
                        }
                    }
                    break;
            }
            
            
        }

        private void IzadjiBtn(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void UbaciBtn(object sender, RoutedEventArgs e)
        {
            foreach (Namestaj izabranNamestaj in dgNamestaj.SelectedItems)
            {
                if (izabranNamestaj != null && !ListaIzabranogNamestaja.Contains(izabranNamestaj))
                {
                    ListaIzabranogNamestaja.Add(izabranNamestaj);
                }
            }
        }

        private void IzbaciBtn(object sender, RoutedEventArgs e)
        {

            int brojSelektovanih = dgIzabranNamestaj.SelectedItems.Count;
            for (int i = 0; i < brojSelektovanih; i++)
            {
                ListaIzabranogNamestaja.Remove((Namestaj)dgIzabranNamestaj.SelectedItems[0]);
            }
        }
    }
}
