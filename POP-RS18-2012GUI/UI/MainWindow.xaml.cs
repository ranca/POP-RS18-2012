using POP_RS18_2012GUI.Model;
using POP_RS18_2012GUI.UI;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace POP_RS18_2012GUI.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ICollectionView ICView;

        public Namestaj IzabranNamestaj { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            ICView = CollectionViewSource.GetDefaultView(Projekat.Instance.Namestaj);
            ICView.Filter = ViewFilter;

            
            dgNamestaj.IsSynchronizedWithCurrentItem = true;
            dgNamestaj.DataContext = this;
            dgNamestaj.ItemsSource = ICView;
            dgNamestaj.SelectedIndex = 0;
            //dgNamestaj.Rows[0].Selected = true;


        }

        private bool ViewFilter(object obj)
        {
            return ((Namestaj)obj).Obrisan == false;
        }
        private void DodajNamestajButton_Click(object sender, RoutedEventArgs e)
        {
            var noviNamestaj = new Namestaj()
            {
            };

            var namestajProzor = new NamestajWindow(noviNamestaj, NamestajWindow.Operacija.DODAVANJE);
            namestajProzor.ShowDialog();       

        }
        
        private void IzmeniButton_Click(object sender, RoutedEventArgs e)
        {
            
            Namestaj kopija = (Namestaj)IzabranNamestaj.Clone();
            var NamestajW = new NamestajWindow(kopija, NamestajWindow.Operacija.IZMENA);
            NamestajW.ShowDialog();

        }

        private void ObrisiButton_Click(object sender, RoutedEventArgs e)
        {          
            var listaNamestaja = Projekat.Instance.Namestaj;

            if (MessageBox.Show($"Da li zelite da obrisete: {IzabranNamestaj.Naziv }", "Brisanje", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (var n in listaNamestaja)
                {
                    if (n.Id == IzabranNamestaj.Id)
                    {
                        Namestaj.Delete(IzabranNamestaj);
                        ICView.Refresh();
                        break;
                    }
                }

               // GenericSerializer.Serialize("namestaj.xml", listaNamestaja);

            }

        }
        private void NaprednaPodesavanjaButton_Click(object sender, RoutedEventArgs e)
        {
            
            var naprednaPodesavanja = new NaprednaPodesavanjaWindow();         
            naprednaPodesavanja.ShowDialog();
            
        }

        private void IzadjiButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AkcijeButton_Click(object sender, RoutedEventArgs e)
        {
            var akcijeNamestaja = new AkcijeWindow();

            akcijeNamestaja.ShowDialog();
            
        }

        private void ProdajaButton_Click(object sender, RoutedEventArgs e)
        {
            var prodajaNamestaja = new ProdajaWindow();
            prodajaNamestaja.ShowDialog();
        }
    }
}
