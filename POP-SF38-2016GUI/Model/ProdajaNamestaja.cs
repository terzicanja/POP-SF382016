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
    public class ProdajaNamestaja : INotifyPropertyChanged, ICloneable
    {
        private int id;
        //private List<int> idNamestaja;
        //private ObservableCollection<int> idStavki;
        private DateTime datumProdaje;
        private int brojRacuna;
        //private int idKupca;
        private string kupac;

        private double pdv;

        //private ObservableCollection<int> idUsluga;
        private double ukupanIznos;
        /*private Korisnik korisnik;


        public Korisnik Korisnik
        {
            get
            {
                if(korisnik == null)
                {
                    korisnik = Korisnik.GetById(IdKupca);
                }
                return korisnik;
            }
            set
            {
                korisnik = value;
                IdKupca = korisnik.Id;
                OnPropertyChanged("IdKupca");
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

        /*public ObservableCollection<int> IdStavki
        {
            get { return idStavki; }
            set
            {
                idStavki = value;
                OnPropertyChanged("IdStavki");
            }
        }*/

        public DateTime DatumProdaje
        {
            get { return datumProdaje; }
            set
            {
                datumProdaje = value;
                OnPropertyChanged("DatumProdaje");
            }
        }

        public int BrojRacuna
        {
            get { return brojRacuna; }
            set
            {
                brojRacuna = value;
                OnPropertyChanged("BrojRacuna");
            }
        }

        public string Kupac
        {
            get { return kupac; }
            set
            {
                kupac = value;
                OnPropertyChanged("Kupac");
            }
        }

        public double PDV
        {
            get { return 0.2; }
            /*set
            {
                pdv = value;
                OnPropertyChanged("PDV");
            }*/
        }

        /*public ObservableCollection<int> IdUsluga
        {
            get { return idUsluga; }
            set
            {
                idUsluga = value;
                OnPropertyChanged("IdUsluga");
            }
        }*/

        public double UkupanIznos
        {
            get { return ukupanIznos; }
            set
            {
                ukupanIznos = value;
                OnPropertyChanged("UkupanIznos");
            }
        }



        //public List<Namestaj> NamestajZaProdaju { get; set; }

        //public List<DodatnaUsluga> DodatnaUsluga { get; set; }
        


        public event PropertyChangedEventHandler PropertyChanged;



        public override string ToString()
        {
            return $"{DatumProdaje}, {Kupac}";
        }

        public static ProdajaNamestaja GetById(int id)
        {
            foreach (var a in Projekat.Instance.ProdajeNamestaja)
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
            return new ProdajaNamestaja()
            {
                Id = id,
                //IdStavki = new ObservableCollection<int>(idStavki),
                DatumProdaje = datumProdaje,
                BrojRacuna = brojRacuna,
                Kupac = kupac,
                //PDV = 0.2,
                //IdUsluga = new ObservableCollection<int>(idUsluga),
                UkupanIznos = ukupanIznos
            };
        }

        #region CRUD
        public static ObservableCollection<ProdajaNamestaja> GetAll()
        {
            var prodaje = new ObservableCollection<ProdajaNamestaja>();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();

                cmd.CommandText = "SELECT * FROM Prodaja;";
                da.SelectCommand = cmd;
                da.Fill(ds, "Prodaja");

                foreach (DataRow row in ds.Tables["Prodaja"].Rows)
                {
                    var tn = new ProdajaNamestaja();
                    tn.Id = Convert.ToInt32(row["Id"]);
                    tn.DatumProdaje = DateTime.Parse(row["DatumProdaje"].ToString());
                    tn.BrojRacuna = Convert.ToInt32(row["BrojRacuna"]);
                    tn.Kupac = row["Kupac"].ToString();
                    tn.UkupanIznos = double.Parse(row["UkupanIznos"].ToString());

                    prodaje.Add(tn);
                }
            }
            return prodaje;
        }

        public static ProdajaNamestaja Create(ProdajaNamestaja tn)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "INSERT INTO Prodaja (DatumProdaje, BrojRacuna, Kupac, UkupanIznos) VALUES (@DatumProdaje, @BrojRacuna, @Kupac, @UkupanIznos);";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                
                cmd.Parameters.AddWithValue("DatumProdaje", tn.DatumProdaje);
                cmd.Parameters.AddWithValue("BrojRacuna", tn.BrojRacuna);
                cmd.Parameters.AddWithValue("Kupac", tn.Kupac);
                cmd.Parameters.AddWithValue("UkupanIznos", tn.UkupanIznos);

                tn.Id = int.Parse(cmd.ExecuteScalar().ToString());
            }

            Projekat.Instance.ProdajeNamestaja.Add(tn);

            return tn;
        }

        public static void Update(ProdajaNamestaja tn)
        {
            //azuriranje baze
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "UPDATE Prodaja SET DatumProdaje = @DatumProdaje, BrojRacuna = @BrojRacuna, " +
                    "Kupac = @Kupac, UkupanIznos = @UkupanIznos WHERE Id=@Id;";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("Id", tn.Id);
                cmd.Parameters.AddWithValue("DatumProdaje", tn.DatumProdaje);
                cmd.Parameters.AddWithValue("BrojRacuna", tn.BrojRacuna);
                cmd.Parameters.AddWithValue("Kupac", tn.Kupac);
                cmd.Parameters.AddWithValue("UkupanIznos", tn.UkupanIznos);

                cmd.ExecuteNonQuery();
            }
            //azuriranje modela
            foreach (var tip in Projekat.Instance.ProdajeNamestaja)
            {
                if (tn.Id == tip.Id)
                {
                    tip.DatumProdaje = tn.DatumProdaje;
                    tip.BrojRacuna = tn.BrojRacuna;
                    tip.Kupac = tn.Kupac;
                    tip.UkupanIznos = tn.UkupanIznos;
                }
            }
        }
        #endregion
    }
}
