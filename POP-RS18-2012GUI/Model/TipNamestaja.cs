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

    public class TipNamestaja : INotifyPropertyChanged, ICloneable
    {
        private int id;
        private string naziv;
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

        public bool Obrisan
        {
            get { return obrisan; }
            set
            {
                obrisan = value;
                OnPropertyChanged("Obrisan");
            }
        }

        public static TipNamestaja GetById(int id)
        {
            foreach (var tip in Projekat.Instance.TipNamestaja)
            {
                if (tip.id == id)
                {
                    return tip;
                }               
            }
            return null;
        }



        public event PropertyChangedEventHandler PropertyChanged;
        public override string ToString()
        {
            return $"{Naziv}";
        }

        public object Clone()
        {
            return new TipNamestaja()
            {
                Id = id,
                Naziv = naziv,
                Obrisan = obrisan
            };
        }



        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        public static ObservableCollection<TipNamestaja> GetAllTipNamestaja()
        {
            var listaTipovaNamestaja = new ObservableCollection<TipNamestaja>();
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RS18-2012"].ConnectionString))
            {
                SqlCommand scmd = conn.CreateCommand();
                SqlDataAdapter sda = new SqlDataAdapter();
                DataSet ds = new DataSet();

                scmd.CommandText = "SELECT * FROM TipNamestaja WHERE Obrisan=0;";
                sda.SelectCommand = scmd;
                //izvrsavanje upita
                sda.Fill(ds, "TipNamestaja");

                foreach (DataRow row in ds.Tables["TipNamestaja"].Rows)
                {
                    var tn = new TipNamestaja();
                    tn.Id = int.Parse(row["Id"].ToString());
                    tn.Naziv = row["Naziv"].ToString();
                    tn.Obrisan = bool.Parse(row["Obrisan"].ToString());

                    listaTipovaNamestaja.Add(tn);
                }
            }
            return listaTipovaNamestaja;
        }

        public static TipNamestaja Create(TipNamestaja ctn)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RS18-2012"].ConnectionString))
            {
                conn.Open();

                SqlCommand scmd = conn.CreateCommand();

                scmd.CommandText = "INSERT INTO TipNamestaja (Naziv, Obrisan) VALUES(@Naziv, @Obrisan);";
                scmd.CommandText += "SELECT SCOPE_IDENTITY();";
                scmd.Parameters.AddWithValue("Naziv", ctn.Naziv);
                scmd.Parameters.AddWithValue("Obrisan", ctn.Obrisan);
                //izvrsavanje upita
                ctn.Id = int.Parse(scmd.ExecuteScalar().ToString());    
            }
            Projekat.Instance.TipNamestaja.Add(ctn);
            return ctn;
        }

        public static void Update(TipNamestaja utn)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RS18-2012"].ConnectionString))
            {
                conn.Open();

                SqlCommand scmd = conn.CreateCommand();

                scmd.CommandText = "UPDATE TipNamestaja SET Naziv=@Naziv, Obrisan=@Obrisan WHERE Id=@TId;";
                scmd.CommandText += "SELECT SCOPE_IDENTITY();";
                scmd.Parameters.AddWithValue("TId", utn.Id);
                scmd.Parameters.AddWithValue("Naziv", utn.Naziv);
                scmd.Parameters.AddWithValue("Obrisan", utn.Obrisan);

                scmd.ExecuteNonQuery();
            }
            foreach (var tip in Projekat.Instance.TipNamestaja)
            {
                if (utn.Id == tip.Id)
                {
                    tip.Naziv = utn.Naziv;
                    tip.Obrisan = utn.Obrisan;
                }
            }
        }

        public static void Delete(TipNamestaja dtn)
        {
            dtn.Obrisan = true;
            Update(dtn);
        }
    }
}