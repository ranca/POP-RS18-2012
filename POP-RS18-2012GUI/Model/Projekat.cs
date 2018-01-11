using POP_RS18_2012GUI.Utils;
using System;
using System.Collections;
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

        public ObservableCollection<TipNamestaja> TipNamestaja { get; set; }

        public ObservableCollection<Namestaj> Namestaj { get; set; }

        public ObservableCollection<Akcija> Akcija { get; set; }

        //public ObservableCollection<ProdajaNamestaja> ProdajaNamestaja { get; set; }

        public ObservableCollection<Korisnik> Korisnik { get; set; }

        public ObservableCollection<DodatnaUsluga> DodatnaUsluga { get; set; }
        //public IEnumerable TipoviNamestaja { get; internal set; }

        private Projekat()
        {
            //ProdajaNamestaja = GenericSerializer.Deserialize<ProdajaNamestaja>("prodajaNamestaja.xml");
            TipNamestaja = Model.TipNamestaja.GetAllTipNamestaja();
            Namestaj = Model.Namestaj.GetAllNamestaj();
            Korisnik = Model.Korisnik.GetAllKorisnik();
            Akcija = Model.Akcija.GetAllAkcija();
            DodatnaUsluga = Model.DodatnaUsluga.GetAllDodatneUsluge();
        }
    }


}

      
