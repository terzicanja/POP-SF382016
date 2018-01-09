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
    public class Akcija : INotifyPropertyChanged, ICloneable
    {
        private int id;
        private string naziv;
        private DateTime pocetakAkcije;
        private DateTime krajAkcije;
        private double popust;
        //private List<int> idNamestaja;
        //private ObservableCollection<int> idNamestaja;


        //private bool obrisan;

        //private Namestaj namestaj;
        //public Namestaj selectedNamestaj;

        /*[XmlIgnore]
        public Namestaj Namestaj
        {
            get
            {
                if(namestaj == null)
                {
                    foreach (var i in IdNamestaja)
                    {
                        namestaj = Namestaj.GetById(IdNamestaja);
                    }
                    namestaj = Namestaj.GetById(IdNamestaja);
                    return namestaj;
                }
            }
        }*/

        

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

        public DateTime PocetakAkcije
        {
            get { return pocetakAkcije; }
            set
            {
                pocetakAkcije = value;
                OnPropertyChanged("PocetakAkcije");
            }
        }

        public DateTime KrajAkcije
        {
            get { return krajAkcije; }
            set
            {
                krajAkcije = value;
                OnPropertyChanged("KrajAkcije");
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

        /*public ObservableCollection<int> IdNamestaja
        {
            get { return idNamestaja; }
            set
            {
                idNamestaja = value;
                OnPropertyChanged("IdNamestaja");
            }
        }*/

        /*public Namestaj SelectedNamestaj
        {
            get { return selectedNamestaj; }
            set
            {
                if (selectedNamestaj == value) return;
                selectedNamestaj = value;
            }
        }
        private void IzabraniNamestaj()
        {
            var listaAkcija = Projekat.Instance.Akcija;
            
        }*/



        /*public bool Obrisan
        {
            get { return obrisan; }
            set
            {
                obrisan = value;
                OnPropertyChanged("Obrisan");
            }
        }*/


        
        //public List<Namestaj> NamestajNaPopustu { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;




        public override string ToString()
        {
            return $"{Naziv} {Popust}%";
        }

        public static Akcija GetById(int id)
        {
            foreach (var a in Projekat.Instance.Akcije)
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
            return new Akcija()
            {
                Id = id,
                PocetakAkcije = pocetakAkcije,
                KrajAkcije = krajAkcije,
                Popust = popust,
                //IdNamestaja = idNamestaja,
                //IdNamestaja = new ObservableCollection<int>(idNamestaja),

                //Obrisan = obrisan
            };
        }

        #region CRUD
        public static ObservableCollection<Akcija> GetAll()
        {
            var akcije = new ObservableCollection<Akcija>();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();

                cmd.CommandText = "SELECT * FROM Akcija;";
                da.SelectCommand = cmd;
                da.Fill(ds, "Akcija");

                foreach (DataRow row in ds.Tables["Akcija"].Rows)
                {
                    var tn = new Akcija();
                    tn.Id = Convert.ToInt32(row["Id"]);
                    tn.Naziv = row["Naziv"].ToString();
                    tn.PocetakAkcije = DateTime.Parse(row["PocetakAkcije"].ToString());
                    tn.KrajAkcije = DateTime.Parse(row["KrajAkcije"].ToString());
                    tn.Popust = Convert.ToInt32(row["Popust"]);

                    akcije.Add(tn);
                }
            }
            return akcije;
        }

        public static ObservableCollection<Akcija> Search(string srchtext, string sorttext)
        {
            var akcije = new ObservableCollection<Akcija>();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                //con.Open();
                SqlCommand cmd = con.CreateCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();

                string selectCommand = "SELECT * FROM Akcija WHERE Naziv LIKE @srchtext OR Popust LIKE @srchtext OR PocetakAkcije LIKE @srchtext OR KrajAkcije LIKE @srchtext ORDER BY ";
                selectCommand += sorttext;
                cmd.CommandText = selectCommand;
                //cmd.CommandText = "SELECT * FROM Akcija WHERE Naziv LIKE @srchtext OR Popust LIKE @srchtext OR PocetakAkcije LIKE @srchtext OR KrajAkcije LIKE @srchtext;";
                cmd.Parameters.AddWithValue("@srchtext", "%" + srchtext + "%");
                da.SelectCommand = cmd;
                da.Fill(ds, "Akcija");

                foreach (DataRow row in ds.Tables["Akcija"].Rows)
                {
                    var tn = new Akcija();
                    tn.Id = Convert.ToInt32(row["Id"]);
                    tn.Naziv = row["Naziv"].ToString();
                    tn.PocetakAkcije = DateTime.Parse(row["PocetakAkcije"].ToString());
                    tn.KrajAkcije = DateTime.Parse(row["KrajAkcije"].ToString());
                    tn.Popust = Convert.ToInt32(row["Popust"]);

                    akcije.Add(tn);
                }
                return akcije;
            }
        }

        public static Akcija Create(Akcija tn)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "INSERT INTO Akcija (Naziv, PocetakAkcije, KrajAkcije, Popust) VALUES (@Naziv, @PocetakAkcije, @KrajAkcije, @Popust);";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";

                cmd.Parameters.AddWithValue("Naziv", tn.Naziv);
                cmd.Parameters.AddWithValue("PocetakAkcije", tn.PocetakAkcije);
                cmd.Parameters.AddWithValue("KrajAkcije", tn.KrajAkcije);
                cmd.Parameters.AddWithValue("Popust", tn.Popust);

                tn.Id = int.Parse(cmd.ExecuteScalar().ToString());
            }

            Projekat.Instance.Akcije.Add(tn);

            return tn;
        }

        public static void Update(Akcija tn)
        {
            //azuriranje baze
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "UPDATE Akcija SET Naziv = @Naziv, PocetakAkcije = @PocetakAkcije, KrajAkcije = @KrajAkcije, Popust = @Popust WHERE Id=@Id;";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("Id", tn.Id);
                cmd.Parameters.AddWithValue("Naziv", tn.Naziv);
                cmd.Parameters.AddWithValue("PocetakAkcije", tn.PocetakAkcije);
                cmd.Parameters.AddWithValue("KrajAkcije", tn.KrajAkcije);
                cmd.Parameters.AddWithValue("Popust", tn.Popust);

                cmd.ExecuteNonQuery();
            }
            //azuriranje modela
            foreach (var tip in Projekat.Instance.Akcije)
            {
                if (tn.Id == tip.Id)
                {
                    tip.Naziv = tn.Naziv;
                    tip.PocetakAkcije = tn.PocetakAkcije;
                    tip.KrajAkcije = tn.KrajAkcije;
                    tip.Popust = tn.Popust;
                }
            }
        }

        #endregion
    }
}
