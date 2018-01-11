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
    /// Interaction logic for DodavanjeIzmenaDodatnaUslugaWindow.xaml
    /// </summary>
    public partial class DodavanjeIzmenaDodatnaUslugaWindow : Window
    {
        public enum Operacija
        {
            DODAVANJE,
            IZMENA
        };

        private DodatnaUsluga dodatnaUsluga;
        private Operacija operacija;

        public DodavanjeIzmenaDodatnaUslugaWindow(DodatnaUsluga dodatnaUsluga, Operacija operacija)
        {
            InitializeComponent();

            this.dodatnaUsluga = dodatnaUsluga;
            this.operacija = operacija;
            tbNaziv.DataContext = dodatnaUsluga;
            tbCena.DataContext = dodatnaUsluga;
        }

        private void SacuvajBtn(object sender, RoutedEventArgs e)
        {
            var listaDodatnihUsluga = Projekat.Instance.DodatnaUsluga;
            this.DialogResult = true;
            switch (operacija)
            {
                case Operacija.DODAVANJE:
                    dodatnaUsluga.Id = listaDodatnihUsluga.Count + 1;
                    listaDodatnihUsluga.Add(dodatnaUsluga);
                    break;
            }
            GenericSerializer.Serialize("dodatnaUsluga.xml", listaDodatnihUsluga);          
        }

        private void IzadjiBtn(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
