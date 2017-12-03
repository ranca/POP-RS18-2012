using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_RS18_2012.Model
{
    [Serializable]

    public class ProdajaNamestaja : INotifyPropertyChanged, ICloneable
    {
        private int id;
        private List<Namestaj> namestajZaProdaju;
        private DateTime datumProdaje;
        private string brojRacuna;
        private string kupac;
        private string dodatnaUsluga;
        public double pdv = 0.02;


        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        public List<Namestaj> NamestajZaProdaju
        {
            get { return namestajZaProdaju; }
            set
            {
                namestajZaProdaju = value;
                OnPropertyChanged("NamestajZaProdaju");
            }
        }

        public DateTime DatumProdaje
        {
            get { return datumProdaje; }
            set
            {
                datumProdaje = value;
                OnPropertyChanged("DatumProdaje");
            }
        }

        public string BrojRacuna
        {
            get { return brojRacuna; }
            set
            {
                brojRacuna = value;
                OnPropertyChanged("BrojRacuna");
            }

        }

        public string Kupac
        {
            get { return kupac; }
            set
            {
                kupac = value;
                OnPropertyChanged("Kupac");
            }
        }

        public string DodatnaUsluga
        {
            get { return dodatnaUsluga; }
            set
            {
                dodatnaUsluga = value;
                OnPropertyChanged("DodatnaUsluga");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;


        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public object Clone()
        {
            return new ProdajaNamestaja()
            {
                Id = id,
                NamestajZaProdaju = namestajZaProdaju,
                DatumProdaje = datumProdaje,
                BrojRacuna = brojRacuna,
                Kupac = kupac,
                DodatnaUsluga = dodatnaUsluga,
                pdv = pdv

            };
        }

    }
}
