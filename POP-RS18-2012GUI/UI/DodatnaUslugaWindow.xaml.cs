using POP_RS18_2012.Model;
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
    /// Interaction logic for DodatnaUslugaWindow.xaml
    /// </summary>
    public partial class DodatnaUslugaWindow : Window
    {
        ICollectionView ICView;
        public DodatnaUsluga izabranaUsluga { get; set; }
        
        public DodatnaUslugaWindow()
        {
            InitializeComponent();

            ICView = CollectionViewSource.GetDefaultView(Projekat.Instance.DodatnaUsluga);
            ICView.Filter = viewFilter;

            dgDodatneUsluge.IsSynchronizedWithCurrentItem = true;
            dgDodatneUsluge.DataContext = this;
            dgDodatneUsluge.ItemsSource = ICView;
        }
        private bool viewFilter(object obj)
        {
            return ((DodatnaUsluga)obj).Obrisan == false;
        }

        private void DodajButton_Click(object sender, RoutedEventArgs e)
        {
            var novaDodatnaUsluga = new DodatnaUsluga();
            var dodatnaUslugaWindow = new DodavanjeIzmenaDodatnaUslugaWindow(novaDodatnaUsluga, DodavanjeIzmenaDodatnaUslugaWindow.Operacija.DODAVANJE);
            dodatnaUslugaWindow.ShowDialog();
        }

        private void IzmeniButton_Click(object sender, RoutedEventArgs e)
        {
            DodatnaUsluga kopija = (DodatnaUsluga)izabranaUsluga.Clone();
            var dodatnaUslugaWindow = new DodavanjeIzmenaDodatnaUslugaWindow(izabranaUsluga, DodavanjeIzmenaDodatnaUslugaWindow.Operacija.IZMENA);
            if (dodatnaUslugaWindow.ShowDialog() != true)
            {
                int index = Projekat.Instance.DodatnaUsluga.IndexOf(izabranaUsluga);
                Projekat.Instance.DodatnaUsluga[index] = kopija;
            }
        }

        private void ObrisiButton_Click(object sender, RoutedEventArgs e)
        {
            var listaDodatnihUsluga = Projekat.Instance.DodatnaUsluga;
            if (MessageBox.Show($"Da li zelite da izbrisete: {izabranaUsluga.Naziv}", "Brisanje", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (var du in listaDodatnihUsluga)
                {
                    if (du.Id == izabranaUsluga.Id)
                    {
                        du.Obrisan = true;
                        ICView.Refresh();
                        break;
                    }
                }
                GenericSerializer.Serialize("dodatnaUsluga.xml", listaDodatnihUsluga);
            }
        }

        private void IzadjiButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
