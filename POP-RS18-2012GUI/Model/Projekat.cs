﻿using POP_RS18_2012.Model;
using POP_RS18_2012GUI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_RS18_2012GUI.Model
{
    public class Projekat
    {
        public static Projekat Instance { get; } = new Projekat();

        private   List<Namestaj> namestaj;

        public   List<Namestaj> Namestaj 
        {
            get {
                this.namestaj = GenericSerializer.Deserialize<Namestaj>("namestaj.xml");
                return this.namestaj; }
            set {

                this.namestaj = value;
                GenericSerializer.Serialize<Namestaj>("namestaj.xml", namestaj);
                }
        }

        private List<Akcija> akcija;

        public List<Akcija> Akcija
        {
            get
            {
                this.akcija = GenericSerializer.Deserialize<Akcija>("akcija.xml");
                return this.akcija;
            }
            set
            {

                this.akcija = value;
                GenericSerializer.Serialize<Akcija>("akcija.xml", akcija);
            }
        }

        private List<Salon>salon;

        public List<Salon> Salon
        {
            get
            {
                this.salon = GenericSerializer.Deserialize<Salon>("salon.xml");
                return this.salon;
            }
            set
            {

                this.salon = value;
                GenericSerializer.Serialize<Salon>("salon.xml", salon);
            }
        }

        private List<Korisnik> korisnik;

        public List<Korisnik> Korisnik
        {
            get
            {
                this.korisnik = GenericSerializer.Deserialize<Korisnik>("korisnik.xml");
                return this.korisnik;
            }
            set
            {

                this.korisnik = value;
                GenericSerializer.Serialize<Korisnik>("korisnik.xml", korisnik);
            }
        }

        private List<DodatnaUsluga> dodatnaUsluga;

        public List<DodatnaUsluga> DodatnaUsluga
        {
            get
            {
                this.dodatnaUsluga = GenericSerializer.Deserialize<DodatnaUsluga>("dodatnaUsluga.xml");
                return this.dodatnaUsluga;
            }
            set
            {

                this.dodatnaUsluga = value;
                GenericSerializer.Serialize<DodatnaUsluga>("dodatnaUsluga.xml", dodatnaUsluga);
            }
        }

        private List<TipNamestaja> tipoviNamestaja;

        public List<TipNamestaja> TipNamestaja
        {
            get
            {
                this.tipoviNamestaja = GenericSerializer.Deserialize<TipNamestaja>("tipoviNamestaja.xml");
                return this.tipoviNamestaja;
            }
            set
            {

                this.tipoviNamestaja = value;
                GenericSerializer.Serialize<TipNamestaja>("tipoviNamestaja.xml", tipoviNamestaja);
            }
        }

        private List<ProdajaNamestaja> prodajaNamestaja;

        public List<ProdajaNamestaja> ProdajaNamestaja
        {
            get
            {
                this.prodajaNamestaja = GenericSerializer.Deserialize<ProdajaNamestaja>("prodajaNamestaja.xml");
                return this.prodajaNamestaja;
            }
            set
            {

                this.prodajaNamestaja = value;
                GenericSerializer.Serialize<ProdajaNamestaja>("prodajaNamestaja.xml", prodajaNamestaja);
            }
        }

    }
}
