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
using System.Windows;
using System.Xml.Serialization;

namespace POP_SF382016.Model
{
    public class StavkaProdaje : INotifyPropertyChanged, ICloneable
    {
        private int id;
        private int idProdaje;
        private int idNamestaja;
        private int kolicina;
        private ProdajaNamestaja prodajaNamestaja;
        private Namestaj namestaj;

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
        [XmlIgnore]
        public ProdajaNamestaja ProdajaNamestaja
        {
            get
            {
                if(prodajaNamestaja == null)
                {
                    prodajaNamestaja = ProdajaNamestaja.GetById(IdProdaje);
                }
                return prodajaNamestaja;
            }
            set
            {
                prodajaNamestaja = value;
                IdProdaje = prodajaNamestaja.Id;
                OnPropertyChanged("ProdajaNamestaja");
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
        [XmlIgnore]
        public Namestaj Namestaj
        {
            get
            {
                if (namestaj == null)
                {
                    namestaj = Namestaj.GetById(IdNamestaja);
                }
                return namestaj;
            }
            set
            {
                namestaj = value;
                IdNamestaja = namestaj.Id;
                OnPropertyChanged("Namestaj");
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
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
                {
                    con.Open();

                    SqlCommand cmd = con.CreateCommand();

                    cmd.CommandText = "INSERT INTO Stavka (IdProdaje, IdNamestaja, Kolicina) VALUES (@IdProdaje, @IdNamestaja, @Kolicina);";
                    cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                    cmd.Parameters.AddWithValue("IdNamestaja", tn.IdNamestaja);
                    cmd.Parameters.AddWithValue("IdProdaje", tn.IdProdaje);
                    cmd.Parameters.AddWithValue("Kolicina", tn.Kolicina);

                    tn.Id = int.Parse(cmd.ExecuteScalar().ToString());
                }

                Projekat.Instance.StavkeProdaje.Add(tn);

                return tn;
            }
            catch (Exception)
            {
                MessageBoxResult obavestenje = MessageBox.Show("Doslo je do greske.", "Obavestenje", MessageBoxButton.OK);
                return null;
            }
            
        }

        public static void Update(StavkaProdaje tn)
        {
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
                {
                    con.Open();

                    SqlCommand cmd = con.CreateCommand();

                    cmd.CommandText = "UPDATE Stavka SET IdProdaje = @IdProdaje, IdNamestaja = @IdNamestaja, Kolicina = @Kolicina WHERE Id=@Id;";
                    cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                    cmd.Parameters.AddWithValue("Id", tn.Id);
                    cmd.Parameters.AddWithValue("IdProdaje", tn.IdProdaje);
                    cmd.Parameters.AddWithValue("IdNamestaja", tn.IdNamestaja);
                    cmd.Parameters.AddWithValue("Kolicina", tn.Kolicina);

                    cmd.ExecuteNonQuery();
                }
                //azuriranje modela
                foreach (var tip in Projekat.Instance.StavkeProdaje)
                {
                    if (tn.Id == tip.Id)
                    {
                        tip.IdProdaje = tn.IdProdaje;
                        tip.IdNamestaja = tn.IdNamestaja;
                        tip.Kolicina = tn.Kolicina;
                    }
                }
            }
            catch (Exception)
            {
                MessageBoxResult obavestenje = MessageBox.Show("Doslo je do greske.", "Obavestenje", MessageBoxButton.OK);
            }
            
        }

        public static void Delete(StavkaProdaje p)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "DELETE FROM Stavka WHERE Id=@Id;";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("Id", p.Id);

                cmd.ExecuteNonQuery();
            }
        }
        #endregion
    }
}
