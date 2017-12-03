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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {

        //private Korisnik korisnik;
        public LoginWindow()
        {
            InitializeComponent();        
        }

        private void PrijavaButton_Click(object sender, RoutedEventArgs e)
        {
            var listaKorisnika = Projekat.Instance.Korisnik;

            foreach (var k in listaKorisnika)
            {
                if (tbUsername.Text != k.KorisnickoIme || pbPassword.Password != k.Lozinka)
                {
                    MessageBox.Show("Unesite ispravne podatke!", "Greska", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                 
                  
                } else if (tbUsername.Text == k.KorisnickoIme && pbPassword.Password == k.Lozinka)
                {
                    
                    var MainWindow = new MainWindow();
                    MainWindow.ShowDialog();
                    this.Close();
                    return;

                }
                return;
                

            }
            return;

        }
    }
}
