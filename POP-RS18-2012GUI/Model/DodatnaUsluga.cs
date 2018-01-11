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

namespace POP_RS18_2012GUI.Model
{
    [Serializable]

    public class DodatnaUsluga : INotifyPropertyChanged, ICloneable
    {

        private int id;
        private string naziv;
        private double cena;
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

        public string Naziv
        {
            get { return naziv; }
            set
            {
                naziv = value;
                OnPropertyChanged("Naziv");
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

        public bool Obrisan
        {
            get { return obrisan; }
            set
            {
                obrisan = value;
                OnPropertyChanged("Obrisan");
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


        //IMAM DOLE ZA BAZU
        //public static DodatnaUsluga GetById(int id)
        //{
        //    foreach( var dodatnaUsluga in Projekat.Instance.DodatnaUsluga)
        //    {
        //        if(dodatnaUsluga.Id == id)
        //        {
        //            return dodatnaUsluga;
        //        }
        //    }
        //    return null;
        //}

        public object Clone()
        {
            return new DodatnaUsluga()
            {
                Id = id,
                Naziv = naziv,
                Cena = cena,
                Obrisan = obrisan
            };
        }
        #region CRUD
        public static ObservableCollection<DodatnaUsluga> GetAllDodatneUsluge()
        {
            var listaDodatnihUsluga = new ObservableCollection<DodatnaUsluga>();
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RS18-2012"].ConnectionString))
            {
                SqlCommand scmd = conn.CreateCommand();
                SqlDataAdapter sda = new SqlDataAdapter();
                DataSet ds = new DataSet();

                scmd.CommandText = "SELECT * FROM DodatneUsluge WHERE Obrisan=0;";
                sda.SelectCommand = scmd;
                sda.Fill(ds, "DodatneUsluge"); //izvrsavanje upita

                foreach (DataRow row in ds.Tables["DodatneUsluge"].Rows)
                {
                    var du = new DodatnaUsluga();
                    du.Id = int.Parse(row["Id"].ToString());
                    du.Naziv = row["Naziv"].ToString();
                    du.Cena = double.Parse(row["Cena"].ToString());
                    du.Obrisan = bool.Parse(row["Obrisan"].ToString());

                    listaDodatnihUsluga.Add(du);
                }
            }
            return listaDodatnihUsluga;
        }

        //CREATE PRAVLJENJE NOVE
        public static DodatnaUsluga Create(DodatnaUsluga cdu)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RS18-2012"].ConnectionString))
            {
                conn.Open();

                SqlCommand scmd = conn.CreateCommand();

                scmd.CommandText = "INSERT INTO DodatneUsluge (Naziv, Cena, Obrisan) VALUES(@Naziv, @Cena, @Obrisan);";
                scmd.CommandText += "SELECT SCOPE_IDENTITY();";
                scmd.Parameters.AddWithValue("Naziv", cdu.Naziv);
                scmd.Parameters.AddWithValue("Cena", cdu.Cena);
                scmd.Parameters.AddWithValue("Obrisan", cdu.Obrisan);
                //Izvrsavanje
                cdu.Id = int.Parse(scmd.ExecuteScalar().ToString());          
            }
            Projekat.Instance.DodatnaUsluga.Add(cdu);
            return cdu;
        }

        //UPDATE EDIT USLUGE
        public static void Update(DodatnaUsluga edu)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RS18-2012"].ConnectionString))
            {
                conn.Open();

                SqlCommand scmd = conn.CreateCommand();

                scmd.CommandText = "UPDATE DodatneUsluge SET Naziv=@NAziv, Cena=@Cena, Obrisan=@Obrisan WHERE Id=@Id;";
                scmd.CommandText += "SELECT SCOPE_IDENTITY();";
                scmd.Parameters.AddWithValue("Id", edu.Id);
                scmd.Parameters.AddWithValue("Naziv", edu.Naziv);
                scmd.Parameters.AddWithValue("Cena", edu.Cena);
                scmd.Parameters.AddWithValue("Obrisan", edu.Obrisan);

                scmd.ExecuteNonQuery();
            }
            foreach (var usluga in Projekat.Instance.DodatnaUsluga)
            {
                if (edu.Id == usluga.Id)
                {
                    usluga.Naziv = edu.Naziv;
                    usluga.Cena = edu.Cena;
                    usluga.Obrisan = edu.Obrisan;
                }
            }
        }

        //BRISANJE
        public static void Delete(DodatnaUsluga ddu)
        {
            ddu.Obrisan = true;
            Update(ddu);
        }

        public static DodatnaUsluga GetById(int id)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RS18-2012"].ConnectionString))
            {
                SqlCommand scmd = conn.CreateCommand();
                SqlDataAdapter sda = new SqlDataAdapter();
                DataSet ds = new DataSet();

                scmd.CommandText = "SELECT * FROM DodatneUsluge WHERE Obrisan=0 AND Id=@id;";
                scmd.Parameters.AddWithValue("@id", id);
                sda.SelectCommand = scmd;
                sda.Fill(ds, "DodatneUsluge");

                foreach (DataRow row in ds.Tables["DodatneUsluge"].Rows)
                {
                    var du = new DodatnaUsluga();
                    du.Id = int.Parse(row["Id"].ToString());
                    du.Naziv = row["Naziv"].ToString();
                    du.Cena = double.Parse(row["Cena"].ToString());
                    du.Obrisan = bool.Parse(row["Obrisan"].ToString());
                    return du;
                }
            }
            return null;
        }
        #endregion
    }
}

