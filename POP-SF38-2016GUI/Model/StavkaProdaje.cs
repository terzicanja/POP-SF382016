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

namespace POP_SF382016.Model
{
    public class StavkaProdaje : INotifyPropertyChanged, ICloneable
    {
        private int id;
        private int idProdaje;
        private int idNamestaja;
        private int kolicina;

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        public int IdProdaje
        {
            get { return idProdaje; }
            set
            {
                idProdaje = value;
                OnPropertyChanged("IdProdaje");
            }
        }

        public int IdNamestaja
        {
            get { return idNamestaja; }
            set
            {
                idNamestaja = value;
                OnPropertyChanged("IdNamestaja");
            }
        }

        public int Kolicina
        {
            get { return kolicina; }
            set
            {
                kolicina = value;
                OnPropertyChanged("Kolicina");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public object Clone()
        {
            return new StavkaProdaje()
            {
                Id = id,
                IdProdaje = idProdaje,
                IdNamestaja = idNamestaja,
                Kolicina = kolicina
            };
        }


        #region CRUD
        public static ObservableCollection<StavkaProdaje> GetAll()
        {
            var stavke = new ObservableCollection<StavkaProdaje>();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();

                cmd.CommandText = "SELECT * FROM Stavka;";
                da.SelectCommand = cmd;
                da.Fill(ds, "Stavka");

                foreach (DataRow row in ds.Tables["Stavka"].Rows)
                {
                    var tn = new StavkaProdaje();
                    tn.Id = Convert.ToInt32(row["Id"]);
                    tn.IdProdaje = Convert.ToInt32(row["IdProdaje"]);
                    tn.IdNamestaja = Convert.ToInt32(row["IdNamestaja"]);
                    tn.Kolicina = Convert.ToInt32(row["Kolicina"]);

                    stavke.Add(tn);
                }
            }
            return stavke;
        }

        public static StavkaProdaje Create(StavkaProdaje tn)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                
                cmd.CommandText = "INSERT INTO Stavka (IdProdaje, IdNamestaja, Kolicina) VALUES (@IdProdaje, @IdNamestaja, @Kolicina);";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                //sql injection google
                cmd.Parameters.AddWithValue("IdNamestaja", tn.IdNamestaja);
                cmd.Parameters.AddWithValue("IdProdaje", tn.IdProdaje);
                cmd.Parameters.AddWithValue("Kolicina", tn.Kolicina);

                tn.Id = int.Parse(cmd.ExecuteScalar().ToString());
            }

            Projekat.Instance.StavkaProdaje.Add(tn);

            return tn;
        }

        #endregion
    }
}
