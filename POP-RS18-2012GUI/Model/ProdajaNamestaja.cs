using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_RS18_2012GUI.Model
{
    [Serializable]

    public class ProdajaNamestaja : INotifyPropertyChanged, ICloneable
    {
        private int id;
        private List<int> namestajZaProdajuId;
        private List<int> dodatnaUslugaId;
        private DateTime datumProdaje;
        private string brojRacuna;
        private string kupac;
        private double cena;
        private const double PDV = 0.02;
        private double ukupnaCena;
        private bool obrisan;
        private ObservableCollection<DodatnaUsluga> dodatnaUsluge;
        private ObservableCollection<Namestaj> namestajZaProdaja;


        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        public List<int> NamestajZaProdajuId
        {
            get { return namestajZaProdajuId; }
            set
            {
                namestajZaProdajuId = value;
                OnPropertyChanged("NamestajZaProdajuId");
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

        public double Cena
        {
            get { return cena; }
            set
            {
                cena = value;
                OnPropertyChanged("Cena");
            }
        }

        public double UkupnaCena
        {
            get { return ukupnaCena; }
            set
            {
                ukupnaCena = value;
                OnPropertyChanged("UkupnaCena");
            }
        }

        public bool Obrisan
        {
            get { return obrisan; }
            set
            {
                obrisan = value;
                OnPropertyChanged("Obrisan");
            }
        }

        public List<int> DodatnaUslugaId
        {
            get { return dodatnaUslugaId; }
            set
            {
                dodatnaUslugaId = value;
                OnPropertyChanged("DodatnaUslugaId");
            }
        }

        public string Kupac
        {
            get { return kupac; }
            set {
                kupac = value;
                OnPropertyChanged("Kupac");
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
                NamestajZaProdajuId = namestajZaProdajuId,
                DatumProdaje = datumProdaje,
                BrojRacuna = brojRacuna,
                Kupac = kupac,
                Cena = cena
                

            };
        }

    }
}
