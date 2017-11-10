using POP_RS18_2012.Model;
using POP_RS18_2012GUI.Model;
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

            InicijalizujVrednosti(namestaj, operacija);
        }

        public NamestajWindow()
        {
        }

        private void InicijalizujVrednosti(Namestaj namestaj, Operacija operacija)
        {
            this.namestaj = namestaj;
            this.operacija = operacija;

            this.tbNaziv.Text = namestaj.Naziv;
        }

        private void Izadji(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //private void SacuvajIzmene(object sender, RoutedEventArgs e)
        //{
        //    var listaNamestaja = Projekat.Instance.Namestaj;

        //    switch (operacija) 
        //    {
        //        case Operacija.DODAVANJE:
        //            var noviNamestaj = new Namestaj()
        //            {
        //                Id = listaNamestaja.Count + 1,
        //                Naziv = this.tbNaziv.Text

        //            };
                    
        //            listaNamestaja.Add(noviNamestaj);
        //            break;

        //        case Operacija.IZMENA:
        //            foreach(var n in listaNamestaja)
        //            {
        //                if(n.Id == namestaj.Id)
        //                {
        //                    n.Naziv = this.tbNaziv.Text;
        //                    break;
        //                }
        //            }

        //            break;

        //    }
        //    Projekat.Instance.Namestaj = listaNamestaja;

            //this.Close();
       // }
    }
}
