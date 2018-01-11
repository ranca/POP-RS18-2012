using POP_RS18_2012GUI.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace POP_RS18_2012GUI.Model
{
    public enum TipKorisnika
    {
        Administrator,
        Prodavac
    }

    public class Korisnik : INotifyPropertyChanged, ICloneable
    {
        private int id;
        private string ime;
        private string prezime;
        private string korisnickoIme;
        private string lozinka;
        private TipKorisnika tipKorisnika;
        private bool obrisan;

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");

            }
        }

        public string Ime
        {
            get { return ime; }
            set
            {
                ime = value;
                OnPropertyChanged("Ime");
            }
        }

        public string Prezime
        {
            get { return prezime; }
            set
            {
                prezime = value;
                OnPropertyChanged("Prezime");
            }
        }

        public string KorisnickoIme
        {
            get { return korisnickoIme; }
            set
            {
                korisnickoIme = value;
                OnPropertyChanged("KorisnickoIme");
            }
        }

        public string Lozinka
        {
            get { return lozinka; }
            set
            {
                lozinka = value;
                OnPropertyChanged("Lozinka");
            }
        }

        public TipKorisnika TipKorisnika
        {
            get { return tipKorisnika; }
            set
            {
                
                tipKorisnika = value;
                OnPropertyChanged("TipKorisnika");
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


        public object Clone()
        {
            return new Korisnik()
            {
                Id = id,
                Ime = ime,
                Prezime = prezime,
                KorisnickoIme = korisnickoIme,
                Lozinka = lozinka,
                TipKorisnika = tipKorisnika,
                Obrisan = obrisan

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


        
        //POVEZIVANJE NA BAZU GETOVANJE SVEGA IZ BAZE.
        public static ObservableCollection<Korisnik> GetAllKorisnik()
        {
            var listaKorisnika = new ObservableCollection<Korisnik>();

            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RS18-2012"].ConnectionString))
            {
                SqlCommand scmd = conn.CreateCommand();
                SqlDataAdapter sda = new SqlDataAdapter();
                DataSet ds = new DataSet();


                scmd.CommandText = "SELECT * FROM Korisnici WHERE Obrisan=0;";
                sda.SelectCommand = scmd;
                sda.Fill(ds, "Korisnici");


                foreach (DataRow row in ds.Tables["Korisnici"].Rows)
                {
                    var tn = new Korisnik();
                    tn.Id = int.Parse(row["Id"].ToString());
                    tn.Ime = row["Ime"].ToString();
                    tn.Prezime = row["Prezime"].ToString();
                    tn.KorisnickoIme = row["KorisnickoIme"].ToString();
                    tn.Lozinka = row["Lozinka"].ToString();
                    tn.TipKorisnika = (TipKorisnika)Enum.Parse(typeof(TipKorisnika), row["TipKorisnika"].ToString());
                    tn.Obrisan = bool.Parse(row["Obrisan"].ToString());

                    listaKorisnika.Add(tn);
                }
            }
            return listaKorisnika;
        }

        //PRAVLJENJE NOVOG KORISNIKA
        public static Korisnik Create(Korisnik ck)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RS18-2012"].ConnectionString))
            {
                conn.Open();

                SqlCommand scmd = conn.CreateCommand();

                scmd.CommandText = "INSERT INTO Korisnici (Ime, Prezime, KorisnickoIme, Lozinka, TipKorisnika, Obrisan) VALUES(@Ime, @Prezime, @KorisnickoIme, @Lozinka, @TipKorisnika, @Obrisan);";
                scmd.CommandText += "SELECT SCOPE_IDENTITY();";
                scmd.Parameters.AddWithValue("Ime", ck.Ime);
                scmd.Parameters.AddWithValue("Prezime", ck.Prezime);
                scmd.Parameters.AddWithValue("KorisnickoIme", ck.KorisnickoIme);
                scmd.Parameters.AddWithValue("Lozinka", ck.Lozinka);
                scmd.Parameters.AddWithValue("TipKorisnika", Convert.ToString(ck.TipKorisnika));
                scmd.Parameters.AddWithValue("Obrisan", ck.Obrisan);
                
                ck.Id = int.Parse(scmd.ExecuteScalar().ToString());               
            }
            Projekat.Instance.Korisnik.Add(ck);
            return ck;
        }


        //IZMENA
        public static void Update(Korisnik uk)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RS18-2012"].ConnectionString))
            {
                conn.Open();

                SqlCommand scmd = conn.CreateCommand();

                scmd.CommandText = "UPDATE Korisnici SET Ime=@Ime, Prezime=@Prezime, KorisnickoIme=@KorisnickoIme, Lozinka=@Lozinka, TipKorisnika=@TipKorisnika, Obrisan=@Obrisan WHERE Id=@Id;";
                scmd.CommandText += "SELECT SCOPE_IDENTITY();";
                scmd.Parameters.AddWithValue("Id", uk.Id);
                scmd.Parameters.AddWithValue("Ime", uk.Ime);
                scmd.Parameters.AddWithValue("Prezime", uk.Prezime);
                scmd.Parameters.AddWithValue("KorisnickoIme", uk.KorisnickoIme);
                scmd.Parameters.AddWithValue("Lozinka", uk.Lozinka);
                scmd.Parameters.AddWithValue("TipKorisnika", uk.TipKorisnika);
                scmd.Parameters.AddWithValue("Obrisan", uk.Obrisan);

                scmd.ExecuteNonQuery();
            }
            foreach (var k in Projekat.Instance.Korisnik)
            {
                if (uk.Id == k.Id)
                {
                    k.Ime = uk.Ime;
                    k.Prezime = uk.Prezime;
                    k.KorisnickoIme = uk.KorisnickoIme;
                    k.Lozinka = uk.Lozinka;
                    k.TipKorisnika = uk.TipKorisnika;
                    k.Obrisan = uk.Obrisan;
                }
            }
        }


        //BRISANJE
        public static void Delete(Korisnik dk)
        {
            dk.Obrisan = true;
            Update(dk);
        }        
    }
}


   
