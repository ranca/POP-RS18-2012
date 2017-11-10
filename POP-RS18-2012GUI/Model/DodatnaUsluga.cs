using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_RS18_2012.Model
{
    [Serializable]

    public class DodatnaUsluga
    {
        public int Id { get; set; }

        public string Naziv { get; set; }

        public double Cena { get; set; }




        public bool Obrisan { get; set; }
    }
}

