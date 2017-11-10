using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_RS18_2012.Model
{
    [Serializable]

    public class ProdajaNamestaja
    {

        public int Id { get; set; }

        public List<Namestaj> NamestajZaProdaju { get; set; }

        public DateTime Datum_prodaje { get; set; }

        public string Broj_racuna { get; set; }

        public string Kupac { get; set; }

        public const double PDV = 0.02;

        public List<DodatnaUsluga> DodatnaUsluga { get; set; }

        public double UkupanIznos { get; set; }

        public Akcija Akcija { get; set; }

    }
}
