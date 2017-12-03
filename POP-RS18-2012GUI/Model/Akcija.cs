using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace POP_RS18_2012.Model
{
    [Serializable]
    public class Akcija : INotifyPropertyChanged
    {
        private int id;
        private DateTime datumPocetka;
        private DateTime datumZavrsetka;
        private decimal popust;
        private bool obrisan;
        private Namestaj namestaj;
        private int namestajNaPopustuId;


        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }
        public DateTime DatumPocetka
        {
            get { return datumPocetka; }
            set
            {
                datumPocetka = value;
                OnPropertyChanged("DatumPocetka");
            }
        }

        public DateTime DatumZavrsetka
        {
            get { return datumZavrsetka; }
            set
            {
                datumZavrsetka = value;
                OnPropertyChanged("DatumZavrsetka");
            }
        }

        public decimal Popust
        {
            get { return popust; }
            set
            {
                popust = value;
                OnPropertyChanged("Popust");
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

        public int NamestajNaPopustuId
        {
            get { return namestajNaPopustuId; }
            set
            {
                namestajNaPopustuId = value;
                OnPropertyChanged("NamestajNaPopustuId");
            }
        }

        [XmlIgnore]
        public Namestaj Namestaj
        {
            get
            {
                if (namestaj == null)
                {
                    namestaj = Namestaj.NamestajNaPopustu(NamestajNaPopustuId);
                }
                return namestaj;
            }
            set
            {
                namestaj = value;
                NamestajNaPopustuId = namestaj.Id;
                OnPropertyChanged("Namestaj");
            }
        }

        public override string ToString()
        {
            return $"{ DatumPocetka}, {DatumZavrsetka}, {Namestaj.NamestajNaPopustu(NamestajNaPopustuId).Naziv}, {Popust}";
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
            return new Akcija()
            {
                Id = id,
                DatumPocetka = datumPocetka,
                DatumZavrsetka = datumZavrsetka,
                Popust = popust,
                Obrisan = obrisan,
                NamestajNaPopustuId = namestajNaPopustuId
            };
        }
    }
}
