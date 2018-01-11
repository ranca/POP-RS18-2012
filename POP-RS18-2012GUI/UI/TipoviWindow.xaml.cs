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
    /// Interaction logic for TipoviWindow.xaml
    /// </summary>
    public partial class TipoviWindow : Window
    {

        ICollectionView ICView;

        public TipNamestaja IzabranTip { get; set; }

        public TipoviWindow()
        {
            InitializeComponent();

            ICView = CollectionViewSource.GetDefaultView(Projekat.Instance.TipNamestaja);
            ICView.Filter = ViewFilter;

            dgTipovi.IsSynchronizedWithCurrentItem = true;
            dgTipovi.DataContext = this;
            dgTipovi.ItemsSource = ICView;


        }

        private bool ViewFilter(object obj)
        {
            return ((TipNamestaja)obj).Obrisan == false;
        }

        private void DodajTipButton_Click(object sender, RoutedEventArgs e)
        {
            var noviTipNamestaja = new TipNamestaja()
            {
            };
            var tipNamestajaWindow = new TipWindow(noviTipNamestaja, TipWindow.Operacija.DODAVANJE);
            tipNamestajaWindow.ShowDialog();
        }

        private void IzmeniTipButton_Click(object sender, RoutedEventArgs e)
        {
            TipNamestaja kopija = (TipNamestaja)IzabranTip.Clone();
            var tipNamestajaWindow = new TipWindow(kopija, TipWindow.Operacija.IZMENA);
            if (tipNamestajaWindow.ShowDialog() != true)
            {
                int index = Projekat.Instance.TipNamestaja.IndexOf(IzabranTip);
                Projekat.Instance.TipNamestaja[index] = kopija;
            }
        }


        private void dgTipovi_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {

        }

        private void IzadjiButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ObrisiButton_Click(object sender, RoutedEventArgs e)
        {
            var listaTipova = Projekat.Instance.TipNamestaja;
            if(MessageBox.Show($"Da li zelite da obrisete: { IzabranTip.Naziv }", "Brisanje", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (var tip in listaTipova)
                {
                    if(tip.Id == IzabranTip.Id)
                    {
                        TipNamestaja.Delete(IzabranTip);
                        ICView.Refresh();
                        break;
                    }
                }
                GenericSerializer.Serialize("tipoviNamestaja.xml", listaTipova);
            }
        }
    }
}
