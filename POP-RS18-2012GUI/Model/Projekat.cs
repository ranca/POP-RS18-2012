using POP_RS18_2012.Model;
using POP_RS18_2012GUI.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_RS18_2012GUI.Model
{
    public class Projekat
    {
        public static Projekat Instance { get; private set; } = new Projekat();

        public ObservableCollection<TipNamestaja> TipoviNamestaja { get; set; }

        public ObservableCollection<Namestaj> Namestaj { get; set; }

        public ObservableCollection<Akcija> Akcija { get; set; }

        public ObservableCollection<ProdajaNamestaja> ProdajaNamestaja { get; set; }

        public ObservableCollection<Korisnik> Korisnik { get; set; }

        public ObservableCollection<DodatnaUsluga> DodatnaUsluga { get; set; }





        private Projekat()
        {
            //ProdajaNamestaja = GenericSerializer.Deserialize<ProdajaNamestaja>("prodajaNamestaja.xml");
            TipoviNamestaja = GenericSerializer.Deserialize<TipNamestaja>("tipoviNamestaja.xml");
            Namestaj = GenericSerializer.Deserialize<Namestaj>("namestaj.xml");
            Korisnik = GenericSerializer.Deserialize<Korisnik>("korisnik.xml");
            Akcija = GenericSerializer.Deserialize<Akcija>("akcija.xml");
            DodatnaUsluga = GenericSerializer.Deserialize<DodatnaUsluga>("dodatnaUsluga.xml");
        }
    }


}

      
