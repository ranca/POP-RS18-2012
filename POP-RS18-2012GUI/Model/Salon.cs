using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_RS18_2012GUI.Model
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

        public static ObservableCollection<Salon> GetSalon()
        {
            var listSalon = new ObservableCollection<Salon>();
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RS18-2012"].ConnectionString))
            {
                SqlCommand scmd = conn.CreateCommand();
                SqlDataAdapter sda = new SqlDataAdapter();
                DataSet ds = new DataSet();

                scmd.CommandText = "SELECT * FROM Salon WHERE Obrisan=0;";
                sda.SelectCommand = scmd;
                sda.Fill(ds, "Salon");

                foreach (DataRow row in ds.Tables["Salon"].Rows)
                {
                    var s = new Salon();
                    s.Id = int.Parse(row["Id"].ToString());
                    s.Obrisan = bool.Parse(row["Obrisan"].ToString());
                    s.Naziv = row["Naziv"].ToString();
                    s.Adresa = row["Adresa"].ToString();
                    s.Telefon = row["Telefon"].ToString();
                    s.Email = row["Email"].ToString();
                    s.Adresa_internet_sajta = row["Adresa_internet_sajta"].ToString();
                    s.PIB = Convert.ToInt32(row["Pib"]);
                    s.Maticni_broj = Convert.ToInt32(row["Maticni_broj"]);
                    s.Broj_ziro_racuna = row["Broj_ziro_racuna"].ToString();
                    
                    listSalon.Add(s);
                }
            }
            return listSalon;
        }
    }    
}
