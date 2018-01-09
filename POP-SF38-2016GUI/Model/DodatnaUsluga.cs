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
    public class DodatnaUsluga : INotifyPropertyChanged, ICloneable
    {
        private int id;
        private string usluga;
        private int cena;
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

        public string Usluga
        {
            get { return usluga; }
            set
            {
                usluga = value;
                OnPropertyChanged("Usluga");
            }
        }

        public int Cena
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



        public override string ToString()
        {
            return $"{Usluga}, {Cena} dinara";
        }

        public static DodatnaUsluga GetById(int id)
        {
            foreach (var a in Projekat.Instance.DodatneUsluge)
            {
                if (a.Id == id)
                {
                    return a;
                }
            }
            return null;
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public object Clone()
        {
            return new DodatnaUsluga()
            {
                Id = id,
                Usluga = usluga,
                Cena = cena,
                Obrisan = obrisan
            };
        }


        #region CRUD
        public static ObservableCollection<DodatnaUsluga> GetAll()
        {
            var usluge = new ObservableCollection<DodatnaUsluga>();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();

                cmd.CommandText = "SELECT * FROM Usluga WHERE Obrisan = 0;";
                da.SelectCommand = cmd;
                da.Fill(ds, "Usluga");

                foreach (DataRow row in ds.Tables["Usluga"].Rows)
                {
                    var tn = new DodatnaUsluga();
                    tn.Id = Convert.ToInt32(row["Id"]);
                    tn.Usluga = row["Naziv"].ToString();
                    tn.Cena = Convert.ToInt32(row["Cena"]);
                    tn.Obrisan = bool.Parse(row["Obrisan"].ToString());

                    usluge.Add(tn);
                }
            }
            return usluge;
        }

        public static ObservableCollection<DodatnaUsluga> Search(string srchtext, string sorttext)
        {
            var usluge = new ObservableCollection<DodatnaUsluga>();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();

                string selectCommand = "SELECT * FROM Usluga WHERE Naziv LIKE @srchtext OR Cena LIKE @srchtext ORDER BY ";
                selectCommand += sorttext;
                cmd.CommandText = selectCommand;
                //cmd.CommandText = "SELECT * FROM Usluga WHERE Naziv LIKE @srchtext OR Cena LIKE @srchtext;";
                cmd.Parameters.AddWithValue("@srchtext", "%" + srchtext + "%");
                da.SelectCommand = cmd;
                da.Fill(ds, "Usluga");

                foreach (DataRow row in ds.Tables["Usluga"].Rows)
                {
                    var tn = new DodatnaUsluga();
                    tn.Id = Convert.ToInt32(row["Id"]);
                    tn.Usluga = row["Naziv"].ToString();
                    tn.Cena = Convert.ToInt32(row["Cena"]);
                    tn.Obrisan = bool.Parse(row["Obrisan"].ToString());

                    usluge.Add(tn);
                }
                return usluge;
            }
        }

        public static DodatnaUsluga Create(DodatnaUsluga dn)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "INSERT INTO Usluga (Naziv, Cena, Obrisan) VALUES (@Naziv, @Cena, @Obrisan);";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("Naziv", dn.Usluga);
                cmd.Parameters.AddWithValue("Cena", dn.Cena);
                cmd.Parameters.AddWithValue("Obrisan", dn.Obrisan);

                dn.Id = int.Parse(cmd.ExecuteScalar().ToString());
            }
            Projekat.Instance.DodatneUsluge.Add(dn);
            return dn;
        }

        public static void Update(DodatnaUsluga dn)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "UPDATE Usluga SET Naziv=@Naziv, Cena=@Cena, Obrisan=@Obrisan WHERE Id=@Id;";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("Id", dn.Id);
                cmd.Parameters.AddWithValue("Naziv", dn.Usluga);
                cmd.Parameters.AddWithValue("Cena", dn.Cena);
                cmd.Parameters.AddWithValue("Obrisan", dn.Obrisan);

                cmd.ExecuteNonQuery();
            }

            foreach (var du in Projekat.Instance.DodatneUsluge)
            {
                if (dn.Id == du.Id)
                {
                    du.Usluga = dn.Usluga;
                    du.Cena = dn.Cena;
                    du.Obrisan = dn.Obrisan;
                }
            }
        }

        public static void Delete(DodatnaUsluga n)
        {
            n.Obrisan = true;
            Update(n);
        }
        #endregion
    }
}
