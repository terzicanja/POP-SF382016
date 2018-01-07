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
    public enum TipKorisnika
    {
        Administrator,
        Prodavac
    }

    public class Korisnik : INotifyPropertyChanged, ICloneable
    {
        private int id;
        private string ime;
        private string prezime;
        private string korisnickoIme;
        private string lozinka;
        private TipKorisnika tipKorisnika;
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

        public string Ime
        {
            get { return ime; }
            set
            {
                ime = value;
                OnPropertyChanged("Ime");
            }
        }

        public string Prezime
        {
            get { return prezime; }
            set
            {
                prezime = value;
                OnPropertyChanged("Prezime");
            }
        }

        public string KorisnickoIme
        {
            get { return korisnickoIme; }
            set
            {
                korisnickoIme = value;
                OnPropertyChanged("KorisnickoIme");
            }
        }

        public string Lozinka
        {
            get { return lozinka; }
            set
            {
                lozinka = value;
                OnPropertyChanged("Lozinka");
            }
        }

        public TipKorisnika TipKorisnika
        {
            get { return tipKorisnika; }
            set
            {
                tipKorisnika = value;
                OnPropertyChanged("TipKorisnika");
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
            return $"{Ime} {Prezime}";
        }

        public static Korisnik GetById(int id)
        {
            foreach (var a in Projekat.Instance.Korisnici)
            {
                if (a.Id == id)
                {
                    return a; //mozda nije id nego naziv ili nzm i onda pozivan Tipnamestaja.getbyid(idtipnamestaja)
                }
            }
            return null;
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public object Clone()
        {
            return new Korisnik()
            {
                Id = id,
                Ime = ime,
                Prezime = prezime,
                KorisnickoIme = korisnickoIme,
                Lozinka = lozinka,
                TipKorisnika = tipKorisnika,
                Obrisan = obrisan
            };
        }


        #region CRUD
        public static ObservableCollection<Korisnik> GetAll()
        {
            var korisnici = new ObservableCollection<Korisnik>();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();

                cmd.CommandText = "SELECT * FROM Korisnik WHERE Obrisan = 0;";
                da.SelectCommand = cmd;
                da.Fill(ds, "Korisnik");

                foreach (DataRow row in ds.Tables["Korisnik"].Rows)
                {
                    var tn = new Korisnik();
                    tn.Id = Convert.ToInt32(row["Id"]);
                    tn.Ime = row["Ime"].ToString();
                    tn.Prezime = row["Prezime"].ToString();
                    tn.KorisnickoIme = row["KorisnickoIme"].ToString();
                    tn.Lozinka = row["Lozinka"].ToString();
                    tn.TipKorisnika = (TipKorisnika)Enum.Parse(typeof(TipKorisnika), (row["TipKorisnika"].ToString()));
                    tn.Obrisan = bool.Parse(row["Obrisan"].ToString());

                    korisnici.Add(tn);
                }
            }
            return korisnici;
        }

        public static ObservableCollection<Korisnik> Search(string srchtext)
        {
            var korisnici = new ObservableCollection<Korisnik>();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();

                cmd.CommandText = "SELECT * FROM Korisnik WHERE Ime LIKE @srchtext OR Prezime LIKE @srchtext OR KorisnickoIme LIKE @srchtext;";
                cmd.Parameters.AddWithValue("@srchtext", "%" + srchtext + "%");
                da.SelectCommand = cmd;
                da.Fill(ds, "Korisnik");

                foreach (DataRow row in ds.Tables["Korisnik"].Rows)
                {
                    var tn = new Korisnik();
                    tn.Id = Convert.ToInt32(row["Id"]);
                    tn.Ime = row["Ime"].ToString();
                    tn.Prezime = row["Prezime"].ToString();
                    tn.KorisnickoIme = row["KorisnickoIme"].ToString();
                    tn.Lozinka = row["Lozinka"].ToString();
                    tn.TipKorisnika = (TipKorisnika)Enum.Parse(typeof(TipKorisnika), (row["TipKorisnika"].ToString()));
                    tn.Obrisan = bool.Parse(row["Obrisan"].ToString());

                    korisnici.Add(tn);
                }
                return korisnici;
            }
        }

        public static Korisnik Create(Korisnik tn)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "INSERT INTO Korisnik (Ime, Prezime, KorisnickoIme, Lozinka, TipKorisnika, Obrisan) " +
                    "VALUES (@Ime, @Prezime, @KorisnickoIme, @Lozinka, @TipKorisnika, @Obrisan);";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("Ime", tn.Ime);
                cmd.Parameters.AddWithValue("Prezime", tn.Prezime);
                cmd.Parameters.AddWithValue("KorisnickoIme", tn.KorisnickoIme);
                cmd.Parameters.AddWithValue("Lozinka", tn.Lozinka);
                cmd.Parameters.AddWithValue("TipKorisnika", tn.TipKorisnika.ToString());
                cmd.Parameters.AddWithValue("Obrisan", tn.Obrisan);

                tn.Id = int.Parse(cmd.ExecuteScalar().ToString());
            }

            Projekat.Instance.Korisnici.Add(tn);

            return tn;
        }

        public static void Update(Korisnik tn)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "UPDATE Korisnik SET Ime = @Ime, Prezime = @Prezime, " +
                    "KorisnickoIme = @KorisnickoIme, Lozinka = @Lozinka, TipKorisnika = @TipKorisnika, Obrisan = @Obrisan " +
                    "WHERE Id = @Id;";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("Id", tn.Id);
                cmd.Parameters.AddWithValue("Ime", tn.Ime);
                cmd.Parameters.AddWithValue("Prezime", tn.Prezime);
                cmd.Parameters.AddWithValue("KorisnickoIme", tn.KorisnickoIme);
                cmd.Parameters.AddWithValue("Lozinka", tn.Lozinka);
                cmd.Parameters.AddWithValue("TipKorisnika", tn.TipKorisnika);
                cmd.Parameters.AddWithValue("Obrisan", tn.Obrisan);

                cmd.ExecuteNonQuery();
            }


            foreach (var k in Projekat.Instance.Korisnici)
            {
                if (tn.Id == k.Id)
                {
                    k.Ime = tn.Ime;
                    k.Prezime = tn.Prezime;
                    k.KorisnickoIme = tn.KorisnickoIme;
                    k.Lozinka = tn.Lozinka;
                    k.TipKorisnika = tn.TipKorisnika;
                    k.Obrisan = tn.Obrisan;
                }
            }
        }

        public static void Delete(Korisnik n)
        {
            n.Obrisan = true;
            Update(n);
        }
        #endregion
    }
}
