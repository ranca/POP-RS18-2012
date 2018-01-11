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
    public class Akcija : INotifyPropertyChanged, ICloneable
    {
        private int id;
        private DateTime datumPocetka;
        private DateTime datumZavrsetka;
        private double popust;
        private bool obrisan;
        private ObservableCollection<Namestaj> namestajNaPopustu;
        private List<int> namestajNaPopustuId;


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


        
        public double Popust
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

        public List<int> NamestajNaPopustuId
        {
            get { return namestajNaPopustuId; }
            set
            {
                namestajNaPopustuId = value;
                OnPropertyChanged("NamestajNaPopustuId");
            }
        }

        public Akcija()
        {
            datumPocetka = DateTime.Today;
            datumZavrsetka = DateTime.Today;
            namestajNaPopustu = new ObservableCollection<Namestaj>();
            namestajNaPopustuId = new List<int>();
        }

        public static Akcija GetById(int? id)
        {
            foreach (var akcija in Projekat.Instance.Akcija)
            {
                if (akcija.id == id)
                {
                    return akcija;
                }
            }
            return null;
        }

        [XmlIgnore]
        public ObservableCollection<Namestaj> NamestajNaPopustu
        {
            get
            {
                if (namestajNaPopustu.Count == 0)
                {
                    namestajNaPopustu = PronazenjeNamestaja(NamestajNaPopustuId);                 
                }
                return namestajNaPopustu;
            }
            set
            {
                namestajNaPopustu = value;
                NamestajNaPopustuId = PronalazenjeIdNamestajaNaPopustu(namestajNaPopustu);
                OnPropertyChanged("NamestajNaPopustu");
            }
        }

        public static List<int> PronalazenjeIdNamestajaNaPopustu(ObservableCollection<Namestaj> n)
        {
            var lnID = new List<int>();
            if (n != null)
            {
                for (int i = 0; i < n.Count; i++)
                {
                    var id = n[i].Id;
                    lnID.Add(id);
                }
                return lnID;
            }
            return null;
        }

        public static ObservableCollection<Namestaj> PronazenjeNamestaja(List<int> nID)
        {
            if (nID != null)
            {
                var ln = new ObservableCollection<Namestaj>();
                for( int i=0; i < nID.Count; i++)
                {
                    var n = Namestaj.NamestajNaPopustu(nID[i]);
                    ln.Add(n);
                }
                return ln;
            }
            return null;
        }

        public override string ToString()
        {
            return $"{ DatumPocetka}, {DatumZavrsetka}";
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
                NamestajNaPopustu = namestajNaPopustu,
                NamestajNaPopustuId = namestajNaPopustuId

            };
        }



        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        //POCETAK RADA SA BAZOM
        public static ObservableCollection<Akcija> GetAllAkcija()
        {
            var listaAkcija = new ObservableCollection<Akcija>();
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RS18-2012"].ConnectionString))
            {
                SqlCommand scmd = conn.CreateCommand();
                SqlDataAdapter sda = new SqlDataAdapter();
                DataSet ds = new DataSet();

                scmd.CommandText = "SELECT * FROM Akcije WHERE Obrisan=0;";
                sda.SelectCommand = scmd;
                //izvrsavanje
                sda.Fill(ds, "Akcije");

                foreach (DataRow row in ds.Tables["Akcije"].Rows)
                {
                    var a = new Akcija();
                    a.Id = int.Parse(row["Id"].ToString());
                    a.DatumPocetka = DateTime.Parse(row["DatumPocetka"].ToString());
                    a.DatumZavrsetka = DateTime.Parse(row["datumZavrsetka"].ToString());
                    a.Popust = double.Parse(row["Popust"].ToString());
                    a.Obrisan = bool.Parse(row["Obrisan"].ToString());

                    DataSet ds2 = new DataSet();
                    SqlCommand scmd2 = conn.CreateCommand();
                    ObservableCollection<Namestaj> namestajAkcija = new ObservableCollection<Namestaj>();
                    scmd2.CommandText = "SELECT * FROM Namestaj WHERE AkcijaId=@uid AND Obrisan=0;";
                    scmd2.Parameters.AddWithValue("@uid", a.Id);
                    sda.SelectCommand = scmd2;
                    sda.Fill(ds2, "Namestaj");

                    foreach (DataRow row2 in ds2.Tables["Namestaj"].Rows)
                    {
                        int id = int.Parse(row2["Id"].ToString());
                        namestajAkcija.Add(Namestaj.GetById(id));
                        a.namestajNaPopustuId.Add(id);
                    }

                    a.NamestajNaPopustu = namestajAkcija;

                    listaAkcija.Add(a);
                }
            }
            return listaAkcija;
        }

        //CREATE
        public static Akcija Create(Akcija ca)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RS18-2012"].ConnectionString))
            {
                conn.Open();
                SqlCommand scmd = conn.CreateCommand();

                scmd.CommandText = "INSERT INTO Akcije (DatumPocetka, datumZavrsetka, Popust, Obrisan) VALUES(@DatumPocetka, @datumZavrsetka, @Popust, @Obrisan);";
                scmd.CommandText += "SELECT SCOPE_IDENTITY();";
                scmd.Parameters.AddWithValue("DatumPocetka", ca.DatumPocetka);
                scmd.Parameters.AddWithValue("DatumZavrsetka", ca.DatumZavrsetka);
                scmd.Parameters.AddWithValue("Popust", Convert.ToString(ca.Popust));
                scmd.Parameters.AddWithValue("Obrisan", ca.Obrisan);

                ca.Id = int.Parse(scmd.ExecuteScalar().ToString());

                for (int i = 0; i < ca.NamestajNaPopustu.Count; i++)
                {
                    SqlCommand scmd2 = conn.CreateCommand();
                    scmd2.CommandText = "UPDATE Namestaj SET AkcijaId = @AkcijaId WHERE Id = @NamestajNaPopustuId";
                    scmd2.Parameters.AddWithValue("NamestajNaPopustuId", ca.NamestajNaPopustu[i].Id);
                    scmd2.Parameters.AddWithValue("AkcijaId", ca.Id);
                    scmd2.ExecuteNonQuery();
                }
            }
            Projekat.Instance.Akcija.Add(ca);
            return ca;
        }

        //EDIT
        public static void Update(Akcija ua, bool delete)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RS18-2012"].ConnectionString))
            {
                conn.Open();
                SqlCommand scmd = conn.CreateCommand();

                scmd.CommandText = "UPDATE Akcije SET DatumPocetka=@DatumPocetka, datumZavrsetka=@datumZavrsetka, Popust=@Popust, Obrisan=@Obrisan WHERE Id=@Id;";
                scmd.CommandText += "SELECT SCOPE_IDENTITY();";
                scmd.Parameters.AddWithValue("Id", ua.Id);
                scmd.Parameters.AddWithValue("DatumPocetka", ua.DatumPocetka);
                scmd.Parameters.AddWithValue("datumZavrsetka", ua.DatumZavrsetka);
                scmd.Parameters.AddWithValue("Popust", ua.Popust);
                scmd.Parameters.AddWithValue("Obrisan", ua.Obrisan);

                for (int i = 0; i < ua.NamestajNaPopustu.Count; i++)
                {
                    SqlCommand scmd2 = conn.CreateCommand();
                    scmd2.CommandText = "UPDATE Namestaj SET AkcijaId = @AkcijaId WHERE Id = @NamestajNaPopustuId";
                    scmd2.Parameters.AddWithValue("NamestajNaPopustuId", ua.NamestajNaPopustu[i].Id);
                    if (delete)
                    {
                        scmd2.Parameters.AddWithValue("AkcijaId", DBNull.Value);
                    }
                    else
                    {
                        scmd2.Parameters.AddWithValue("AkcijaId", ua.Id);
                    }
                    scmd2.ExecuteNonQuery();
                }

                scmd.ExecuteNonQuery();
            }

            foreach (var ak in Projekat.Instance.Akcija)
            {
                if (ak.Id == ua.Id)
                {
                    ak.DatumPocetka = ua.DatumPocetka;
                    ak.DatumZavrsetka = ua.DatumZavrsetka;
                    ak.Popust = ua.Popust;
                    ak.Obrisan = ua.Obrisan;
                }
            }
        }

        public static void Delete(Akcija da)
        {
            da.Obrisan = true;
            foreach (var item in da.NamestajNaPopustu)
            {
                item.PopustCena = 0;
                item.AkcijaId = null;
                Namestaj.Update(item);
                foreach (var n in Projekat.Instance.Namestaj)
                {
                    if (n.Id == item.Id)
                    {
                        n.PopustCena = 0;
                    }
                }
            }
            Update(da, true);
        }

        public static bool AddAkcijskiNamestaj(Akcija a, ObservableCollection<Namestaj> dodatiNamestaji)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RS18-2012"].ConnectionString))
            {
                conn.Open();
                SqlCommand scmd = conn.CreateCommand();

                for (int i = 0; i < dodatiNamestaji.Count; i++)
                {
                    scmd.CommandText = "INSERT INTO AkcijskiNamestaj (NamestajNaPopustuId, AkcijaId, Obrisan) VALUES(@nnn, @AkcijaId, @Obrisan)";
                    scmd.Parameters.AddWithValue("@nnn", dodatiNamestaji[i].Id);
                    scmd.Parameters.AddWithValue("@AkcijaId", a.Id);
                    scmd.Parameters.AddWithValue("@Obrisan", '0');
                    scmd.ExecuteNonQuery();
                }
                return true;
            }
        }


        //Obrisan
        public static bool DeleteAkcijskiNamestaj(Akcija a, ObservableCollection<Namestaj> obrisaniNamestaji)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RS18-2012"].ConnectionString))
            {
                conn.Open();
                SqlCommand scmd = conn.CreateCommand();

                for (int i = 0; i < obrisaniNamestaji.Count; i++)
                {
                    scmd.CommandText = "UPDATE AkcijskiNamestaj SET Obrisan=@obrisan WHERE NamestajNaPopustuId=@iid AND AkcijaId=@aid";
                    scmd.Parameters.AddWithValue("@iid", obrisaniNamestaji[i].Id);
                    scmd.Parameters.AddWithValue("@aid", a.Id);
                    scmd.Parameters.AddWithValue("@obrisan", '1');
                    scmd.ExecuteNonQuery();
                }
                return true;
            }
        }
        

    }
}
