using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_RS18_2012.Model
{
    [Serializable]

    public class Salon
    {

        public int Id { get; set; }

        public bool Obrisan { get; set; }

        public string Naziv { get; set; }

        public string Adresa { get; set; }

        public string Telefon { get; set; }

        public string Email { get; set; }

        public string Adresa_internet_sajta { get; set; }

        public int PIB { get; set; }

        public int Maticni_broj { get; set; }

        public string Broj_ziro_racuna { get; set; }

    }
}
