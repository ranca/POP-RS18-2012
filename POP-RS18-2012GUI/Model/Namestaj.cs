using POP_RS18_2012GUI.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace POP_RS18_2012GUI.Model
{
    [Serializable]

    public class Namestaj : INotifyPropertyChanged, ICloneable
    {
        private int id;
        private string naziv;
        private string sifra;
        private double cena;
        private int kolicinaUMagacinu;
        private int tipNamestajaId;
        private bool obrisan;
        private TipNamestaja tipNamestaja;
        private double popustCena;
        private int prodataKolicina;
        private int? akcijaId;
        private Akcija akcija;

        [XmlIgnore]
        public TipNamestaja TipNamestaja
        {
            get
            {
                if (tipNamestaja == null)
                {
                    tipNamestaja = TipNamestaja.GetById(TipNamestajaId);
                }
                return tipNamestaja;
            }
            set
            {
                tipNamestaja = value;
                TipNamestajaId = tipNamestaja.Id;
                OnPropertyChanged("TipNamestaja");
            }
        }

        [XmlIgnore]
        public Akcija Akcija
        {
            get
            {
                if (akcija == null)
                {
                    akcija = Akcija.GetById(AkcijaId);
                }
                return akcija;
            }
            set
            {
                akcija = value;
                AkcijaId = akcija.Id;
                OnPropertyChanged("Akcija");
            }
        }

        public int? AkcijaId
        {
            get { return akcijaId; }
            set
            {
                akcijaId = value;
                OnPropertyChanged("AkcijaId");
            }
        }


        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");

            }
        }

        public string Naziv
        {
            get { return naziv; }
            set
            {
                naziv = value;
                OnPropertyChanged("Naziv");

            }
        }

        public string Sifra
        {
            get { return sifra; }
            set
            {
                sifra = value;
                OnPropertyChanged("Sifra");
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

        public int KolicinaUMagacinu
        {
            get { return kolicinaUMagacinu; }
            set
            {
                kolicinaUMagacinu = value;
                OnPropertyChanged("KolicinaUMagacinu");
            }
        }

        public int TipNamestajaId
        {
            get { return tipNamestajaId; }
            set
            {
                tipNamestajaId = value;
                OnPropertyChanged("tipNamestajaId");
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

        public double PopustCena
        {
            get { return popustCena; }
            set
            {
                popustCena = value;
                OnPropertyChanged("PopustCena");
            }
        }

        public int ProdataKolicina
        {
            get { return prodataKolicina; }
            set
            {
                prodataKolicina = value;
                OnPropertyChanged("ProdataKolicina");
            }
        }

        //public int AkcijaId
        //{
        //    get { return akcijaId; }
        //    set
        //    {
        //        akcijaId = value;
        //        OnPropertyChanged("AkcijaId");
        //    }
        //}

        public event PropertyChangedEventHandler PropertyChanged;

        public override string ToString()
        {
            return $"{ Naziv}    {Sifra}    {Cena}  {KolicinaUMagacinu}     {TipNamestajaId}";
        }

        

        


        public static Namestaj NamestajNaPopustu(int id)
        {
            foreach (var naPopustu in Projekat.Instance.Namestaj)
            {
                if(naPopustu.Id == id)
                {
                    return naPopustu;
                }
            }
            return null;
        }

        public static Namestaj NamestajZaProdaju(int id)
        {
            foreach(var zaProdaju in Projekat.Instance.Namestaj)
            {
                if(zaProdaju.Id == id)
                {
                    return zaProdaju;
                }
            }
            return null;
        }

        public object Clone()
        {
            return new Namestaj()
            {
                Id = id,
                Naziv = naziv,
                Cena = cena,
                Sifra = sifra,
                KolicinaUMagacinu = kolicinaUMagacinu,
                TipNamestaja = tipNamestaja,
                TipNamestajaId = tipNamestajaId,
                Obrisan = obrisan,
                PopustCena = popustCena,
                ProdataKolicina = prodataKolicina
            };
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }




        public static ObservableCollection<Namestaj> GetAllNamestaj()
        {
            var listaNamestaja = new ObservableCollection<Namestaj>();
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RS18-2012"].ConnectionString))
            {
                SqlCommand cmd = conn.CreateCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();

                cmd.CommandText = "SELECT * FROM Namestaj WHERE Obrisan=0;";
                da.SelectCommand = cmd;
                da.Fill(ds, "Namestaj");

                foreach (DataRow row in ds.Tables["Namestaj"].Rows)
                {
                    var n = new Namestaj();
                    n.Id = int.Parse(row["Id"].ToString());
                    n.Naziv = row["Naziv"].ToString();
                    n.Cena = double.Parse(row["Cena"].ToString());
                    n.Sifra = row["Sifra"].ToString();
                    n.KolicinaUMagacinu = Convert.ToInt32(row["KolicinaUMagacinu"]);
                    n.TipNamestajaId = Convert.ToInt32(row["TipNamestajaId"]);
                    n.Obrisan = bool.Parse(row["Obrisan"].ToString());
                    n.PopustCena = double.Parse(row["PopustCena"].ToString());
                    n.ProdataKolicina = Convert.ToInt32(row["ProdataKolicina"]);
                    if (row["AkcijaId"] == DBNull.Value)
                    {
                        n.AkcijaId = null;
                    }
                    else {
                        n.AkcijaId = Convert.ToInt32(row["AkcijaId"]);
                    }

                    listaNamestaja.Add(n);
                }
            }
            return listaNamestaja;
        }

        public static Namestaj Create(Namestaj cn)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RS18-2012"].ConnectionString))
            {
                conn.Open();

                SqlCommand scmd = conn.CreateCommand();

                scmd.CommandText = "INSERT INTO Namestaj (Naziv, Cena, Sifra, KolicinaUMagacinu, TipNamestajaId, Obrisan, PopustCena, ProdataKolicina, AkcijaId) VALUES(@Naziv, @Cena, @Sifra, @KolicinaUMagacinu, @TipNamestajaId, @Obrisan, @PopustCena, @ProdataKolicina, @AkcijaId);";
                scmd.CommandText += "SELECT SCOPE_IDENTITY();";
                scmd.Parameters.AddWithValue("Naziv", cn.Naziv);
                scmd.Parameters.AddWithValue("Cena", cn.Cena);
                scmd.Parameters.AddWithValue("Sifra", cn.Sifra);
                scmd.Parameters.AddWithValue("KolicinaUMagacinu", cn.KolicinaUMagacinu);                
                scmd.Parameters.AddWithValue("TipNamestajaId", cn.TipNamestajaId);
                scmd.Parameters.AddWithValue("Obrisan", cn.Obrisan);
                scmd.Parameters.AddWithValue("PopustCena", cn.PopustCena);               
                scmd.Parameters.AddWithValue("ProdataKolicina", cn.ProdataKolicina);
                //scmd.Parameters.AddWithValue("AkcijaId", cn.AkcijaId);
                if (cn.AkcijaId == null)
                {
                    scmd.Parameters.AddWithValue("AkcijaId", DBNull.Value);
                }
                else
                {
                    scmd.Parameters.AddWithValue("AkcijaId", cn.AkcijaId);
                }

                cn.Id = int.Parse(scmd.ExecuteScalar().ToString());

            }
            Projekat.Instance.Namestaj.Add(cn);
            return cn;
        }

        public static void Update(Namestaj un)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RS18-2012"].ConnectionString))
            {
                conn.Open();

                SqlCommand scmd = conn.CreateCommand();

                scmd.CommandText = "UPDATE Namestaj SET Naziv=@Naziv, Cena=@Cena, Sifra=@Sifra, KolicinaUMagacinu=@KolicinaUMagacinu, TipNamestajaId=@TipNamestajaId, Obrisan=@Obrisan, PopustCena=@PopustCena, ProdataKolicina=@ProdataKolicina, AkcijaId=@AkcijaId WHERE Id=@Id;";
                scmd.CommandText += "SELECT SCOPE_IDENTITY();";
                scmd.Parameters.AddWithValue("Id", un.Id);
                scmd.Parameters.AddWithValue("Naziv", un.Naziv);
                scmd.Parameters.AddWithValue("Cena", un.Cena);
                scmd.Parameters.AddWithValue("Sifra", un.Sifra);
                scmd.Parameters.AddWithValue("KolicinaUMagacinu", un.KolicinaUMagacinu);
                scmd.Parameters.AddWithValue("TipNamestajaId", un.TipNamestajaId);
                scmd.Parameters.AddWithValue("Obrisan", un.Obrisan);
                scmd.Parameters.AddWithValue("PopustCena", un.PopustCena);
                scmd.Parameters.AddWithValue("ProdataKolicina", un.ProdataKolicina);
                if (un.AkcijaId == null)
                    scmd.Parameters.AddWithValue("AkcijaId", DBNull.Value);
                else
                    scmd.Parameters.AddWithValue("AkcijaId", un.AkcijaId);

                scmd.ExecuteNonQuery();
            }
            foreach (var n in Projekat.Instance.Namestaj)
            {
                if (n.Id == n.Id)
                {
                    n.Naziv = n.Naziv;
                    n.Cena = n.Cena;
                    n.Sifra = n.Sifra;
                    n.KolicinaUMagacinu = n.KolicinaUMagacinu;             
                    n.TipNamestajaId = n.TipNamestajaId;
                    n.Obrisan = n.Obrisan;
                    n.PopustCena = n.PopustCena;                    
                    n.ProdataKolicina = n.ProdataKolicina;
                    n.AkcijaId = n.AkcijaId;
                }
            }
        }

        public static void Delete(Namestaj dn)
        {
            dn.Obrisan = true;
            Update(dn);
        }


        public static Namestaj GetById(int id)
        {

            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RS18-2012"].ConnectionString))
            {
                SqlCommand scmd = conn.CreateCommand();
                SqlDataAdapter sda = new SqlDataAdapter();
                DataSet ds = new DataSet();

                scmd.CommandText = "SELECT * FROM Namestaj WHERE Obrisan=0 AND Id=@lid;";
                scmd.Parameters.AddWithValue("@lid", id);
                sda.SelectCommand = scmd;
                sda.Fill(ds, "Namestaj");

                foreach (DataRow row in ds.Tables["Namestaj"].Rows)
                {
                    var n = new Namestaj();
                    n.Id = int.Parse(row["Id"].ToString());
                    n.Naziv = row["Naziv"].ToString();
                    n.Cena = double.Parse(row["Cena"].ToString());
                    n.Sifra = row["Sifra"].ToString();
                    n.KolicinaUMagacinu = Convert.ToInt32(row["KolicinaUMagacinu"]);
                    n.TipNamestajaId = Convert.ToInt32(row["TipNamestajaId"]);
                    n.Obrisan = bool.Parse(row["Obrisan"].ToString());
                    n.PopustCena = double.Parse(row["PopustCena"].ToString());                   
                    n.ProdataKolicina = Convert.ToInt32(row["ProdataKolicina"]);
                    if (row["AkcijaId"] == DBNull.Value)
                    {
                        n.AkcijaId = null;
                    }
                    else
                    {
                        n.AkcijaId = Convert.ToInt32(row["AkcijaId"]);
                    }

                    return n;

                }
                return null;
            }

        }
    }
}
