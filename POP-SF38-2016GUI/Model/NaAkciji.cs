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
    public class NaAkciji : INotifyPropertyChanged, ICloneable
    {
        private int id;
        private int idAkcije;
        private int idNamestaja;
        private Akcija akcija;
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

        public int IdAkcije
        {
            get { return idAkcije; }
            set
            {
                idAkcije = value;
                OnPropertyChanged("IdAkcije");
            }
        }
        [XmlIgnore]
        public Akcija Akcija
        {
            get
            {
                if (akcija == null)
                {
                    akcija = Akcija.GetById(IdAkcije);
                }
                return akcija;
            }
            set
            {
                akcija = value;
                IdAkcije = akcija.Id;
                OnPropertyChanged("Akcija");
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



        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public object Clone()
        {
            return new NaAkciji()
            {
                Id = id,
                IdAkcije = idAkcije,
                IdNamestaja = idNamestaja
            };
        }

        #region CRUD
        public static ObservableCollection<NaAkciji> GetAll()
        {
            var naAkciji = new ObservableCollection<NaAkciji>();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();

                cmd.CommandText = "SELECT * FROM NaAkciji;";
                da.SelectCommand = cmd;
                da.Fill(ds, "NaAkciji");

                foreach (DataRow row in ds.Tables["NaAkciji"].Rows)
                {
                    var tn = new NaAkciji();
                    tn.Id = Convert.ToInt32(row["Id"]);
                    tn.IdAkcije = Convert.ToInt32(row["IdAkcije"]);
                    tn.IdNamestaja = Convert.ToInt32(row["IdNamestaja"]);

                    naAkciji.Add(tn);
                }
            }
            return naAkciji;
        }

        public static NaAkciji Create(NaAkciji tn)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "INSERT INTO NaAkciji (IdAkcije, IdNamestaja) VALUES (@IdAkcije, @IdNamestaja);";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                //sql injection google
                cmd.Parameters.AddWithValue("IdAkcije", tn.IdAkcije);
                cmd.Parameters.AddWithValue("IdNamestaja", tn.IdNamestaja);

                tn.Id = int.Parse(cmd.ExecuteScalar().ToString());
            }

            Projekat.Instance.NaAkcijama.Add(tn);

            return tn;
        }

        public static void Update(NaAkciji tn)
        {
            //azuriranje baze
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "UPDATE NaAkciji SET IdAkcije = @IdAkcije, IdNamestaja = @IdNamestaja WHERE Id=@Id;";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("Id", tn.Id);
                cmd.Parameters.AddWithValue("IdAkcije", tn.IdAkcije);
                cmd.Parameters.AddWithValue("IdNamestaja", tn.IdNamestaja);

                cmd.ExecuteNonQuery();
            }
            //azuriranje modela
            foreach (var tip in Projekat.Instance.NaAkcijama)
            {
                if (tn.Id == tip.Id)
                {
                    tip.IdAkcije = tn.IdAkcije;
                    tip.IdNamestaja = tn.IdNamestaja;
                }
            }
        }

        public static void Delete(NaAkciji p)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "DELETE FROM NaAkciji WHERE Id=@Id;";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("Id", p.Id);

                cmd.ExecuteNonQuery();
            }
        }
        #endregion
    }
}
