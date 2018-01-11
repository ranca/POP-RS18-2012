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
    /// Interaction logic for ProdajaWindow.xaml
    /// </summary>
    public partial class ProdajaWindow : Window
    {

        public ProdajaNamestaja IzabraniNamestajProdaja { get; set; }

        public ProdajaWindow()
        {
            InitializeComponent();

            //dgProdaja.IsSynchronizedWithCurrentItem = true;
           // dgProdaja.DataContext = this;
           // dgProdaja.ItemsSource = Projekat.Instance.ProdajaNamestaja;

           // IzabraniNamestajProdaja = dgProdaja.SelectedItem as ProdajaNamestaja;
        }

        private void DodajRacunButton_Click(object sender, RoutedEventArgs e)
        {
            var novaProdaja = new ProdajaNamestaja();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
