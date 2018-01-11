using POP_RS18_2012GUI.Model;
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

namespace POP_RS18_2012.UI
{
    /// <summary>
    /// Interaction logic for AddKopraWindow.xaml
    /// </summary>
    public partial class AddKopraWindow : Window
    {
        ICollectionView ICView;

        public Namestaj IzabraniNamestaj { get; set; }

        public enum Operacija { Administrator, Preuzimanje}

        public AddKopraWindow()
        {
            InitializeComponent();

            ICView = CollectionViewSource.GetDefaultView(Projekat.Instance.Namestaj);

            ICView.Filter = ViewFilter;

            dgRaspolozivNamestaj.IsSynchronizedWithCurrentItem = true;
            dgRaspolozivNamestaj.DataContext = this;
            dgRaspolozivNamestaj.ItemsSource = ICView;

            
        }

        private bool ViewFilter(object obj)
        {
            return ((Namestaj)obj).Obrisan == false;
        }
    }
}
