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

namespace POP_SF382016.Model
{
    public class UslugaProdaje : INotifyPropertyChanged, ICloneable
    {
        private int id;
        private int idProdaje;
        private int idUsluge;
        private ProdajaNamestaja prodajaNamestaja;
        private DodatnaUsluga dodatnaUsluga;

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
                if (prodajaNamestaja == null)
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

        public int IdUsluge
        {
            get { return idUsluge; }
            set
            {
                idUsluge = value;
                OnPropertyChanged("IdUsluge");
            }
        }
        [XmlIgnore]
        public DodatnaUsluga DodatnaUsluga
        {
            get
            {
                if (dodatnaUsluga == null)
                {
                    dodatnaUsluga = DodatnaUsluga.GetById(IdUsluge);
                }
                return dodatnaUsluga;
            }
            set
            {
                dodatnaUsluga = value;
                IdUsluge = dodatnaUsluga.Id;
                OnPropertyChanged("DodatnaUsluga");
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

        public static UslugaProdaje GetById(int id)
        {
            foreach (var u in Projekat.Instance.UslugeProdaje)
            {
                if (u.Id == id)
                {
                    return u;
                }
            }
            return null;
        }

        public object Clone()
        {
            return new UslugaProdaje()
            {
                Id = id,
                IdProdaje = idProdaje,
                IdUsluge = idUsluge
            };
        }


        #region CRUD
        public static ObservableCollection<UslugaProdaje> GetAll()
        {
            var uslugeZaProdaju = new ObservableCollection<UslugaProdaje>();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();

                cmd.CommandText = "SELECT * FROM UslugaProdaje;";
                da.SelectCommand = cmd;
                da.Fill(ds, "UslugaProdaje");

                foreach (DataRow row in ds.Tables["UslugaProdaje"].Rows)
                {
                    var tn = new UslugaProdaje();
                    tn.Id = Convert.ToInt32(row["Id"]);
                    tn.IdProdaje = Convert.ToInt32(row["IdProdaje"]);
                    tn.IdUsluge = Convert.ToInt32(row["IdUsluge"]);

                    uslugeZaProdaju.Add(tn);
                }
            }
            return uslugeZaProdaju;
        }

        public static UslugaProdaje Create(UslugaProdaje tn)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "INSERT INTO UslugaProdaje (IdProdaje, IdUsluge) VALUES (@IdProdaje, @IdUsluge);";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("IdUsluge", tn.IdUsluge);
                cmd.Parameters.AddWithValue("IdProdaje", tn.IdProdaje);

                tn.Id = int.Parse(cmd.ExecuteScalar().ToString());
            }

            Projekat.Instance.UslugeProdaje.Add(tn);

            return tn;
        }

        #endregion
    }
}
