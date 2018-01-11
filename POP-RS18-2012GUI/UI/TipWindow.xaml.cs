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
    /// Interaction logic for TipWindow.xaml
    /// </summary>
    public partial class TipWindow : Window
    {
        public enum Operacija
        {
            DODAVANJE,
            IZMENA
        };

        private TipNamestaja tipNamestaja;
        private Operacija operacija;

        public TipWindow(TipNamestaja tipNamestaja, Operacija operacija)
        {
            InitializeComponent();

            this.tipNamestaja = tipNamestaja;
            this.operacija = operacija;

            tbNazivTipa.DataContext = tipNamestaja;

        }

        private void IzadjiBtn(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void SacuvajBtn (object sender, RoutedEventArgs e)
        {
            var listaTipNamestaj = Projekat.Instance.TipNamestaja;

            switch (operacija)
            {
                case Operacija.DODAVANJE:
                    tipNamestaja.Id = listaTipNamestaj.Count + 1;
                    foreach (var tn in listaTipNamestaj)
                    {
                        if (tn.Naziv == tipNamestaja.Naziv)
                        {
                            MessageBox.Show($"Uneti tip vec { tipNamestaja.Naziv } postoji u sistemu. Odaberite drugi.");
                            tipNamestaja.Obrisan = true;
                            break;
                        }
                    }
                    //listaTipNamestaj.Add(tipNamestaja);
                    TipNamestaja.Create(tipNamestaja);
                    break;

                case Operacija.IZMENA:
                    foreach (var tn in listaTipNamestaj)
                    {
                        if (tn.Id == tipNamestaja.Id)
                        {
                            TipNamestaja.Update(tipNamestaja);
                            break;
                        }
                    }
                    break;

            }
            GenericSerializer.Serialize("tipoviNamestaja.xml", listaTipNamestaj);
            

            this.Close();

        }
    }
}
