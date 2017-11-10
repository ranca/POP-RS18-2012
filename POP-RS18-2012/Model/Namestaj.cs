using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_RS18_2012.Model
{
    [Serializable]

    public class Namestaj
    {

        public int Id { get; set; }

        public string Naziv { get; set; }

        public string Sifra { get; set; }

        public double Jedinicna_cena { get; set; }

        public int Kolicina_u_magacinu { get; set; }

        public int TipNamestajaId { get; set; }

        public Akcija Akcija { get; set; }

        public bool Obrisan { get; set; }


    }
}
