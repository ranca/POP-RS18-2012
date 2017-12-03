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

    public partial class AkcijeWindow : Window
    {
        ICollectionView ICView;

        public Akcija izabranaAkcija { get; set; }


        public AkcijeWindow()
        {
            InitializeComponent();

            ICView = CollectionViewSource.GetDefaultView(Projekat.Instance.Akcija);
            ICView.Filter = ViewFilter;

            dgAkcije.IsSynchronizedWithCurrentItem = true;
            dgAkcije.DataContext = this;
            dgAkcije.ItemsSource = ICView;
        }

        private bool ViewFilter(object obj)
        {
            return ((Akcija)obj).Obrisan == false;
        }

        private void DodajButton_Click(object sender, RoutedEventArgs e)
        {
            var novaAkcijaNamestaja = new Akcija();
            {
            };
            var diaw = new DodavanjaIzmenaAkcijeWindow(novaAkcijaNamestaja, DodavanjaIzmenaAkcijeWindow.Operacija.DODAVANJE);
            diaw.ShowDialog();
        }

        private void IzmeniButton_Click(object sender, RoutedEventArgs e)
        {
            Akcija kopija = (Akcija)izabranaAkcija.Clone();
            var diaw = new DodavanjaIzmenaAkcijeWindow(izabranaAkcija, DodavanjaIzmenaAkcijeWindow.Operacija.IZMENA);
            if (diaw.ShowDialog() != true)
            {
                int index = Projekat.Instance.Akcija.IndexOf(izabranaAkcija);
                Projekat.Instance.Akcija[index] = kopija;
            }
        }

        private void ObrisiButton_Click(object sender, RoutedEventArgs e)
        {
            var listaAkcija = Projekat.Instance.Akcija;
            if (MessageBox.Show($"Da li zelite da izbrisete: {izabranaAkcija}", "Brisanje", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (var a in listaAkcija)
                {
                    if (a.Id == izabranaAkcija.Id)
                    {
                        a.Obrisan = true;
                        ICView.Refresh();
                        break;
                    }
                }
                GenericSerializer.Serialize("akcija.xml", listaAkcija);
            }
        }
    
        private void IzadjiButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
