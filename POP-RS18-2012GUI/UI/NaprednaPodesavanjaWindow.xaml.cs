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
    /// Interaction logic for NaprednaPodesavanjaWindow.xaml
    /// </summary>
    public partial class NaprednaPodesavanjaWindow : Window
    {     

        public NaprednaPodesavanjaWindow()
        {
            InitializeComponent();         
        }

        public object ContentAlignment { get; }

        private void TipoviButton_Click(object sender, RoutedEventArgs e)
        {
            TipoviWindow tipoviNamestaja = new TipoviWindow();           
            tipoviNamestaja.ShowDialog();
        }

        private void DodatnaUslugaButton_Click(object sender, RoutedEventArgs e)
        {
            var dodatneUsluge = new DodatnaUslugaWindow();
            dodatneUsluge.ShowDialog();
        }

        private void KorisniciButton_Click(object sender, RoutedEventArgs e)
        {
            var korisnici = new KorisniciWindow();
            korisnici.ShowDialog();
        }
    }
}
