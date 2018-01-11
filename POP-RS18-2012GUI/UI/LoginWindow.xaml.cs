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

            tbUsername.Focus();
        }

        private void PrijavaButton_Click(object sender, RoutedEventArgs e)
        {
            if(!tbUsername.Text.Equals("") && !pbPassword.Password.Equals(""))
            {
                
                var listaKorisnika = Projekat.Instance.Korisnik;
                bool LoggedIn = false;
                foreach (Korisnik k in listaKorisnika)
                {
                    if(tbUsername.Text.Equals(k.KorisnickoIme) && pbPassword.Password.Equals(k.Lozinka))
                    {
                        var MainWindow = new MainWindow();
                        this.Close();
                        MainWindow.ShowDialog();
                    }
                }
                if (LoggedIn.Equals(false))
                {
                    MessageBox.Show("Unesite ispravne podatke!", "Greska", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Popunite sva polja!", "Greska", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            //
            //var obrisan = false;
            //foreach (var k in listaKorisnika)
            //{

            //    if (tbUsername.Text == "" || pbPassword.Password == "")
            //    {
            //        MessageBox.Show("Unesite ispravne podatke!", "Greska", MessageBoxButton.OK, MessageBoxImage.Warning);

            //        return;
            //    }
            //    else if (tbUsername.Text == k.KorisnickoIme && pbPassword.Password == k.Lozinka && obrisan == k.Obrisan)
            //    {
            //        var MainWindow = new MainWindow();
            //        this.Close();
            //        MainWindow.ShowDialog();

            //    }
            //}
        }

        private void pbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {

                if (!tbUsername.Text.Equals("") && !pbPassword.Password.Equals(""))
                {

                    var listaKorisnika = Projekat.Instance.Korisnik;
                    bool LoggedIn = false;
                    foreach (Korisnik k in listaKorisnika)
                    {
                        if (tbUsername.Text.Equals(k.KorisnickoIme) && pbPassword.Password.Equals(k.Lozinka))
                        {
                            var MainWindow = new MainWindow();
                            this.Close();
                            MainWindow.ShowDialog();
                        }
                    }
                    if (LoggedIn.Equals(false))
                    {
                        MessageBox.Show("Unesite ispravne podatke!", "Greska", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Popunite sva polja!", "Greska", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
            }
        }

        private void IzadjiButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }  
}
