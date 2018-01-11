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
    public class Salon : INotifyPropertyChanged, ICloneable
    {
        private int id;
        private string naziv;
        private string adresa;
        private string telefon;
        private string email;
        private string sajt;
        private int pib;
        private int maticniBroj;
        private string ziroRacun;
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

        public string Adresa
        {
            get { return adresa; }
            set
            {
                adresa = value;
                OnPropertyChanged("Adresa");
            }
        }

        public string Telefon
        {
            get { return telefon; }
            set
            {
                telefon = value;
                OnPropertyChanged("Telefon");
            }
        }

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }

        public string Sajt
        {
            get { return sajt; }
            set
            {
                sajt = value;
                OnPropertyChanged("Sajt");
            }
        }

        public int PIB
        {
            get { return pib; }
            set
            {
                pib = value;
                OnPropertyChanged("PIB");
            }
        }

        public int MaticniBroj
        {
            get { return maticniBroj; }
            set
            {
                maticniBroj = value;
                OnPropertyChanged("MaticniBroj");
            }
        }

        public string ZiroRacun
        {
            get { return ziroRacun; }
            set
            {
                ziroRacun = value;
                OnPropertyChanged("ZiroRacun");
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



        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public object Clone()
        {
            return new Salon()
            {
                Id = id,
                Naziv = naziv,
                Adresa = adresa,
                Telefon = telefon,
                Email = email,
                Sajt = sajt,
                PIB = pib,
                MaticniBroj = maticniBroj, 
                ZiroRacun = ziroRacun, 
                Obrisan = obrisan
            };
        }

        public override string ToString()
        {
            return $"{Naziv}, {Adresa}, {Sajt}";
        }


        #region CRUD
        public static ObservableCollection<Salon> GetAll()
        {
            var saloni = new ObservableCollection<Salon>();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();

                cmd.CommandText = "SELECT * FROM Salon WHERE Obrisan = 0;";
                da.SelectCommand = cmd;
                da.Fill(ds, "Salon");

                foreach (DataRow row in ds.Tables["Salon"].Rows)
                {
                    var n = new Salon();
                    n.Id = Convert.ToInt32(row["Id"]);
                    n.Naziv = row["Naziv"].ToString();
                    n.Adresa = row["Adresa"].ToString();
                    n.Telefon = row["Telefon"].ToString();
                    n.Email = row["Email"].ToString();
                    n.Sajt = row["Sajt"].ToString();
                    n.PIB = Convert.ToInt32(row["PIB"]);
                    n.MaticniBroj = Convert.ToInt32(row["MaticniBroj"]);
                    n.ZiroRacun = row["ZiroRacun"].ToString();
                    n.Obrisan = bool.Parse(row["Obrisan"].ToString());

                    saloni.Add(n);
                }
            }
            return saloni;
        }

        public static void Update(Salon n)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "UPDATE Salon SET Naziv=@Naziv, Adresa=@Adresa, Telefon=@Telefon, Email=@Email," +
                    "Sajt=@Sajt, PIB=@PIB, MaticniBroj=@MaticniBroj, ZiroRacun=@ZiroRacun, Obrisan=@Obrisan WHERE Id=@Id;";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";

                cmd.Parameters.AddWithValue("Id", n.Id);
                cmd.Parameters.AddWithValue("Naziv", n.Naziv);
                cmd.Parameters.AddWithValue("Adresa", n.Adresa);
                cmd.Parameters.AddWithValue("Telefon", n.Telefon);
                cmd.Parameters.AddWithValue("Email", n.Email);
                cmd.Parameters.AddWithValue("Sajt", n.Sajt);
                cmd.Parameters.AddWithValue("PIB", n.PIB);
                cmd.Parameters.AddWithValue("MaticniBroj", n.MaticniBroj);
                cmd.Parameters.AddWithValue("ZiroRacun", n.ZiroRacun);
                cmd.Parameters.AddWithValue("Obrisan", n.Obrisan);

                cmd.ExecuteNonQuery();
            }

            foreach (var nam in Projekat.Instance.Saloni)
            {
                if (n.Id == nam.Id)
                {
                    nam.Naziv = n.Naziv;
                    nam.Adresa = n.Adresa;
                    nam.Telefon = n.Telefon;
                    nam.Email = n.Email;
                    nam.Sajt = n.Sajt;
                    nam.PIB = n.PIB;
                    nam.MaticniBroj = n.MaticniBroj;
                    nam.ZiroRacun = n.ZiroRacun;
                    nam.Obrisan = n.Obrisan;
                }
            }
        }
        #endregion

    }
}
