﻿using System;
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
    public class Namestaj : INotifyPropertyChanged, ICloneable
    {
        private int id;
        private string naziv;
        private string sifra;
        private double cena;
        private int kolicinaUMagacinu;
        public int idTipaNamestaja;
        private bool obrisan;
        private TipNamestaja tipNamestaja;


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

        public int IdTipaNamestaja
        {
            get { return idTipaNamestaja; }
            set
            {
                idTipaNamestaja = value;
                OnPropertyChanged("IdTipaNamestaja");
            }
        }
        [XmlIgnore]
        public TipNamestaja TipNamestaja
        {
            get
            {
                if (tipNamestaja == null)
                {
                    tipNamestaja = TipNamestaja.GetById(IdTipaNamestaja);
                }
                return tipNamestaja;
            }
            set
            {
                tipNamestaja = value;
                IdTipaNamestaja = tipNamestaja.Id;
                OnPropertyChanged("TipNamestaja");
            }
        }

        public string Sifra
        {
            get { return sifra; }
            set
            {
                sifra = value;
                OnPropertyChanged("Sifra");
            }
        }

        public double Cena
        {
            get { return cena; }
            set
            {
                cena = value;
                OnPropertyChanged("Cena");
            }
        }

        public int KolicinaUMagacinu
        {
            get { return kolicinaUMagacinu; }
            set
            {
                kolicinaUMagacinu = value;
                OnPropertyChanged("KolicinaUMagacinu");
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
            return $"{Naziv}, {Cena}, {TipNamestaja.GetById(IdTipaNamestaja).Naziv}";
        }

        public static Namestaj GetById(int id)
        {
            foreach (var namestaj in Projekat.Instance.Namestaji)
            {
                if (namestaj.Id == id)
                {
                    return namestaj;
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
            return new Namestaj()
            {
                Id = id,
                Naziv = naziv,
                Sifra = sifra,
                Cena = cena,
                KolicinaUMagacinu = kolicinaUMagacinu,
                Obrisan = obrisan, 
                TipNamestaja = tipNamestaja,
                IdTipaNamestaja = idTipaNamestaja
            };
        }

        #region CRUD
        public static ObservableCollection<Namestaj> GetAll()
        {
            var namestaji = new ObservableCollection<Namestaj>();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();

                cmd.CommandText = "SELECT * FROM Namestaj WHERE Obrisan = 0;";
                da.SelectCommand = cmd;
                da.Fill(ds, "Namestaj");

                foreach (DataRow row in ds.Tables["Namestaj"].Rows)
                {
                    var n = new Namestaj();
                    n.Id = Convert.ToInt32(row["Id"]);
                    n.IdTipaNamestaja = Convert.ToInt32(row["TipNamestajaId"]);
                    n.Naziv = row["Naziv"].ToString();
                    n.Sifra = row["Sifra"].ToString();
                    n.Cena = double.Parse(row["Cena"].ToString());
                    n.KolicinaUMagacinu = Convert.ToInt32(row["Kolicina"]);
                    n.Obrisan = bool.Parse(row["Obrisan"].ToString());

                    namestaji.Add(n);
                }
            }
            return namestaji;
        }

        public static ObservableCollection<Namestaj> Search(string srchtext, string sorttext)
        {
            var namestaji = new ObservableCollection<Namestaj>();

            using(var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();

                string selectCommand = "SELECT * FROM Namestaj WHERE (Obrisan = 0) AND (Naziv LIKE @srchtext OR Cena LIKE @srchtext) ORDER BY ";
                selectCommand += sorttext;
                cmd.CommandText = selectCommand;
                //cmd.CommandText = "SELECT * FROM Namestaj JOIN TipNamestaja On Namestaj.TipNamestajaId=TipNamestaja.Id WHERE (Namestaj.Obrisan = 0) AND (Namestaj.Naziv LIKE @srchtext OR Cena LIKE @srchtext OR TipNamestaja.Naziv LIKE @srchtext);";
                cmd.Parameters.Add(new SqlParameter("@srchtext", "%" + srchtext + "%"));
                da.SelectCommand = cmd;
                da.Fill(ds, "Namestaj");

                foreach (DataRow row in ds.Tables["Namestaj"].Rows)
                {
                    var n = new Namestaj();
                    n.Id = Convert.ToInt32(row["Id"]);
                    n.IdTipaNamestaja = Convert.ToInt32(row["TipNamestajaId"]);
                    n.Naziv = row["Naziv"].ToString();
                    n.Sifra = row["Sifra"].ToString();
                    n.Cena = double.Parse(row["Cena"].ToString());
                    n.KolicinaUMagacinu = Convert.ToInt32(row["Kolicina"]);
                    n.Obrisan = bool.Parse(row["Obrisan"].ToString());

                    namestaji.Add(n);
                }
                return namestaji;
            }
        }

        public static Namestaj Create(Namestaj n)
        {
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
                {
                    con.Open();

                    SqlCommand cmd = con.CreateCommand();

                    cmd.CommandText = "INSERT INTO Namestaj (TipNamestajaId, Naziv, Sifra, Cena, Kolicina, Obrisan) VALUES (@TipNamestajaId, @Naziv, @Sifra, @Cena, @Kolicina, @Obrisan);";
                    cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                    cmd.Parameters.AddWithValue("TipNamestajaId", n.IdTipaNamestaja);
                    cmd.Parameters.AddWithValue("Naziv", n.Naziv);
                    cmd.Parameters.AddWithValue("Sifra", n.Sifra);
                    cmd.Parameters.AddWithValue("Cena", n.Cena);
                    cmd.Parameters.AddWithValue("Kolicina", n.KolicinaUMagacinu);
                    cmd.Parameters.AddWithValue("Obrisan", n.Obrisan);

                    n.Id = int.Parse(cmd.ExecuteScalar().ToString());
                }
                Projekat.Instance.Namestaji.Add(n);

                return n;
            }
            catch (Exception)
            {
                MessageBoxResult obavestenje = MessageBox.Show("Doslo je do greske.", "Obavestenje", MessageBoxButton.OK);
                return null;
            }
            
        }

        public static void Update(Namestaj n)
        {
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
                {
                    con.Open();

                    SqlCommand cmd = con.CreateCommand();

                    cmd.CommandText = "UPDATE Namestaj SET TipNamestajaId=@TipNamestajaId, Naziv=@Naziv, " +
                        "Sifra=@Sifra, Cena=@Cena, Kolicina=@Kolicina, Obrisan=@Obrisan WHERE Id=@Id;";
                    cmd.CommandText += "SELECT SCOPE_IDENTITY();";

                    cmd.Parameters.AddWithValue("Id", n.Id);
                    cmd.Parameters.AddWithValue("TipNamestajaId", n.IdTipaNamestaja);
                    cmd.Parameters.AddWithValue("Naziv", n.Naziv);
                    cmd.Parameters.AddWithValue("Sifra", n.Sifra);
                    cmd.Parameters.AddWithValue("Cena", n.Cena);
                    cmd.Parameters.AddWithValue("Kolicina", n.KolicinaUMagacinu);
                    cmd.Parameters.AddWithValue("Obrisan", n.Obrisan);

                    cmd.ExecuteNonQuery();
                }

                foreach (var nam in Projekat.Instance.Namestaji)
                {
                    if (n.Id == nam.Id)
                    {
                        nam.IdTipaNamestaja = n.IdTipaNamestaja;
                        nam.Naziv = n.Naziv;
                        nam.Sifra = n.Sifra;
                        nam.Cena = n.Cena;
                        nam.KolicinaUMagacinu = n.KolicinaUMagacinu;
                        nam.Obrisan = n.Obrisan;
                    }
                }
            }
            catch (Exception){}
            
        }

        public static void Delete(Namestaj n)
        {
            n.Obrisan = true;
            Update(n);
        }
        #endregion
    }
}
